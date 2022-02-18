using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercePortal.Models
{
    public class User
    {
        public int UserID { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        public string Token { get; internal set; }
    }
}
