using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class OrderViewModel
    {
        public OrderViewModel(int id, string clientDoc, string clientName, string emailAddress, string address, int numberAddress, string neighborhood, string city, string state, int postalCode,int userId, List<Product> products)
        {
            Id = id;
            ClientDoc = clientDoc;
            ClientName = clientName;            
            EmailAddress = emailAddress;
            Address = address;
            NumberAddress = numberAddress;
            Neighborhood = neighborhood;
            City = city;
            State = state.ToString();
            PostalCode = postalCode;
            UserId = userId;
            Products = products.Select(c => $"{c.ProductName} - {c.Quantity} - {c.Price}").ToList();
            
            Total = products.Sum(c=> c.TotalCost);
        }

        public int Id { get; set; }        
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int NumberAddress { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public int UserId { get; set; }
        public List<string> Products { get; private set; }
        public double Total { get; set; }


        public static OrderViewModel FromEntityOrder(Order entity)
            => new OrderViewModel(entity.Id, entity.ClientDoc, entity.ClientName, entity.EmailAddress, entity.Address, entity.NumberAddress, entity.Neighborhood, entity.City,entity.State.ToString(), entity.PostalCode, entity.UserId, entity.Products);
    }
}
