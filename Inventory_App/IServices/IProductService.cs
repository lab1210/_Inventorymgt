using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Models;
using Inventory_App.Resources;



namespace Inventory_App.IServices
{
    public interface IProductService
    {
        Product SaveProduct(Product product);
        IEnumerable<ProductResource> GetAllProducts();
        ProductResource GetProductByID(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<ProductResource> GetProductByName();
        IEnumerable<string> GetProductName();
    }
}
