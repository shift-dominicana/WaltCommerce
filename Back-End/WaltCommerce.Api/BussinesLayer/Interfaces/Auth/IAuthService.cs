using Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces.Auth
{
    public interface IAuthService
    {
      string BuildToken(User userName);
    }
}
