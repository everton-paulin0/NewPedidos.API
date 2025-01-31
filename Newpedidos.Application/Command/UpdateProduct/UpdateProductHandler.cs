using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public UpdateProductHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Product.SingleOrDefaultAsync(p => p.Id == request.IdProduct);

            if (product is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            product.UpdateProduct(request.ProductName, request.Quantity, request.Price, request.IdProduct);

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
