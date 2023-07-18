using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Web;

namespace Inventory_App.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$", ErrorMessage = "Name must start with a capital letter and contain only letters")]
        [Display(Name = "Customer Name")]
        public string name { get; set; }
       
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "must contain only digits")]
        [Required]

        public string Phone { get; set; }
        public string CreatedBy { get; set; }


    }
    public class CustomerMemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
