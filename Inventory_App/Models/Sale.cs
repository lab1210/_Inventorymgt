using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_App.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public virtual List<SoldProducts> SoldProducts { get; set; }
        public string CreatedBy { get; set; }

    }
    public class SoldProducts
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        [Range(0,double.PositiveInfinity)]
        public int Quantity { get; set; } = 0;
        public int ProductID { get; set; }
        public int stock { get; set; }

    }


}