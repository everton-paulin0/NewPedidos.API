using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newpedidos.Application.Model
{
    public class LoginInputModel
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        public LoginViewModel(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}
