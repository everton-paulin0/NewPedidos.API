
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using Newpedidos.Application.Notification.ProductCreated;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.InsertProduct
{
    public class InsertProductHandler : IRequestHandler<InsertProductCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public InsertProductHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
                     
            var product = request.ToEntityProduct();

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            var orderCreatead = new ProductCreatedNotification(product.Id, product.ProductName, product.Quantity, product.Price);

            await _mediator.Publish(orderCreatead);

            return ResultViewModel<int>.Sucess(product.Id);

            
        }
    }
}
