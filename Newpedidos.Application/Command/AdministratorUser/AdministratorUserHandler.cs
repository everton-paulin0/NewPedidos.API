using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.AdministratorUser
{

    public class AdministratorUserHandler : IRequestHandler<AdministratorUserCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public AdministratorUserHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(AdministratorUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Pedido não existe");
            }
            user.Administrator();

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }    
    }
}
