using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Command.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<ResultViewModel>
    {
        public int IdOrder { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int NumberAddress { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public int PostalCode { get; set; }
    }
}
