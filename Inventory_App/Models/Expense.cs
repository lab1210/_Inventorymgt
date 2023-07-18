using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Inventory_App.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$", ErrorMessage = "Country Name must start with a capital letter and contain only letters")]
        [Display(Name = "Expense Name")]
        public string Name { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]

        public decimal Amount { get; set; }
        [Required]

        public string description { get; set; }
        public string CreatedBy { get; set; }
    }
}