using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class BrandBol
    {
        //Instances
        private BrandDal _brandDal = new BrandDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Registrate(Brand brand)
        {
            if (ValidateBrand(brand))
            {
                if (_brandDal.GetByid(brand.IdBrand) == null)
                {
                    _brandDal.Insert(brand);
                }
                else
                    _brandDal.Update(brand);

            }
        }

        public List<Brand> All()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetAllByName(string name)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(name)) stringBuilder.Append("Por favor proporcione un valor de Nombre valido");

            if (stringBuilder.Length == 0)
            {
                return _brandDal.GetAllByName(name);
            }
            return null;
        }

        public Brand GetByName(string name)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(name)) stringBuilder.Append("Por favor proporcione un valor de Nombre valido");

            if (stringBuilder.Length == 0)
            {
                return _brandDal.GetByName(name);
            }
            return null;
        }

        public Brand GetById(int idBrand)
        {
            stringBuilder.Clear();

            if (idBrand == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _brandDal.GetByid(idBrand);
            }
            return null;
        }

        public void Delete(int idBrand)
        {
            stringBuilder.Clear();

            if (idBrand == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _brandDal.Delete(idBrand);
            }
        }

        private bool ValidateBrand(Brand brand)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(brand.Name)) stringBuilder.Append("El campo Descripción es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
