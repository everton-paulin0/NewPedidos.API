using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class OrderViewModel
    {
        public OrderViewModel(int id, string clientName, string clientDoc, int idProduct)
        {
            Id = id;
            ClientName = clientName;
            ClientDoc = clientDoc;
            IdProduct = idProduct;

        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientDoc { get; set; }
        public int IdProduct { get; set; }

        public static OrderViewModel FromEntityOrder(Order entity)
            => new OrderViewModel(entity.Id, entity.ClientName, entity.ClientDoc, entity.IdProduct);
    }
}
