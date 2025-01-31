using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class CreateOrderInputModel
    {
        [Required]
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }


        public Order ToEntityOrder()
            => new Order(ClientDoc, ClientName);
    }
}
