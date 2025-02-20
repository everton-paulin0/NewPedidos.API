using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Model
{
    public class UpdateOrderInputModel
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
