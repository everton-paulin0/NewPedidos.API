using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Command.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Level UserLevel { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
    }
}
