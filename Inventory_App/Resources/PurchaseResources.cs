using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Inventory_App.Models;


namespace Inventory_App.Resources
{
    public class PurchaseResources
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public List<PurchaseResourceProduct> purchaseResourceProducts { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public string CreatedBy { get; set; }



    }
    public class PurchaseResourceProduct
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        public bool Selected { get; set; } = false;
        

    }

}