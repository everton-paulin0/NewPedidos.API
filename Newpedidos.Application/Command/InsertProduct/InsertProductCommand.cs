
using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Command.InsertProduct
{
    public class InsertProductCommand : IRequest<ResultViewModel<int>>
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }


        public Product ToEntityProduct()
            => new Product(ProductName, Quantity, Price, OrderId);
    }
}
