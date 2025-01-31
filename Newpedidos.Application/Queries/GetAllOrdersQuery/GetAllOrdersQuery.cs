using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;


namespace Newpedidos.Application.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersQuery : IRequest<ResultViewModel<List<OrderItemViemModel>>>
    {
        public GetAllOrdersQuery()
        {

        }

        public class GetAllordesHandler : IRequestHandler<GetAllOrdersQuery, ResultViewModel<List<OrderItemViemModel>>>
        {
            private readonly AppDbContext _context;
            public GetAllordesHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ResultViewModel<List<OrderItemViemModel>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _context.Orders
                    .Include(p => p.Products)
                    .Where(o => !o.IsDeleted).ToListAsync();

                var model = orders.Select(OrderItemViemModel.FromEntityOrder).ToList();


                return ResultViewModel<List<OrderItemViemModel>>.Sucess(model);
            }
        }

    }
}
