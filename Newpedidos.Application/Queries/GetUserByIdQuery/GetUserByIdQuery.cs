using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Queries.GetUserByQuery
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly AppDbContext _context;
        public GetUserByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                   .Where(o => !o.IsDeleted)
                   .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não existe");
            }

            var model = UserViewModel.FromEntityUser(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
