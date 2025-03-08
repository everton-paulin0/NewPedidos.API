using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newpedidos.Application.Model;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Queries.GetAllUsersQuery
{
    public class GetAllUserHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UserItemViewModel>>>
    {
        private readonly AppDbContext _context;
        public GetAllUserHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<UserItemViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
            .Where(o => !o.IsDeleted).ToListAsync();

            var model = users.Select(UserItemViewModel.FromEntityUser).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(model);
        }
    }
}
