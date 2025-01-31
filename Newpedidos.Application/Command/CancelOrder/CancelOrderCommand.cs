using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.CancelOrder
{
    public class CancelOrderCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public CancelOrderCommand(int id)
        {
            Id = id;
        }
    }
}
