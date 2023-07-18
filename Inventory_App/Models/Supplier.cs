using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inventory_App.Models
{
    public class Supplier
    {

        public int id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$", ErrorMessage = "Name must start with a capital letter and contain only letters")]
        [Display(Name = "Supplier Name")]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "must contain only digits")]

        public string phone { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }
        public string CreatedBy { get; set; }

    }

    public class SupplierMemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
