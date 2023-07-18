using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_App.Models
{
    public class Register
    {
        public int ID { get; set; }
        [Required]

        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "must contain only digits")]

        public string Phone { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}