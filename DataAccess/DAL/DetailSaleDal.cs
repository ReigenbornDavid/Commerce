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
                    command.Parameters.AddWithValue("@idSale", detailSale.sale.idSale);
                    command.Parameters.AddWithValue("@price", detailSale.price);
                    command.Parameters.AddWithValue("@quantity", detailSale.quantity);
                    command.Parameters.AddWithValue("@idProduct", detailSale.product.idProduct);
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
                            idDetailSale = Convert.ToInt32(dataReader["idDetailSale"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            sale = new SaleDal().GetByid(Convert.ToInt32(dataReader["idSale"])),
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
                            idDetailSale = Convert.ToInt32(dataReader["idDetailSale"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            sale = new SaleDal().GetByid(Convert.ToInt32(dataReader["idSale"])),
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
                            idDetailSale = Convert.ToInt32(dataReader["idDetailSale"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            sale = new SaleDal().GetByid(Convert.ToInt32(dataReader["idSale"])),
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
                    command.Parameters.AddWithValue("@idDetailSale", detailSale.idDetailSale);
                    command.Parameters.AddWithValue("@idSale", detailSale.sale.idSale);
                    command.Parameters.AddWithValue("@price", detailSale.price);
                    command.Parameters.AddWithValue("@quantity", detailSale.quantity);
                    command.Parameters.AddWithValue("@idProduct", detailSale.product.idProduct);
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
