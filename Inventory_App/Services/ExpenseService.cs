using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_App.IServices;
using Inventory_App.Models;

namespace Inventory_App.Services
{
    public class ExpenseService
    {
        private readonly AppsContext _db;
        public ExpenseService()
        {
            _db = new AppsContext();
        }
        public Expense SaveExpenses(Expense expense)
        {
            this._db.Expenses.Add(expense);
            this._db.SaveChanges();
            return expense;
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return this._db.Expenses;
        }
        public Expense GetExpenseByid(int id)
        {
            return this._db.Expenses.Find(id);
        }
        public void UpdateExpense(Expense expense)
        {
            this._db.Entry(expense).State = System.Data.Entity.EntityState.Modified;
            this._db.SaveChanges();
        }
        public void DeleteExpense(int id)
        {
            var expense1 = GetExpenseByid(id);
            this._db.Expenses.Remove(expense1);
            this._db.SaveChanges();
        }
        public IEnumerable<Expense> GetExpensesByName()
        {
            var expense1 = from c in _db.Expenses
                           select c;
            return expense1;
        }
    }
}