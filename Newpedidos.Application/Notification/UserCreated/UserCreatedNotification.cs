using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Notification.UserCreated
{
    public class UserCreatedNotification : INotification
    {
        public UserCreatedNotification(int id, string userName, string userEmail, Level userLevel, string password)
        {
            Id = id;
            UserName = userName;
            UserEmail = userEmail;
            UserLevel = userLevel;
            Password = password;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Level UserLevel { get; set; }
        public string Password { get; set; }
    }
}
