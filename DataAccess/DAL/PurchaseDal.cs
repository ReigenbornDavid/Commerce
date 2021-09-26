using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class PurchaseDal:ConnectionToSql
    {
        public void Insert(Purchase purchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Purchase (dniEmployee, date) " +
                    "VALUES (@dniEmployee, @date)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", purchase.employee.idEmployee);
                    command.Parameters.AddWithValue("@date", purchase.date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Purchase> GetAll()
        {
            List<Purchase> purchases = new List<Purchase>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM Purchase ORDER BY idSale ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Purchase purchase = new Purchase
                        {
                            idPurchase = Convert.ToInt32(dataReader["idPurchase"]),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            date = Convert.ToDateTime(dataReader["date"]),
                            detailPurchases = new DetailPurchaseDal().GetByPurchase(Convert.ToInt32(dataReader["idPurchase"]))
                        };
                        purchases.Add(purchase);
                    }
                }
            }
            return purchases;
        }

        public int GetLastId()
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT p.idPurchase as last FROM Purchase p " +
                    "ORDER BY p.idPurchase DESC LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        return Convert.ToInt32(dataReader["last"]);
                    }
                }
            }
            return -1;
        }

        public Purchase GetByDate(DateTime date)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Purchase WHERE date = @date";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@date", date);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Purchase purchase = new Purchase
                        {
                            idPurchase = Convert.ToInt32(dataReader["idPurchase"]),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            date = Convert.ToDateTime(dataReader["date"]),
                            detailPurchases = new DetailPurchaseDal().GetByPurchase(Convert.ToInt32(dataReader["idPurchase"]))
                        };
                        return purchase;
                    }
                }
            }
            return null;
        }

        public Purchase GetByid(int idPurchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Purchase WHERE idPurchase = @idPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idPurchase", idPurchase);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Purchase purchase = new Purchase
                        {
                            idPurchase = Convert.ToInt32(dataReader["idPurchase"]),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            date = Convert.ToDateTime(dataReader["date"]),
                            detailPurchases = new DetailPurchaseDal().GetByPurchase(Convert.ToInt32(dataReader["idPurchase"]))
                        };
                        return purchase;
                    }
                }
            }
            return null;
        }
        public void Update(Purchase purchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Sale SET dniEmployee = @dniEmployee, date = @date " +
                    "WHERE idPurchase = @idPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idPurchase", purchase.idPurchase);
                    command.Parameters.AddWithValue("@dniEmployee", purchase.employee.idEmployee);
                    command.Parameters.AddWithValue("@date", purchase.date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idPurchase)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Purchase WHERE idPurchase = @idPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idPurchase", idPurchase);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
