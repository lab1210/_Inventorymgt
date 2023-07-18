using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Inventory_App.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$", ErrorMessage = "Country Name must start with a capital letter and contain only letters")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }

    }
}