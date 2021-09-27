using Common.Models.BuyCarts;
using Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Token
{
    public class AccessToken
    {
        public User User { get; set; }
        public string Token { get; set; }
        public BuyCart Cart { get; set; }
    }
}
