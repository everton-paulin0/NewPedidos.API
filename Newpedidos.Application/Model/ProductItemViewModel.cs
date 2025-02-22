
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class ProductItemViewModel
    {
        public ProductItemViewModel(int id, string productName, int quantity, double price,  int orderId)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            TotalCost = (quantity * price);
            OrderId = orderId;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public int OrderId { get; set; }


        public static ProductItemViewModel FromEntityProduct(Product product)
           => new(product.Id, product.ProductName, product.Quantity, product.Price, product.OrderId);
    }
}
