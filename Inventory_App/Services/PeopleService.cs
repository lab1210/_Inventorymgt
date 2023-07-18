using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_App.IServices;
using Inventory_App.Models;

namespace Inventory_App.Services
{
    public class PeopleService:IPeopleService
    {
        private readonly AppsContext _db;
        public PeopleService()
        {
            _db = new AppsContext();
        }
        public Customer SaveCustomer(Customer customer)
        {
            this._db.Customers.Add(customer);
            this._db.SaveChanges();
            return customer;

        }
        public IEnumerable<Customer> GetCustomerList()
        {
            return this._db.Customers;
        }
        public Customer GetCustomerByID(int id)
        {
            return this._db.Customers.Find(id);
        }
        public void UpdateCustomer(Customer customer)
        {
            this._db.Entry(customer).State = EntityState.Modified;
            this._db.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customer1 = GetCustomerByID(id);
            this._db.Customers.Remove(customer1);
            this._db.SaveChanges();
        }
        public Supplier SaveSupplier(Supplier supplier)
        {
            this._db.Suppliers.Add(supplier);
            this._db.SaveChanges();
            return supplier;
        }
        public IEnumerable<Supplier> GetSuppliername()
        {
            var suppliers = _db.Suppliers.ToList();
            return suppliers;

        }
        public Supplier GetSupplierByID(int id)
        {
            return this._db.Suppliers.Find(id);
        }
        public void UpdateSupplier(Supplier supplier)
        {
            this._db.Entry(supplier).State = EntityState.Modified;
            this._db.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var Supplier1 = GetSupplierByID(id);
            this._db.Suppliers.Remove(Supplier1);
            this._db.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomerByName()
        {
            var customer1 = from c in _db.Customers
                            select c;
            return customer1;
        }
        public IEnumerable<Supplier> GetSupplierByName()
        {
            var Supplier1 = from c in _db.Suppliers
                            select c;
            Supplier1 = Supplier1.Include(c => c.Country);
            return Supplier1;

        }

    }
}