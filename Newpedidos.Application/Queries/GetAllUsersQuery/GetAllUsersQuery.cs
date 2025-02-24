using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newpedidos.Application.Model;

namespace Newpedidos.Application.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<ResultViewModel<List<UserItemViewModel>>>
    {
        public GetAllUsersQuery()
        {
           
        }
    }
}
