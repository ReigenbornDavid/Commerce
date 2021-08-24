using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ProductDal : ConnectionToSql
    {
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

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM Product ORDER BY idProduct ASC";
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

        public void Update(Product product)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Producto SET description = @description, quantity = @quantity, price = @price, idCategory = @idCategory WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", product.description);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@quantity", product.quantity);
                    command.Parameters.AddWithValue("@idCategory", product.category.idCategory);
                    command.Parameters.AddWithValue("@idProduct", product.idProduct);
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

