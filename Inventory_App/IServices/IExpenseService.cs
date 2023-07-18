using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_App.Models;


namespace Inventory_App.IServices
{
    public interface IExpenseService
    {
        Expense SaveExpenses(Expense expense);
        IEnumerable<Expense> GetAllExpenses();
        Expense GetExpenseByid(int id);
        void UpdateExpense(Expense expense);
        void DeleteExpense(int id);
        IEnumerable<Expense> GetExpensesByName();
    }
}
