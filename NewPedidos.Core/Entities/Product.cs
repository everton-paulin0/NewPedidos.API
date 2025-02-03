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

        public Product(string productName, int quantity, double price, int idOrder):base()
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            TotalCost = (quantity * price);
            IdOrder = idOrder;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public int IdOrder { get; set; }
        public Order Order { get; set; }
        public List<Order> OwnedOrders { get; private set; }

        public void UpdateProduct(string productName, int quantity, double price, int idOrder)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            IdOrder = idOrder;
            UpdatedAt = DateTime.Now;
        }
    }
}
