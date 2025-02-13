using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Model
{
    public class OrderItemViemModel
    {
        public OrderItemViemModel(int id, string clientDoc, string clientName, OrderStatus status, List<Product> products)
        {
            Id = id;
            ClientDoc = clientDoc;
            ClientName = clientName;
            Products = products.Select(c => c.ProductName).ToList();
            Status = status;
        }

        

        public int Id { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public OrderStatus Status { get; set; }
        public List<string> Products { get; private set; }


        public static OrderItemViemModel FromEntityOrder(Order order)
            => new(order.Id, order.ClientDoc, order.ClientName,order.Status ,order.Products);
    }
}
