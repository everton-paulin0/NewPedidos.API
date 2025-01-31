using MediatR;
using Newpedidos.Application.Command.InsertOrder;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;


namespace Newpedidos.Application.Command.InsertProduct
{
    public class ValidateInsertProductCommandBevahior : IPipelineBehavior<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        public ValidateInsertProductCommandBevahior(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var quantities = _context.Product.Any(o => o.Quantity > 0);

            if (!quantities)
            {
                return ResultViewModel<int>.Error("A quantidade de Produto não pode estar zerado");
            }
            return await next();
        }
    }
}
