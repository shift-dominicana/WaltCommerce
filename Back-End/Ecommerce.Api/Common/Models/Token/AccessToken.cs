using Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Token
{
    public class AccessToken:User
    {
        public string Token { get; set; }
    }
}
