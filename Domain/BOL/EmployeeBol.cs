using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class EmployeeBol
    {
        //Instances
        private EmployeeDal _employeeDal = new EmployeeDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        //Methods

        public void Registrate(Employee employee)
        {
            if (ValidateEmployee(employee))
            {
                if (_employeeDal.GetByid(employee.IdEmployee) == null)
                {
                    _employeeDal.Insert(employee);
                }
                else
                {
                    _employeeDal.Update(employee);
                }
            }
        }

        public List<Employee> GetProducts()
        {
            return _employeeDal.GetAll();
        }

        public List<Employee> GetByName(string name)
        {
            return _employeeDal.GetByName(name);
        }

        public Employee GetById(int idEmployee)
        {
            stringBuilder.Clear();

            if (idEmployee == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _employeeDal.GetByid(idEmployee);
            }
            return null;
        }

        public void Delete(int idEmployee)
        {
            stringBuilder.Clear();

            if (idEmployee == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _employeeDal.Delete(idEmployee);
            }
        }

        private bool ValidateEmployee(Employee employee)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(employee.IdEmployee.ToString())) stringBuilder.Append("El campo Dni es obligatorio");
            if (string.IsNullOrEmpty(employee.FirstName)) stringBuilder.Append(Environment.NewLine + "El campo Apellido es obligatorio");
            if (string.IsNullOrEmpty(employee.LastName)) stringBuilder.Append(Environment.NewLine + "El campo Nombre es obligatorio");
            if (string.IsNullOrEmpty(employee.User)) stringBuilder.Append(Environment.NewLine + "El campo Usuario es obligatorio");
            if (string.IsNullOrEmpty(employee.Pass)) stringBuilder.Append(Environment.NewLine + "El campo Clave es obligatorio");
            if (string.IsNullOrEmpty(employee.Active.ToString())) stringBuilder.Append(Environment.NewLine + "El campo Activo es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
