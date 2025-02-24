using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Newpedidos.Application.Notification.UserCreated
{
    public class UserNotificationHandler : INotificationHandler<UserCreatedNotification>
    {
        public Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"O Usuário - {notification.Id} - Descrição : {notification.UserName}, foi cadastrado com sucesso.");

            return Task.CompletedTask;
        }
    }
}
