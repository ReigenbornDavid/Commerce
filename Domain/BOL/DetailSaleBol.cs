using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class DetailSaleBol
    {
        //Instances
        private DetailSaleDal _detailSaleDal = new DetailSaleDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Registrate(DetailSale detailSale)
        {
            if (ValidateDetailSale(detailSale))
            {
                if (_detailSaleDal.GetByid(detailSale.idDetailSale) == null)
                {
                    _detailSaleDal.Insert(detailSale);
                }
                else
                    _detailSaleDal.Update(detailSale);

            }
        }

        public List<DetailSale> All()
        {
            return _detailSaleDal.GetAll();
        }

        public List<DetailSale> GetBySale(int idSale)
        {
            return _detailSaleDal.GetBySale(idSale);
        }

        public DetailSale GetById(int idDetailSale)
        {
            stringBuilder.Clear();

            if (idDetailSale == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _detailSaleDal.GetByid(idDetailSale);
            }
            return null;
        }

        public void Delete(int idDetailSale)
        {
            stringBuilder.Clear();

            if (idDetailSale == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _detailSaleDal.Delete(idDetailSale);
            }
        }

        private bool ValidateDetailSale(DetailSale detailSale)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(detailSale.price.ToString())) stringBuilder.Append("El campo precio es obligatorio");
            if (string.IsNullOrEmpty(detailSale.quantity.ToString())) stringBuilder.Append(Environment.NewLine + "El campo cantidad es obligatorio");
            if (string.IsNullOrEmpty(detailSale.product.idProduct.ToString())) stringBuilder.Append(Environment.NewLine + "El campo IdProducto es obligatorio");
            if (string.IsNullOrEmpty(detailSale.sale.idSale.ToString())) stringBuilder.Append(Environment.NewLine + "El campo IdSale es obligatorio");
            return stringBuilder.Length == 0;
        }
    }

}
