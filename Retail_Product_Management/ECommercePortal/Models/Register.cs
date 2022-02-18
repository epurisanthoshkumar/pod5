using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ECommercePortal.Models
{
    public class Register
    {
        
         public Guid userid { get; set; }
    
        public string Username { get; set; }
        public string Email { get; set; }
        public string password { get; set; }

        public string address { get; set; }
       
        
    }
}
