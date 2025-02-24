using System.ComponentModel;
using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Core.Entities;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Command.InsertOrder
{
    public class InsertOrderCommand : IRequest<ResultViewModel<int>>
    {
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public DocumentType DocumentType { get; set; }        
        public string EmailAddress { get; set; }        
        public string Address { get; set; }        
        public int NumberAddress { get; set; }        
        public string Neighborhood { get; set; }        
        public string City { get; set; }        
        public States State { get; set; }        
        public int PostalCode { get; set; }
        public int UserId { get; set; }

        public Order ToEntityOrder()
            => new Order(ClientDoc, ClientName, DocumentType, EmailAddress, Address, NumberAddress, Neighborhood, City, State, PostalCode, UserId);
    }
}
