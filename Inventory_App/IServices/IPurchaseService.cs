using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Resources;
using Inventory_App.Models;

namespace Inventory_App.IServices
{
    public interface IPurchaseService
    {
        bool SavePurchase(PurchaseResources purchase);
        IEnumerable<PurchaseResources> GetAllPurchase();
        void DeletePurchase(int id);
        PurchaseResources GetPurchase(int id);
        PurchaseResources GetProductPurchaseDetails();

        IEnumerable<SupplierMemo> GetSupplier();
        decimal GetTotalPurchases();

    }
}
