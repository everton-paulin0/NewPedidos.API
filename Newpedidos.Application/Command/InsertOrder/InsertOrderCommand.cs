using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Command.InsertOrder
{
    public class InsertOrderCommand : IRequest<ResultViewModel<int>>
    {
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public int IdProduct { get; set; }


        public Order ToEntityOrder()
            => new Order(ClientDoc, ClientName, IdProduct);
    }
}
