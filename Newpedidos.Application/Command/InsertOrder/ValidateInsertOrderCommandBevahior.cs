using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.InsertOrder
{
    public class ValidateInsertOrderCommandBevahior : IPipelineBehavior<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        public ValidateInsertOrderCommandBevahior(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var clientName = _context.Order.Any(o => o.ClientName != "");

            if (!clientName)
            {
                return ResultViewModel<int>.Error("O Nome do Cliente deve ser preenchido");
            }
            return await next();
        }
    }
}
