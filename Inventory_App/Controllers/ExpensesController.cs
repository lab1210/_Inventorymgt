using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_App.Services;
using Inventory_App.Models;


namespace Inventory_App.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseService _expenseService;
        public ExpensesController()
        {
            _expenseService = new ExpenseService();
        }
        // GET: Expenses
        public ActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExpense( Expense expense)
        {
            if (ModelState.IsValid)
            {
                var loggedInUserName = HttpContext.Session["LoggedInUserName"] as string;
                expense.CreatedBy = loggedInUserName;
                _expenseService.SaveExpenses(expense);
                return RedirectToAction("ExpenseList");
            }
            return View(expense);
        }
        public ActionResult EditExpense(int id)
        {
            Expense expense = _expenseService.GetExpenseByid(id);

            return View(expense);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseService.UpdateExpense(expense);
                return RedirectToAction("ExpenseList");
            }
            return View(expense);
        }
        public ActionResult ExpenseList(string searchname)
        {
            var expenses = _expenseService.GetExpensesByName();
            if (!String.IsNullOrEmpty(searchname))
            {
                expenses = expenses.Where(c => c.Name.Contains(searchname)).ToList();
            }


            return View(expenses);

        }
        [HttpGet]
        public ActionResult DeleteConfirmedExpense(int ID)
        {
            _expenseService.DeleteExpense(ID);

            return RedirectToAction("ExpenseList");
        }
    }
}