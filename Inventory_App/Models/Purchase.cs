using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Inventory_App.Models
{
    public class Purchase
    {

        public int Id { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        public decimal Total { get; set; }
        
        public List<PurchaseProduct> PurchaseProducts { get; set; }
        public string CreatedBy { get; set; }


    }
    public class PurchaseProduct
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        public bool Selected { get; set; } = false;
        
        public Product Product { get; set; }

    }
}
