using MediatR;
using Newpedidos.Application.Model;
using Newpedidos.Application.Notification.OrderCreated;
using NewPedidos.Infractruture.Persistence;


namespace Newpedidos.Application.Command.InsertOrder
{
    public class InsertOrderHandler : IRequestHandler<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public InsertOrderHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntityOrder();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var orderCreatead = new OrderCreatedNotification(order.Id, order.ClientName);

            await _mediator.Publish(orderCreatead);

            return ResultViewModel<int>.Sucess(order.Id);
        }
    }
}
