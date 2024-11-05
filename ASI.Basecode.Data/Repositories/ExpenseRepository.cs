using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        List<Expense> _allExpense = new List<Expense>();

        public List<Expense> ViewExpenses()
        {
            return _allExpense;
        }
        public void AddExpense(Expense expense)
        {
            _allExpense.Add(expense);
        }
        public void UpdateExpense(Expense expense)
        {
            var existingExpense = _allExpense.FirstOrDefault(b => b.ID == expense.ID);
            if (existingExpense != null)
            {
                existingExpense.Title = expense.Title;
                existingExpense.Amount = expense.Amount;
                existingExpense.Date = expense.Date;
                existingExpense.Category = expense.Category;
                existingExpense.Description = expense.Description;
            }
        }
        public void DeleteExpense(Expense expense)
        {

            _allExpense.Remove(expense);
        }


    }
}
