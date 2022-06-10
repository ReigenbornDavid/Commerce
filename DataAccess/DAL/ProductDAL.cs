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
                    "INSERT INTO product (code, description, cost, price, quantity, " +
                    "idCategory, idSupplier, idBrand, usd) " +
                    "VALUES (@code, @description, @cost, @price, @quantity, @idCategory, " +
                    "@idSupplier, @idBrand, @usd)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@code", product.Code);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@cost", product.Code);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@idCategory", product.Category.IdCategory);
                    command.Parameters.AddWithValue("@idSupplier", product.Supplier.IdSupplier);
                    command.Parameters.AddWithValue("@idBrand", product.Brand.IdBrand);
                    command.Parameters.AddWithValue("@usd", product.Usd);
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
                    "SELECT * FROM product p ORDER BY p.description ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            IdProduct = Convert.ToInt32(dataReader["idProduct"]),
                            Code = Convert.ToString(dataReader["code"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Cost = Convert.ToDouble(dataReader["cost"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"])),
                            Supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"])),
                            Brand = new BrandDal().GetByid(Convert.ToInt32(dataReader["idBrand"])),
                            Usd = Convert.ToBoolean(dataReader["usd"])
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetByP(string query, Category category, Brand brand, Supplier supplier)
        {
            List<Product> products = new List<Product>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                string sqlGetById = query;
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    if (category != null)
                    {
                        command.Parameters.AddWithValue("@idCategory", category.IdCategory);
                    }
                    if (brand != null)
                    {
                        command.Parameters.AddWithValue("@idBrand", brand.IdBrand);
                    }
                    if (supplier != null)
                    {
                        command.Parameters.AddWithValue("@idSupplier", supplier.IdSupplier);
                    }
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            IdProduct = Convert.ToInt32(dataReader["idProduct"]),
                            //code = Convert.ToString(dataReader["code"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Cost = Convert.ToDouble(dataReader["cost"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Category = new Category(),
                            Supplier = new Supplier(),
                            Brand = new Brand(),
                            Usd = Convert.ToBoolean(dataReader["usd"])
                        };
                        product.Category.Name = Convert.ToString(dataReader["category"]);
                        product.Supplier.Name = Convert.ToString(dataReader["supplier"]);
                        product.Brand.Name = Convert.ToString(dataReader["brand"]);
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetByName(string description, string query, string categoryFilter, string supplierFilter, string brandFilter)
        {
            List<Product> products = new List<Product>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", "%"+ description + "%");
                    command.Parameters.AddWithValue("@CategoryFilter", categoryFilter);
                    command.Parameters.AddWithValue("@BrandFilter", brandFilter);
                    command.Parameters.AddWithValue("@SupplierFilter", supplierFilter);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            IdProduct = Convert.ToInt32(dataReader["idProduct"]),
                            //code = Convert.ToString(dataReader["code"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Cost = Convert.ToDouble(dataReader["cost"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Category = new Category(),
                            Supplier = new Supplier(),
                            Brand = new Brand(),
                            Usd = Convert.ToBoolean(dataReader["usd"])
                        };
                        product.Category.Name = Convert.ToString(dataReader["category"]);
                        product.Supplier.Name = Convert.ToString(dataReader["supplier"]);
                        product.Brand.Name = Convert.ToString(dataReader["brand"]);
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
                const string sqlGetById = "SELECT * FROM product WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idProduct", idProduct);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Product product = new Product
                        {
                            IdProduct = Convert.ToInt32(dataReader["idProduct"]),
                            Code = Convert.ToString(dataReader["code"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Cost = Convert.ToDouble(dataReader["cost"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Category = new CategoryDal().GetByid(Convert.ToInt32(dataReader["idCategory"])),
                            Supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"])),
                            Brand = new BrandDal().GetByid(Convert.ToInt32(dataReader["idBrand"])),
                            Usd = Convert.ToBoolean(dataReader["usd"])
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
                    "UPDATE product SET code = @code, description = @description, cost = @cost, " +
                    "price = @price, quantity = @quantity, idCategory = @idCategory, " +
                    "idSupplier = @idSupplier, idBrand = @idBrand, usd = @usd " +
                    "WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@code", product.Code);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@cost", product.Cost);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@idCategory", product.Category.IdCategory);
                    command.Parameters.AddWithValue("@idSupplier", product.Supplier.IdSupplier);
                    command.Parameters.AddWithValue("@idBrand", product.Brand.IdBrand);
                    command.Parameters.AddWithValue("@usd", product.Usd);
                    command.Parameters.AddWithValue("@idProduct", product.IdProduct);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idProduct)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM product WHERE idProduct = @idProduct";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idProduct", idProduct);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

