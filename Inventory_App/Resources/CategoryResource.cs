using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_App.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string CreatedBy { get; set; }

    }
}