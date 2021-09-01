using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class ProductBol
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private ProductDal _productDal = new ProductDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrate(Product product)
        {
            if (ValidateProduct(product))
            {
                if (_productDal.GetByid(product.idProduct) == null)
                {
                    _productDal.Insert(product);
                }
                else
                    _productDal.Update(product);

            }
        }

        public List<Product> GetProducts()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetByName(string description)
        {
            return _productDal.GetByName(description);
        }

        public Product GetById(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _productDal.GetByid(idProduct);
            }
            return null;
        }

        public void Delete(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _productDal.Delete(idProduct);
            }
        }

        private bool ValidateProduct(Product product)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(product.description)) stringBuilder.Append("El campo Descripción es obligatorio");
            if (string.IsNullOrEmpty(product.category.name)) stringBuilder.Append(Environment.NewLine + "El campo Categoria es obligatorio");
            if (product.price <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");
            if (product.quantity <= 0) stringBuilder.Append(Environment.NewLine + "El campo Cantidad es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
