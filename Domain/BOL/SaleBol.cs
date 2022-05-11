using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class SaleBol
    {
        //Instances
        private SaleDal _saleDal = new SaleDal();
        private DetailSaleDal _detailSaleDal = new DetailSaleDal();
        private ProductDal _productDal = new ProductDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public int lastSale; 

        public int Registrate(Sale sale)
        {
            if (ValidateSale(sale))
            {
                if (_saleDal.GetByid(sale.IdSale) == null)
                {
                    _saleDal.Insert(sale);
                    lastSale = _saleDal.GetLastId();
                    foreach (var item in sale.DetailSales)
                    {
                        item.Sale = new Sale();
                        item.Sale.IdSale = lastSale;
                        _detailSaleDal.Insert(item);
                        item.Product.Quantity = item.Product.Quantity - item.Quantity; 
                        _productDal.Update(item.Product);
                    }
                    return lastSale;
                }
                else
                    _saleDal.Update(sale);
                return 0;
            }
            return 0;
        }

        public int Registrate2(Sale sale)
        {
            if (ValidateSale(sale))
            {
                if (_saleDal.GetByid(sale.IdSale) == null)
                {
                    _saleDal.Insert2(sale);
                }
                else
                    _saleDal.Update(sale);
                return 0;
            }
            return 0;
        }

        public List<Sale> All()
        {
            return _saleDal.GetAll();
        }

        public int GetLastId()
        {
            return _saleDal.GetLastId();
        }

        public List<DetailSale> GetDetailBySale(int idSale)
        {
            stringBuilder.Clear();

            if (idSale == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _detailSaleDal.GetBySale(idSale);
            }
            return null;
        }

        public Sale GetById(int idSale)
        {
            stringBuilder.Clear();

            if (idSale == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _saleDal.GetByid(idSale);
            }
            return null;
        }

        public void Delete(int idSale)
        {
            stringBuilder.Clear();

            if (idSale == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _saleDal.Delete(idSale);
            }
        }

        private bool ValidateSale(Sale sale)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(sale.Client.IdClient.ToString())) stringBuilder.Append("El campo cliente es obligatorio");
            if (string.IsNullOrEmpty(sale.Employee.IdEmployee.ToString())) stringBuilder.Append(Environment.NewLine + "El campo empleado es obligatorio");
            if (string.IsNullOrEmpty(sale.Date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            //if (string.IsNullOrEmpty(sale.detailSales.Count.ToString())) stringBuilder.Append(Environment.NewLine + "El campo detalle es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
