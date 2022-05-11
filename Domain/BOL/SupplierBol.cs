using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class SupplierBol
    {
        //Instances
        private SupplierDal _supplierDal = new SupplierDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Registrate(Supplier supplier)
        {
            if (ValidateSupplier(supplier))
            {
                if (_supplierDal.GetByid(supplier.IdSupplier) == null)
                {
                    _supplierDal.Insert(supplier);
                }
                else
                    _supplierDal.Update(supplier);

            }
        }

        public List<Supplier> GetAllByName(string name)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(name)) stringBuilder.Append("Por favor proporcione un valor de Nombre valido");

            if (stringBuilder.Length == 0)
            {
                return _supplierDal.GetAllByName(name);
            }
            return null;
        }

        public List<Supplier> All()
        {
            return _supplierDal.GetAll();
        }

        public Supplier GetByName(string name)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(name)) stringBuilder.Append("Por favor proporcione un valor de Nombre valido");

            if (stringBuilder.Length == 0)
            {
                return _supplierDal.GetByName(name);
            }
            return null;
        }

        public Supplier GetById(int idSupplier)
        {
            stringBuilder.Clear();

            if (idSupplier == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _supplierDal.GetByid(idSupplier);
            }
            return null;
        }

        public void Delete(int idSupplier)
        {
            stringBuilder.Clear();

            if (idSupplier == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _supplierDal.Delete(idSupplier);
            }
        }

        private bool ValidateSupplier(Supplier supplier)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(supplier.Name)) stringBuilder.Append("El campo Nombre es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
