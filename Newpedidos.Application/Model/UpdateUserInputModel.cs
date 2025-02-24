using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Model
{
    public class UpdateUserInputModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public Level UserLevel { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}
