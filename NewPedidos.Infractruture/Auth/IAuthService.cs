using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPedidos.Core.Enum;

namespace NewPedidos.Infractruture.Auth
{
    public interface IAuthService
    {
        string ComputerHash(string password);

        string GenerateToken(string userEmail, string userLevel);
    }
}
