using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<ResultViewModel>
    {
        public int IdOrder { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
    }
}
