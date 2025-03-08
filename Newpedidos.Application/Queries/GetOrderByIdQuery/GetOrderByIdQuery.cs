using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdQuery : IRequest<ResultViewModel<OrderViewModel>>
    {
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, ResultViewModel<OrderViewModel>>
    {
        private readonly AppDbContext _context;
        public GetOrderByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<OrderViewModel>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Order
                .Include(p => p.Products)
                .Where(o => !o.IsDeleted)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            var model = OrderViewModel.FromEntityOrder(order);

            return ResultViewModel<OrderViewModel>.Success(model);
        }
    }
}
