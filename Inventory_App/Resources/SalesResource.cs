using Inventory_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_App.Resources
{
    public class SalesResource
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public virtual List<SoldProductResource> SoldProductResources { get; set; }
        public string CreatedBy { get; set; }

    }

    public class SoldProductResource
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;

        public int ProductID { get; set; }
        public int stock { get; set; }
    }
}