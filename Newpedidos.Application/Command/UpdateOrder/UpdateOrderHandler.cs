using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public UpdateOrderHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Order.SingleOrDefaultAsync(p => p.Id == request.IdOrder);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.Update(request.ClientDoc, request.ClientName, request.EmailAddress,request.Address, request.NumberAddress,request.Neighborhood, request.City, request.State, request.PostalCode);

            _context.Order.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
