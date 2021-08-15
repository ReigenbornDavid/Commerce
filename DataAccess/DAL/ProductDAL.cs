using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductoDal:ConnectionToSql
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Producto es nuestra 
        //tabla Producto
        public void Insert(Product product)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Product (description, price, quantity, idCategory) VALUES (@description, @price, @quantity, @idCategory)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", product.description);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@quantity", product.quantity);
                    command.Parameters.AddWithValue("@idCategory", product.category.idCategory);
                    command.ExecuteNonQuery();
                }
            }
        }
        /*
        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EProducto> GetAll()
        {
            //Declaramos una lista del objeto EProducto la cual será la encargada de
            //regresar una colección de los elementos que se obtengan de la BD
            //
            //La lista substituye a DataTable utilizado en el proyecto de ejemplo
            List<EProducto> productos = new List<EProducto>();

            using (SqlCeConnection cnx = new SqlCeConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Producto ORDER BY Id ASC";
                using (SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cnx))
                {
                    SqlCeDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProducto producto = new EProducto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDecimal(dataReader["Precio"])
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }

        /// <summary>
        /// Devuelve un Objeto Producto
        /// </summary>
        /// <param name="idProducto">Id del producto a buscar</param>
        /// <returns>Un registro con los valores del Producto</returns>
        /// <autor>José Luis García Bautista</autor>
        public EProducto GetByid(int idProducto)
        {
            using (SqlCeConnection cnx = new SqlCeConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM Producto WHERE Id = @id";
                using (SqlCeCommand cmd = new SqlCeCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    SqlCeDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EProducto producto = new EProducto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDecimal(dataReader["Precio"])
                        };

                        return producto;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Actualiza el Producto correspondiente al Id proporcionado
        /// </summary>
        /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
        /// <autor>José Luis García Bautista</autor>
        public void Update(EProducto producto)
        {
            using (SqlCeConnection cnx = new SqlCeConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE Producto SET Descripcion = @descripcion, Marca = @marca, Precio = @precio WHERE Id = @id";
                using (SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@id", producto.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idproducto">Id del registro a Eliminar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Delete(int idproducto)
        {
            using (SqlCeConnection cnx = new SqlCeConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Producto WHERE Id = @id";
                using (SqlCeCommand cmd = new SqlCeCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idproducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        */
    }
}
