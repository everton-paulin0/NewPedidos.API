using System.ComponentModel.DataAnnotations;
using NewPedidos.Core.Entities;
using NewPedidos.Core.Enum;


namespace Newpedidos.Application.Model
{
    public class CreateUserInputModel
    {
        [Required]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserLevel { get; set; }
        public string Password { get; set; }

        public User ToEntityUser()
            => new User(UserName, UserEmail, UserLevel, Password);

    }

}
