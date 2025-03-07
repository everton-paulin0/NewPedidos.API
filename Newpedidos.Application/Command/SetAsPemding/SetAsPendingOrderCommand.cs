using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.SetAsPemding
{
    public class SetAsPendingOrderCommand : IRequest<ResultViewModel>
    {
        public SetAsPendingOrderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        
    }
}
