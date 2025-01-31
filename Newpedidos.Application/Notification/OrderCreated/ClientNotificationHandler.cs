using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Newpedidos.Application.Notification.OrderCreated
{
    public class ClientNotificationHandler : INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"O Pedido - {notification.Id} - Cliente : {notification.ClientName}, foi emitido com sucesso.");

            return Task.CompletedTask;
        }
    }
}
