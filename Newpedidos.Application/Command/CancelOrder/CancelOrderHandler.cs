using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.CancelOrder
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public CancelOrderHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Order.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }
            order.Cancel();

            _context.Order.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
