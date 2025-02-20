using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Model
{
    public class OrderItemViemModel
    {
        public OrderItemViemModel(int id, string clientDoc, string clientName, DocumentType documentType, string emailAddress, string address, int numberAddress, string neighborhood, string city, States state, int postalCode, OrderStatus status, List<Product> products)
        {
            Id = id;
            ClientDoc = clientDoc;
            ClientName = clientName;
            DocumentType = documentType;
            EmailAddress = emailAddress;
            Address = address;
            NumberAddress = numberAddress;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            PostalCode = postalCode;
            Products = products.Select(c => $" Produto: {c.ProductName} - Quantidade: {c.Quantity} - Valor Unitário: {c.Price} ").ToList();
            Total = products.Sum(c => c.Price);
            Status = status;
        }

        public int Id { get; set; }
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
        public OrderStatus Status { get; set; }
        public List<string> Products { get; private set; }
        public double Total { get; set; }


        public static OrderItemViemModel FromEntityOrder(Order order)
            => new(order.Id, order.ClientDoc, order.ClientName,order.DocumentType, order.EmailAddress, order.Address, order.NumberAddress, order.Neighborhood, order.City, order.State, order.PostalCode,order.Status ,order.Products);
    }
}
