using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationAPI.Models;

namespace AuthorizationAPI.Helper
{
    public class HelperClass
    {
        public static List<UserModel> userlist = new List<UserModel>()
        {
            new UserModel{ userid=1,password="123",username="Bharath"},
            new UserModel{ userid=2,password="123",username="Anupama"},
            new UserModel{ userid=3,password="123",username="Renuka"},
            new UserModel{ userid=4,password="123",username="Nancy"},
            new UserModel{ userid=5,password="123",username="Pranay"}
        };
    }
}
