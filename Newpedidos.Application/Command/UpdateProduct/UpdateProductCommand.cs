using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ResultViewModel>
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
