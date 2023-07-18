using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_App.Models
{
    public class Login
    {
        public int ID { get; set; }
       
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public DateTime LoggedInDate { get; set; } = DateTime.Now;
    }
    public class LoginMemo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }



    }
}