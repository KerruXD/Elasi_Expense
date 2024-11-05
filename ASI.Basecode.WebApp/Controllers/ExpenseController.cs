using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            this._expenseService = expenseService;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate, string category)
        {
            var expenses = _expenseService.GetExpenses();

            // Apply date range filter if provided
            if (startDate.HasValue)
            {
                expenses = expenses.Where(e => e.Date >= startDate.Value).ToList();
            }
            if (endDate.HasValue)
            {
                expenses = expenses.Where(e => e.Date <= endDate.Value).ToList();
            }

            // Apply category filter if provided
            if (!string.IsNullOrEmpty(category))
            {
                expenses = expenses.Where(e => e.Category == category).ToList();
            }

            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            _expenseService.AddExpense(expense);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var expense = _expenseService.GetExpenses().FirstOrDefault(b => b.ID == id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseService.UpdateExpense(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult Delete(string id)
        {
            var expense = _expenseService.GetExpenses().FirstOrDefault(b => b.ID == id);
            if (expense != null)
            {
                _expenseService.DeleteExpense(expense);
            }
            return RedirectToAction("Index");
        }
    }
}
