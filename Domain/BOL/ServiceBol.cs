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

        public int Registrate(Service service)
        {
            if (ValidateService(service))
            {
                if (_serviceDal.GetByid(service.IdService) == null)
                {
                    _serviceDal.Insert(service);
                    lastService = _serviceDal.GetLastId();
                    return lastService;
                }
                else
                    _serviceDal.Update(service);
                return 0;
            }
            return 0;
        }

        public List<Service> GetByName(string description, string filter)
        {
            string query = "SELECT * FROM Service s WHERE s.description like @Description";
            if (filter != "TODOS")
            {
                query += " AND s.state = @Filter;";
            }
            return _serviceDal.GetByName(description, query, filter);
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

            if (string.IsNullOrEmpty(service.Client)) stringBuilder.Append("El campo cliente es obligatorio");
            if (string.IsNullOrEmpty(service.Tel)) stringBuilder.Append(Environment.NewLine + "El campo empleado es obligatorio");
            if (string.IsNullOrEmpty(service.Date.ToString())) stringBuilder.Append(Environment.NewLine + "El campo fecha es obligatorio");
            if (string.IsNullOrEmpty(service.Description)) stringBuilder.Append(Environment.NewLine + "El campo descripcion es obligatorio");
            if (string.IsNullOrEmpty(service.Price.ToString())) stringBuilder.Append(Environment.NewLine + "El campo precio es obligatorio");
            if (string.IsNullOrEmpty(service.State)) stringBuilder.Append(Environment.NewLine + "El campo estado es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
