using MediatR;


namespace Newpedidos.Application.Notification.ProductCreated
{
    public class GenerateProductBoardHandler : INotificationHandler<ProductCreatedNotification>
    {
        public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Pedidos Cadastrados : {notification.ProductName}");

            return Task.CompletedTask;
        }
    }
}
