using MediatR;
using Newpedidos.Application.Model;
using Newpedidos.Application.Notification.UserCreated;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Command.InsertUser
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public InsertUserHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntityUser();

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var userCreatead = new UserCreatedNotification(user.Id, user.UserName,user.UserEmail, user.UserLevel, user.Password);

            await _mediator.Publish(userCreatead);

            return ResultViewModel<int>.Sucess(user.Id);
        }
    }
}

