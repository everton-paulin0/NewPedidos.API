using System.ComponentModel;
using NewPedidos.Core.Enum;

namespace NewPedidos.Core.Entities
{
    public class Order : BaseEntities
    {
        public Order()
        {

        }
        
        public Order(string clientDoc, string clientName, DocumentType documentType, string emailAddress, string address, int numberAddress, string neighborhood, string city, States state, int postalCode, int userId)
        {
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
            UserId = userId;
            Status = OrderStatus.Started;
            Products = [];
            
        }
        [Description("Numero de Documento")]
        public string ClientDoc { get; set; }
        [Description("Nome Completo / Razão Scial")]
        public string ClientName { get; set; }
        [Description("CPF / CNPJ")]
        public DocumentType DocumentType { get; set; }
        [Description("Email")]
        public string EmailAddress { get; set; }
        [Description("Endereço")]
        public string Address { get; set; }
        [Description("Número")] 
        public int NumberAddress { get; set; }
        [Description("Bairro")]
        public string Neighborhood { get; set; }
        [Description("Cidade")]
        public string City { get; set; }
        [Description("Estado")]
        public States State { get; set; }
        [Description("CEP")]
        public int PostalCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Description("Status")]
        public OrderStatus Status { get; set; }
        [Description("Produtos")]
        public List<Product> Products { get; set; }
        


        public void Update(string clientDoc, string clientName, string emailAddress, string address, int numberAddress, string neighborhood, string city, States state, int postalCode)
        {
            ClientDoc = clientDoc;
            ClientName = clientName;
            EmailAddress = emailAddress;
            Address = address;
            NumberAddress = numberAddress;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            PostalCode = postalCode;
            UpdatedAt = DateTime.Now;
        }

        public void Complete()
        {
            if (Status != OrderStatus.PaymentPending && Status != OrderStatus.Fronzen && Status != OrderStatus.Cancelled)
            {
                Status = OrderStatus.Finished;
                UpdatedAt = DateTime.Now;
            }
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Started || Status == OrderStatus.Fronzen)
            {
                Status = OrderStatus.Cancelled;
                UpdatedAt = DateTime.Now;
            }
        }

        public void SetPaymentPending()
        {
            if (Status == OrderStatus.Started && Status != OrderStatus.Finished)
            {
                Status = OrderStatus.PaymentPending;
                UpdatedAt = DateTime.Now;
            }
        }
    }
}
