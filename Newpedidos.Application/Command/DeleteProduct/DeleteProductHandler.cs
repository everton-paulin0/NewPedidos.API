using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Command.DeleteOrder;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;


namespace Newpedidos.Application.Command.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteOrderCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public DeleteProductHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (product is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            product.SetAsDeleted();

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
