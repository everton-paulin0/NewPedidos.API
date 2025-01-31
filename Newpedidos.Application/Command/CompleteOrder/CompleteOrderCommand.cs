using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.CompleteOrder
{
    public class CompleteOrderCommand : IRequest<ResultViewModel>
    {
        public CompleteOrderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
