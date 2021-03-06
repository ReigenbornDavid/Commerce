using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class CategoryBol
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private CategoryDal _categoryDal = new CategoryDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrate(Category category)
        {
            if (ValidateCategory(category))
            {
                if (_categoryDal.GetByid(category.idCategory) == null)
                {
                    _categoryDal.Insert(category);
                }
                else
                    _categoryDal.Update(category);

            }
        }

        public List<Category> All()
        {
            return _categoryDal.GetAll();
        }

        public Category GetByName(string name)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(name)) stringBuilder.Append("Por favor proporcione un valor de Nombre valido");

            if (stringBuilder.Length == 0)
            {
                return _categoryDal.GetByName(name);
            }
            return null;
        }

        public Category GetById(int idCategory)
        {
            stringBuilder.Clear();

            if (idCategory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _categoryDal.GetByid(idCategory);
            }
            return null;
        }

        public void Delete(int idCategory)
        {
            stringBuilder.Clear();

            if (idCategory == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _categoryDal.Delete(idCategory);
            }
        }

        private bool ValidateCategory(Category category)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(category.name)) stringBuilder.Append("El campo Descripción es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
