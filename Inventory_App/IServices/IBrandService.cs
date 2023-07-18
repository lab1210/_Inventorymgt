using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Models;


namespace Inventory_App.IServices
{
    public interface IBrandService
    {
        Brand SaveBrand(Brand brand);
        IEnumerable<Brand> GetAllBrands();
        Brand GetBrandByID(int id);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int id);
        IEnumerable<Brand> GetBrandByName();
    }
}
