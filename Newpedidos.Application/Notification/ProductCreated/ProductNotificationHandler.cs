using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Newpedidos.Application.Notification.ProductCreated
{
    public class ProductNotificationHandler : INotificationHandler<ProductCreatedNotification>
    {
        public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"O(s)  Produto(s) - {notification.Id} - Descrição : {notification.ProductName}, foi cadastrado com sucesso.");

            return Task.CompletedTask;
        }
    }
}
