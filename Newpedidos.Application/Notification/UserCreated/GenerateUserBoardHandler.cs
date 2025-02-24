using MediatR;


namespace Newpedidos.Application.Notification.UserCreated
{
    public class GenerateUserBoardHandler : INotificationHandler<UserCreatedNotification>
    {
        public Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Usuários Cadastrados : {notification.UserName}");

            return Task.CompletedTask;
        }
    }
}
