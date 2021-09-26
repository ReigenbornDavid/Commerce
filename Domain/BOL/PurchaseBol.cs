using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class PurchaseBol
    {
        //Instances
        private PurchaseDal _purchaseDal = new PurchaseDal();
        private DetailPurchaseDal _detailPurchaseDal = new DetailPurchaseDal();
        private ProductDal _productDal = new ProductDal();
        private ExpenseDal _expenseDal = new ExpenseDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public int lastPurchase;

        public void Registrate(Purchase purchase)
        {
            if (ValidateSale(purchase))
            {
                if (_purchaseDal.GetByid(purchase.idPurchase) == null)
                {
                    _purchaseDal.Insert(purchase);
                    lastPurchase = _purchaseDal.GetLastId();
                    Expense expense = new Expense();
                    expense.description = "Compra";
                    expense.purchase = new Purchase();
                    expense.purchase.idPurchase = lastPurchase;
                    expense.date = purchase.date;
                    expense.price = 0;
                    foreach (var item in purchase.detailPurchases)
                    {
                        item.purchase = new Purchase();
                        item.purchase.idPurchase = lastPurchase;
                        _detailPurchaseDal.Insert(item);
                        item.product.quantity = item.product.quantity + item.quantity;
                        _productDal.Update(item.product);
                        expense.price += item.price * item.quantity;
                    }
                    _expenseDal.Insert(expense);
                }
                else
                    _purchaseDal.Update(purchase);

            }
        }

        public List<Purchase> All()
        {
            return _purchaseDal.GetAll();
        }

        public int GetLastId()
        {
            return _purchaseDal.GetLastId();
        }

        public Purchase GetById(int idPurchase)
        {
            stringBuilder.Clear();

            if (idPurchase == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _purchaseDal.GetByid(idPurchase);
            }
            return null;
        }

        public void Delete(int idPurchase)
        {
            stringBuilder.Clear();

            if (idPurchase == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _purchaseDal.Delete(idPurchase);
            }
        }

        private bool ValidateSale(Purchase purchase)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(purchase.employee.idEmployee.ToString())) stringBuilder.Append("El campo empleado es obligatorio");
            if (string.IsNullOrEmpty(purchase.date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            //if (string.IsNullOrEmpty(sale.detailSales.Count.ToString())) stringBuilder.Append(Environment.NewLine + "El campo detalle es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
