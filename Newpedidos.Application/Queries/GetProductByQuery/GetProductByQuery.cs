using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Queries.GetProductByQuery
{
    public class GetProductByQuery : IRequest<ResultViewModel<ProductViewModel>>
    {
        public GetProductByQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }


        public class GetProductByIdHandler : IRequestHandler<GetProductByQuery, ResultViewModel<ProductViewModel>>
        {
            private readonly AppDbContext _context;
            public GetProductByIdHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<ResultViewModel<ProductViewModel>> Handle(GetProductByQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Product
                    .Where(o => !o.IsDeleted)
                    .SingleOrDefaultAsync(p => p.Id == request.Id);

                if (product is null)
                {
                    return ResultViewModel<ProductViewModel>.Error("Produto não existe");
                }

                var model = ProductViewModel.FromEntityProduct(product);

                return ResultViewModel<ProductViewModel>.Sucess(model);
            }
        }
    }
}
