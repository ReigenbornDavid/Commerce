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
                    "INSERT INTO Product (code, description, cost, price, quantity, idCategory, idSupplier) " +
                    "VALUES (@code, @description, @cost, @price, @quantity, @idCategory, @idSupplier)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@code", product.code);
                    command.Parameters.AddWithValue("@description", product.description);
                    command.Parameters.AddWithValue("@cost", product.cost);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@quantity", product.quantity);
                    command.Parameters.AddWithValue("@idCategory", product.category.idCategory);
                    command.Parameters.AddWithValue("@idSupplier", product.supplier.idSupplier);
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
                            code = Convert.ToString(dataReader["code"]),
                            description = Convert.ToString(dataReader["description"]),
                            cost = Convert.ToDecimal(dataReader["cost"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToDecimal(dataReader["quantity"]),
                            category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"])),
                            supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"]))
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
                            code = Convert.ToString(dataReader["code"]),
                            description = Convert.ToString(dataReader["description"]),
                            cost = Convert.ToDecimal(dataReader["cost"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToDecimal(dataReader["quantity"]),
                            category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"])),
                            supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"]))
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
                            code = Convert.ToString(dataReader["code"]),
                            description = Convert.ToString(dataReader["description"]),
                            cost = Convert.ToDecimal(dataReader["cost"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToDecimal(dataReader["quantity"]),
                            category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"])),
                            supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"]))
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
                    "UPDATE Product SET code = @code, description = @description, cost = @cost, price = @price, quantity = @quantity, idCategory = @idCategory, idSupplier = @idSupplier WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@code", product.code);
                    command.Parameters.AddWithValue("@description", product.description);
                    command.Parameters.AddWithValue("@cost", product.cost);
                    command.Parameters.AddWithValue("@price", product.price);
                    command.Parameters.AddWithValue("@quantity", product.quantity);
                    command.Parameters.AddWithValue("@idCategory", product.category.idCategory);
                    command.Parameters.AddWithValue("@idSupplier", product.supplier.idSupplier);
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

