using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Models
{
    public class UserModel
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Token { get; internal set; }
    }
}
