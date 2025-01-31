using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class ProductItemViewModel
    {
        public ProductItemViewModel(int id, string productName, int quantity, double price, int idOrder)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            IdOrder = idOrder;
            TotalCost = (quantity * price);
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public int IdOrder { get; set; }

        public static ProductItemViewModel FromEntityProduct(Product product)
           => new(product.Id, product.ProductName, product.Quantity, product.Price, product.IdOrder);
    }
}
