using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPedidos.Core.Entities
{
    public class Product:BaseEntities
    {
        public Product()
        {

        }

        public Product(string productName, int quantity, double price, int orderId):base()
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            TotalCost = (quantity * price);
            OrderId = orderId;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
       

        public void UpdateProduct(string productName, int quantity, double price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            UpdatedAt = DateTime.Now;
        }
    }
}
