using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Queries.GetOrderByIdQuery
{
    public class GetOrderByIdQuery : IRequest<ResultViewModel<OrderViewModel>>
    {
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
