using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Models;


namespace Inventory_App.IServices
{
    public interface IPeopleService
    {
        Customer SaveCustomer(Customer customer);
        IEnumerable<Customer> GetCustomerList();
        Customer GetCustomerByID(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        Supplier SaveSupplier(Supplier supplier);
        IEnumerable<Supplier> GetSuppliername();
        Supplier GetSupplierByID(int id);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
        IEnumerable<Customer> GetCustomerByName();
        IEnumerable<Supplier> GetSupplierByName();
    }
}
