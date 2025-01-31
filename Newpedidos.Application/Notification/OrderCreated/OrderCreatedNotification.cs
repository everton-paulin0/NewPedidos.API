using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Newpedidos.Application.Notification.OrderCreated
{
    public class OrderCreatedNotification : INotification
    {
        public OrderCreatedNotification(int id, string clientName)
        {
            Id = id;
            ClientName = clientName;
        }

        public int Id { get; set; }
        public string ClientName { get; set; }
    }
}
