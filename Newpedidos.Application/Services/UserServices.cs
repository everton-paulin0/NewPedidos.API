using Newpedidos.Application.Model;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Infractruture.Persistence;

namespace Newpedidos.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            user.SetAsDeleted();

            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<UserItemViewModel>> GetAll(string search = "")
        {
            var products = _context.Users
            .Where(o => !o.IsDeleted && (search == "" || o.UserName.Contains(search))).ToList();

            var model = products.Select(UserItemViewModel.FromEntityUser).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Sucess(model);
        }
        

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Produto não existe");
            }

            var model = UserViewModel.FromEntityUser(user);

            return ResultViewModel<UserViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = model.ToEntityUser();

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(user.Id);
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == model.UserId);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não existe");
            }
            user.UpdateUser(model.Username, model.UserEmail, model.Password);
            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
