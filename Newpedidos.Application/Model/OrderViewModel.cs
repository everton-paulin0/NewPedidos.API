using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class OrderViewModel
    {
        public OrderViewModel(int id, string clientDoc, string clientName, List<Product> products)
        {
            Id = id;
            ClientDoc = clientDoc;
            ClientName = clientName;            
            Products = products.Select(c => c.ProductName).ToList();
        }

        public int Id { get; set; }        
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
        public List<string> Products { get; private set; }


        public static OrderViewModel FromEntityOrder(Order entity)
            => new OrderViewModel(entity.Id, entity.ClientDoc, entity.ClientName,  entity.Products);
    }
}
