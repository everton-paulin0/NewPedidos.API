using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Command.DeleteProduct
{
    public class DelectProductCommand : IRequest<ResultViewModel>
    {
        public DelectProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
