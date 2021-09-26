using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class DetailPurchaseDal:ConnectionToSql
    {
        public void Insert(DetailPurchase detailPurchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO DetailPurchase (idPurchase, price, quantity, idProduct) " +
                    "VALUES (@idPurchase, @price, @quantity, @idProduct)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idPurchase", detailPurchase.purchase.idPurchase);
                    command.Parameters.AddWithValue("@price", detailPurchase.price);
                    command.Parameters.AddWithValue("@quantity", detailPurchase.quantity);
                    command.Parameters.AddWithValue("@idProduct", detailPurchase.product.idProduct);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<DetailPurchase> GetAll()
        {
            List<DetailPurchase> detailPurchases = new List<DetailPurchase>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM DetailPurchase ORDER BY DetailPurchase ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DetailPurchase detailPurchase = new DetailPurchase
                        {
                            idDetailPurchase = Convert.ToInt32(dataReader["idDetailPurchase"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            purchase = new PurchaseDal().GetByid(Convert.ToInt32(dataReader["idPurchase"])),
                        };
                        detailPurchases.Add(detailPurchase);
                    }
                }
            }
            return detailPurchases;
        }

        public List<DetailPurchase> GetByPurchase(int idPurchase)
        {
            List<DetailPurchase> detailPurchases = new List<DetailPurchase>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM DetailPurchase WHERE idPurchase = @idPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idPurchase", idPurchase);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DetailPurchase detailPurchase = new DetailPurchase
                        {
                            idDetailPurchase = Convert.ToInt32(dataReader["idDetailPurchase"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            purchase = new PurchaseDal().GetByid(Convert.ToInt32(dataReader["idPurchase"])),
                        };
                        detailPurchases.Add(detailPurchase);
                    }
                }
            }
            return detailPurchases;
        }

        public DetailPurchase GetByid(int idDetailPurchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM DetailPurchase WHERE idDetailPurchase = @idDetailPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idDetailPurchase", idDetailPurchase);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        DetailPurchase detailPurchase = new DetailPurchase
                        {
                            idDetailPurchase = Convert.ToInt32(dataReader["idDetailPurchase"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            quantity = Convert.ToInt32(dataReader["quantity"]),
                            product = new ProductDal().GetByid(Convert.ToInt32(dataReader["idproduct"])),
                            purchase = new PurchaseDal().GetByid(Convert.ToInt32(dataReader["idPurchase"])),
                        };
                        return detailPurchase;
                    }
                }
            }
            return null;
        }

        public void Update(DetailPurchase detailPurchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE DetailPurchase SET idPurchase = @idPurchase, price = @price, quantity = @quantity," +
                    " idProduct = @idProduct " +
                    "WHERE idDetailPurchase = @idDetailPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idDetailPurchase", detailPurchase.idDetailPurchase);
                    command.Parameters.AddWithValue("@idPurchase", detailPurchase.purchase.idPurchase);
                    command.Parameters.AddWithValue("@price", detailPurchase.price);
                    command.Parameters.AddWithValue("@quantity", detailPurchase.quantity);
                    command.Parameters.AddWithValue("@idProduct", detailPurchase.product.idProduct);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idDetailPurchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM DetailPurchase WHERE idDetailPurchase = @idDetailPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idDetailPurchase", idDetailPurchase);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
