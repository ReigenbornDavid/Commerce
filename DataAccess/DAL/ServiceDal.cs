using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ServiceDal:ConnectionToSql
    {
        public void Insert(Service service)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Service (description, price, date, dniClient, dniEmployee, idSale) " +
                    "VALUES (@description, @price, @date, @dniClient, @dniEmployee, @idSale)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", service.description);
                    command.Parameters.AddWithValue("@price", service.price);
                    command.Parameters.AddWithValue("@date", service.date);
                    command.Parameters.AddWithValue("@dniClient", service.client.idClient);
                    command.Parameters.AddWithValue("@dniEmployee", service.employee.idEmployee);
                    command.Parameters.AddWithValue("@idSale", service.sale.idSale);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "SELECT * FROM Product p ORDER BY idProduct ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            idProduct = Convert.ToInt32(dataReader["idProduct"]),
                            description = Convert.ToString(dataReader["description"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"]))
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetByName(string description)
        {
            List<Product> products = new List<Product>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById =
                "SELECT * FROM Product WHERE description like @Description";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@Description", "%" + description + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            idProduct = Convert.ToInt32(dataReader["idProduct"]),
                            description = Convert.ToString(dataReader["description"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"]))
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public Product GetByid(int idProduct)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Product WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idProduct", idProduct);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            idProduct = Convert.ToInt32(dataReader["idProduct"]),
                            description = Convert.ToString(dataReader["description"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"]))
                        };
                        return product;
                    }
                }
            }
            return null;
        }

        public void Update(Service service)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Service SET description = @description, date = @date, dniClient = @dniClient, " +
                    "dniEmployee = @dniEmployee, idSale = @idSale WHERE idService = @idService";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idService", service.idService);
                    command.Parameters.AddWithValue("@description", service.description);
                    command.Parameters.AddWithValue("@price", service.price);
                    command.Parameters.AddWithValue("@date", service.date);
                    command.Parameters.AddWithValue("@dniClient", service.client.idClient);
                    command.Parameters.AddWithValue("@dniEmployee", service.employee.idEmployee);
                    command.Parameters.AddWithValue("@idSale", service.sale.idSale);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idProduct)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Product WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idProduct", idProduct);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
