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
                    "INSERT INTO Purchase (dniEmployee, date, idSupplier, total) " +
                    "VALUES (@dniEmployee, @date, @idSupplier, @total)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", purchase.Employee.IdEmployee);
                    command.Parameters.AddWithValue("@date", purchase.Date);
                    command.Parameters.AddWithValue("@total", purchase.Total);
                    command.Parameters.AddWithValue("@idSupplier", purchase.Supplier.IdSupplier);
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
                            IdPurchase = Convert.ToInt32(dataReader["idPurchase"]),
                            Employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            Supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"])),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Total = Convert.ToDouble(dataReader["total"]),
                            DetailPurchases = new DetailPurchaseDal().GetByPurchase(Convert.ToInt32(dataReader["idPurchase"]))
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
                            IdPurchase = Convert.ToInt32(dataReader["idPurchase"]),
                            Employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            Supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"])),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Total = Convert.ToDouble(dataReader["total"]),
                            DetailPurchases = new DetailPurchaseDal().GetByPurchase(Convert.ToInt32(dataReader["idPurchase"]))
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
                            IdPurchase = Convert.ToInt32(dataReader["idPurchase"]),
                            Employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            Supplier = new SupplierDal().GetByid(Convert.ToInt32(dataReader["idSupplier"])),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Total = Convert.ToDouble(dataReader["total"]),
                            DetailPurchases = new DetailPurchaseDal().GetByPurchase(Convert.ToInt32(dataReader["idPurchase"]))
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
                    "UPDATE Sale SET dniEmployee = @dniEmployee, date = @date, idSupplier = @idSupplier, total = @total " +
                    "WHERE idPurchase = @idPurchase";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idPurchase", purchase.IdPurchase);
                    command.Parameters.AddWithValue("@dniEmployee", purchase.Employee.IdEmployee);
                    command.Parameters.AddWithValue("@date", purchase.Date);
                    command.Parameters.AddWithValue("@total", purchase.Total);
                    command.Parameters.AddWithValue("@idSupplier", purchase.Supplier.IdSupplier);
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
