using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.SetAsPemding
{
    public class SetAsPendingOrderCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public SetAsPendingOrderCommand(int id)
        {
            Id = id;
        }
    }
}
