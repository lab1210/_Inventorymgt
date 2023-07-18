using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Web;

namespace Inventory_App.Models
{
    public class City
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$", ErrorMessage = "City Name must start with a capital letter and contain only letters")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
        public string CreatedBy { get; set; }

        public bool status { get; set; }
    }
}