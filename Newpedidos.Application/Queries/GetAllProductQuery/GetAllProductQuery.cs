using MediatR;
using Newpedidos.Application.Model;


namespace Newpedidos.Application.Queries.GetAllProductQuery
{
    public class GetAllProductQuery : IRequest<ResultViewModel<List<ProductItemViewModel>>>
    {
        public GetAllProductQuery()
        {
            
        }        
        
    }
  
}



