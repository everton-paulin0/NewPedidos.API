using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;


namespace Newpedidos.Application.Queries.GetAllProductQuery
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductQuery, ResultViewModel<List<ProductItemViewModel>>>
    {
        private readonly AppDbContext _context;
        public GetAllProductsHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<ProductItemViewModel>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
            .Where(o => !o.IsDeleted).ToListAsync();

            var model = products.Select(ProductItemViewModel.FromEntityProduct).ToList();

            return ResultViewModel<List<ProductItemViewModel>>.Sucess(model);
        }
    }
}
