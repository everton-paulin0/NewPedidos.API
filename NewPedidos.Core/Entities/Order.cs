using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Enum;

namespace NewPedidos.Core.Entities
{
    public class Order : BaseEntities
    {
        public Order()
        {

        }
        public Order(string clientDoc, string clientName, int idProduct) : base()
        {
            ClientDoc = clientDoc;
            ClientName = clientName;
            Status = OrderStatus.Started;
            IdProduct = idProduct;
            Products = [];
            
        }


        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public OrderStatus Status { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        

        public void Update(string clientdoc, string clientName)
        {
            ClientDoc = clientdoc;
            ClientName = clientName;
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
