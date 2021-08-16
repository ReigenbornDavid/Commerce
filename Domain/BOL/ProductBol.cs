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
        public void Registrar(Product product)
        {
            if (ValidarProducto(product))
            {
                if (_productDal.GetByid(product.idProduct) == null)
                {
                    _productDal.Insert(product);
                }
                else
                    _productDal.Update(product);

            }
        }

        public List<EProducto> Todos()
        {
            return _productoDal.GetAll();
        }

        public EProducto TraerPorId(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _productoDal.GetByid(idProduct);
            }
            return null;
        }

        public void Eliminar(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _productoDal.Delete(idProduct);
            }
        }

        private bool ValidarProducto(EProducto producto)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(producto.Descripcion)) stringBuilder.Append("El campo Descripción es obligatorio");
            if (string.IsNullOrEmpty(producto.Marca)) stringBuilder.Append(Environment.NewLine + "El campo Marca es obligatorio");
            if (producto.Precio <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
