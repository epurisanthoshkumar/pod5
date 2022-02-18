using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationAPI.Models
{
    public class Register
    {
        internal string address;

        // string userid, string username, string Email, string password)
        public string userid { get; set; }

        public string username { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

    }
}
