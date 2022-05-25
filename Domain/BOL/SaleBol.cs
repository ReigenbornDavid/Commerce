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
                    //_saleDal.Insert(sale);
                    if (!_saleDal.Insert(sale))
                    {
                        stringBuilder.Append("No se pudo registrar la venta");
                    }
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

        public int GetLastIdSale()
        {
            return _saleDal.GetLastIdSale();
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
