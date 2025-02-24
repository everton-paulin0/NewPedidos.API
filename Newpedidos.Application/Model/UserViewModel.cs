
using Newpedidos.Application.Model;
using NewPedidos.Core.Entities;

namespace Newpedidos.Application.Model
{
    public class UserViewModel
    {
        public UserViewModel(int id, string username, string userEmail, string password)
        {
            Id = id;
            Username = username;
            UserEmail = userEmail;
            Password = password;

            OwnedOrder = [];
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public List<Order> OwnedOrder { get; private set; }

        public static UserViewModel FromEntityUser( User user)
            => new(user.Id,user.UserName , user.UserEmail, user.Password);
    }
}
