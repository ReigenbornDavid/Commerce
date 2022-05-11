using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class ExpenseBol
    {
        //Instances
        private ExpenseDal _expenseDal = new ExpenseDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public int lastExpense;

        public void Registrate(Expense expense)
        {
            if (ValidateExpense(expense))
            {
                if (_expenseDal.GetByid(expense.IdExpense) == null)
                {
                    _expenseDal.Insert(expense);
                }
                else
                    _expenseDal.Update(expense);

            }
        }

        public List<Expense> All()
        {
            return _expenseDal.GetAll();
        }

        public int GetLastId()
        {
            return _expenseDal.GetLastId();
        }

        public Expense GetById(int idExpense)
        {
            stringBuilder.Clear();

            if (idExpense == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _expenseDal.GetByid(idExpense);
            }
            return null;
        }

        public void Delete(int idExpense)
        {
            stringBuilder.Clear();

            if (idExpense == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _expenseDal.Delete(idExpense);
            }
        }

        private bool ValidateExpense(Expense expense)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(expense.Description)) stringBuilder.Append("El campo descipcion es obligatorio");
            if (string.IsNullOrEmpty(expense.Price.ToString())) stringBuilder.Append(Environment.NewLine + "El campo monto es obligatorio");
            if (string.IsNullOrEmpty(expense.Date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            //if (string.IsNullOrEmpty(sale.detailSales.Count.ToString())) stringBuilder.Append(Environment.NewLine + "El campo detalle es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
