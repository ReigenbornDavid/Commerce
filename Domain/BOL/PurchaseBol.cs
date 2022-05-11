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
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public int lastPurchase;

        public int Registrate(Purchase purchase)
        {
            if (ValidatePurchase(purchase))
            {
                if (_purchaseDal.GetByid(purchase.IdPurchase) == null)
                {
                    _purchaseDal.Insert(purchase);
                    lastPurchase = _purchaseDal.GetLastId();
                    foreach (var item in purchase.DetailPurchases)
                    {
                        item.Purchase = new Purchase();
                        item.Purchase.IdPurchase = lastPurchase;
                        _detailPurchaseDal.Insert(item);
                        item.Product.Quantity = item.Product.Quantity + item.Quantity;
                        _productDal.Update(item.Product);
                    }
                    return lastPurchase;
                }
                else
                    _purchaseDal.Update(purchase);
            
                return 0;
            }
            return 0;
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

        private bool ValidatePurchase(Purchase purchase)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(purchase.Employee.IdEmployee.ToString())) stringBuilder.Append("El campo empleado es obligatorio");
            if (string.IsNullOrEmpty(purchase.Date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            if (string.IsNullOrEmpty(purchase.Supplier.Name)) stringBuilder.Append(Environment.NewLine + "El campo proveedor es obligatorio");
            //if (string.IsNullOrEmpty(sale.detailSales.Count.ToString())) stringBuilder.Append(Environment.NewLine + "El campo detalle es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
