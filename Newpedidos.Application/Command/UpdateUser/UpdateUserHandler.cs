using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Command.UpdateProduct;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly AppDbContext _context;
        public UpdateUserHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(p => p.Id == request.UserId);

            if (user is null)
            {
                return ResultViewModel<OrderViewModel>.Error("usuário não existe");
            }

            user.UpdateUser(request.UserName, request.UserEmail,request.Password);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
