using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class ServiceBol
    {
        //Instances
        private ServiceDal _serviceDal = new ServiceDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public int lastService;

        public void Registrate(Service service)
        {
            if (ValidateService(service))
            {
                if (_serviceDal.GetByid(service.idService) == null)
                {
                    _serviceDal.Insert(service);
                }
                else
                    _serviceDal.Update(service);

            }
        }

        public List<Service> All()
        {
            return _serviceDal.GetAll();
        }

        public Service GetById(int idService)
        {
            stringBuilder.Clear();

            if (idService == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _serviceDal.GetByid(idService);
            }
            return null;
        }

        public void Delete(int idService)
        {
            stringBuilder.Clear();

            if (idService == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _serviceDal.Delete(idService);
            }
        }

        private bool ValidateService(Service service)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(service.client.idClient.ToString())) stringBuilder.Append("El campo cliente es obligatorio");
            if (string.IsNullOrEmpty(service.employee.idEmployee.ToString())) stringBuilder.Append(Environment.NewLine + "El campo empleado es obligatorio");
            if (string.IsNullOrEmpty(service.date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            if (string.IsNullOrEmpty(service.description.ToString())) stringBuilder.Append(Environment.NewLine + "El campo descripcion es obligatorio");
            if (string.IsNullOrEmpty(service.price.ToString())) stringBuilder.Append(Environment.NewLine + "El campo precio es obligatorio");
            //if (string.IsNullOrEmpty(sale.detailSales.Count.ToString())) stringBuilder.Append(Environment.NewLine + "El campo detalle es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
