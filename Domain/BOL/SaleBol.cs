﻿using Common.Entities;
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

        public void Registrate(Sale sale)
        {
            if (ValidateSale(sale))
            {
                if (_saleDal.GetByid(sale.idSale) == null)
                {
                    _saleDal.Insert(sale);
                    lastSale = _saleDal.GetLastId();
                    foreach (var item in sale.detailSales)
                    {
                        item.sale = new Sale();
                        item.sale.idSale = lastSale;
                        _detailSaleDal.Insert(item);
                        item.product.quantity = item.product.quantity - item.quantity; 
                        _productDal.Update(item.product);
                    }
                }
                else
                    _saleDal.Update(sale);

            }
        }

        public List<Sale> All()
        {
            return _saleDal.GetAll();
        }

        public int GetLastId()
        {
            return _saleDal.GetLastId();
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

            if (string.IsNullOrEmpty(sale.client.idClient.ToString())) stringBuilder.Append("El campo cliente es obligatorio");
            if (string.IsNullOrEmpty(sale.employee.idEmployee.ToString())) stringBuilder.Append(Environment.NewLine + "El campo empleado es obligatorio");
            if (string.IsNullOrEmpty(sale.date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            //if (string.IsNullOrEmpty(sale.detailSales.Count.ToString())) stringBuilder.Append(Environment.NewLine + "El campo detalle es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}