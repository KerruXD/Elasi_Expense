using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        //constructor
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            this._expenseRepository = expenseRepository;
        }
        public List<Expense> GetExpenses()
        {
            var expenses = _expenseRepository.ViewExpenses();
            return expenses;
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException();
            }
            var newExpense = new Expense();
            newExpense.ID = System.Guid.NewGuid().ToString();
            newExpense.Title = expense.Title;
            newExpense.Amount = expense.Amount;
            newExpense.Date = expense.Date;
            newExpense.Category = expense.Category;
            newExpense.Description = expense.Description;
            _expenseRepository.AddExpense(newExpense);
        }
        public void UpdateExpense(Expense expense)
        {

            _expenseRepository.UpdateExpense(expense);
        }

        public void DeleteExpense(Expense expense)
        {

            _expenseRepository.DeleteExpense(expense);
        }

    }
}
