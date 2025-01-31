using System;
using System.Collections.Generic;
using MediatR;

namespace Newpedidos.Application.Notification.OrderCreated
{
    public class GenerateOrderBoardHandler : INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Pedidos Gerados do Cliente: {notification.ClientName}");

            return Task.CompletedTask;
        }
    }
}
