using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<ResultViewModel>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
