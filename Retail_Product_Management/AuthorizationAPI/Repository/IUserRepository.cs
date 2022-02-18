using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.Models;

namespace AuthorizationAPI.Repository
{
    public interface IUserRepository
    {
        public bool isUniqueUser(string username);
        public UserModel Authenticate(string username, string password);
        public UserModel UserDetails(string username);


        Register RegisterDetails(string userid, string username, string Email, string password, string address);
    }
}
