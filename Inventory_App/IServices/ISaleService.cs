using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Resources;
using Inventory_App.Models;
namespace Inventory_App.IServices
{
    public interface ISaleService
    {
        bool SaveSales(SalesResource sale);
        IEnumerable<SalesResource> GetAllSales();
        void DeleteSales(int id);
        SalesResource GetSalesByID(int id);
        SalesResource GetProductDetails();
        IEnumerable<CustomerMemo> GetCustomer();
        string GetSalesTotal();
    }
}
