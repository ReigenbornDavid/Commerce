using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class DetailSaleDal : ConnectionToSql
    {
        public void Insert(DetailSale detailSale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO DetailSale (idSale, price, quantity, idProduct) " +
                    "VALUES (@idSale, @price, @quantity, @idProduct)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSale", detailSale.Sale.IdSale);
                    command.Parameters.AddWithValue("@price", detailSale.Price);
                    command.Parameters.AddWithValue("@quantity", detailSale.Quantity);
                    command.Parameters.AddWithValue("@idProduct", detailSale.Product.IdProduct);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<DetailSale> GetAll()
        {
            List<DetailSale> detailSales = new List<DetailSale>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM DetailSale ORDER BY DetailSale ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DetailSale detailSale = new DetailSale
                        {
                            IdDetailSale = Convert.ToInt32(dataReader["idDetailSale"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            Sale = new SaleDal().GetByid(Convert.ToInt32(dataReader["idSale"])),
                        };
                        detailSales.Add(detailSale);
                    }
                }
            }
            return detailSales;
        }

        public List<DetailSale> GetBySale(int idSale)
        {
            List<DetailSale> detailSales = new List<DetailSale>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM DetailSale WHERE idSale = @idSale";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSale", idSale);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DetailSale detailSale = new DetailSale
                        {
                            IdDetailSale = Convert.ToInt32(dataReader["idDetailSale"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            Sale = new SaleDal().GetByid(Convert.ToInt32(dataReader["idSale"])),
                        };
                        detailSales.Add(detailSale);
                    }
                }
            }
            return detailSales;
        }

        public DetailSale GetByid(int idDetailSale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM DetailSale WHERE idDetailSale = @idDetailSale";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idDetailSale", idDetailSale);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        DetailSale detailSale = new DetailSale
                        {
                            IdDetailSale = Convert.ToInt32(dataReader["idDetailSale"]),
                            Price = Convert.ToDouble(dataReader["price"]),
                            Quantity = Convert.ToDouble(dataReader["quantity"]),
                            Product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            Sale = new SaleDal().GetByid(Convert.ToInt32(dataReader["idSale"])),
                        };
                        return detailSale;
                    }
                }
            }
            return null;
        }

        public void Update(DetailSale detailSale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE DetailSale SET idSale = @idSale, price = @price, quantity = @quantity, idProduct = @idProduct " +
                    "WHERE idDetailSale = @idDetailSale";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idDetailSale", detailSale.IdDetailSale);
                    command.Parameters.AddWithValue("@idSale", detailSale.Sale.IdSale);
                    command.Parameters.AddWithValue("@price", detailSale.Price);
                    command.Parameters.AddWithValue("@quantity", detailSale.Quantity);
                    command.Parameters.AddWithValue("@idProduct", detailSale.Product.IdProduct);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idDetailSale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM DetailSale WHERE idDetailSale = @idDetailSale";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idDetailSale", idDetailSale);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
