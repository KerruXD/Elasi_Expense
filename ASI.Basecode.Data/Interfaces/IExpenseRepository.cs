using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IExpenseRepository
    {
        List<Expense> ViewExpenses();

        void AddExpense(Expense expense);

        void UpdateExpense(Expense expense);

        void DeleteExpense(Expense expense);
    }
}
