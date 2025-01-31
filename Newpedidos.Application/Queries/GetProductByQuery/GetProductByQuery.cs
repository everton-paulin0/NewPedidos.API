using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Queries.GetProductByQuery
{
    public class GetProductByQuery : IRequest<ResultViewModel<ProductViewModel>>
    {
        public GetProductByQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        
    }
}
