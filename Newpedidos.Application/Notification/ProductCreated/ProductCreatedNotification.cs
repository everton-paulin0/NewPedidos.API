using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Newpedidos.Application.Notification.ProductCreated
{
    public class ProductCreatedNotification : INotification
    {
        public ProductCreatedNotification(int id, string productName, int quantity, double price, int idOrder)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            IdOrder = idOrder;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int IdOrder { get; set; }
    }
}
