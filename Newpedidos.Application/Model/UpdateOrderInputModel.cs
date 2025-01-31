using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newpedidos.Application.Model
{
    public class UpdateOrderInputModel
    {
        public int IdOrder { get; set; }
        public string ClientDoc { get; set; }
        public string ClientName { get; set; }
    }
}
