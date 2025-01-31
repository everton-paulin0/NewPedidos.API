using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class OrderItemViemModel
    {
        public OrderItemViemModel(int id, string clientDoc, string clientName)
        {
            Id = id;
            ClientDoc = clientDoc;
            ClientName = clientName;
        }

        public int Id { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }


        public static OrderItemViemModel FromEntityOrder(Order order)
            => new(order.Id, order.ClientDoc, order.ClientName);
    }
}
