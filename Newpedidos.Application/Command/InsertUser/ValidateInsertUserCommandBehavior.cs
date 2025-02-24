using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Command.InsertOrder;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.InsertUser
{
    public class ValidateInsertUserCommandBehavior : IPipelineBehavior<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        public ValidateInsertUserCommandBehavior(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResultViewModel<int>> Handle(InsertUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
