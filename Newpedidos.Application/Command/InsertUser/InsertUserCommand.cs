using MediatR;
using Newpedidos.Application.Model;
using NewPedidos.Core.Entities;
using NewPedidos.Core.Enum;

namespace Newpedidos.Application.Command.InsertUser
{
    public class InsertUserCommand : IRequest<ResultViewModel<int>>
    {
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public Level UserLevel { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

        public User ToEntityUser()
            => new User(Username, UserEmail, Password);
    }
}
