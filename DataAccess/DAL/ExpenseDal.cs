using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ExpenseDal:ConnectionToSql
    {
        public void Insert(Expense expense)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Expense (description, price, idPurchase, date) " +
                    "VALUES (@description, @price, @idPurchase, @date)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", expense.description);
                    command.Parameters.AddWithValue("@price", expense.price);
                    if (expense.purchase.idPurchase == 0)
                    {
                        command.Parameters.AddWithValue("@idPurchase", null);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@idPurchase", expense.purchase.idPurchase);
                    }
                    command.Parameters.AddWithValue("@date", expense.date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Expense> GetAll()
        {
            List<Expense> expenses = new List<Expense>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM Expense ORDER BY idExpense ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Expense expense = new Expense
                        {
                            idExpense = Convert.ToInt32(dataReader["idExpense"]),
                            description = dataReader["description"].ToString(),
                            price = Convert.ToDecimal(dataReader["price"]),
                            purchase = new PurchaseDal().GetByid(Convert.ToInt32(dataReader["idPurchase"])),
                            date = Convert.ToDateTime(dataReader["date"])
                        };
                        expenses.Add(expense);
                    }
                }
            }
            return expenses;
        }

        public int GetLastId()
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT e.idExpense as last FROM Expense e " +
                    "ORDER BY e.idExpense DESC LIMIT 1";
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

        public Expense GetByDate(DateTime date)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Expense WHERE date = @date";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@date", date);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Expense expense = new Expense
                        {
                            idExpense = Convert.ToInt32(dataReader["idExpense"]),
                            description = dataReader["description"].ToString(),
                            price = Convert.ToDecimal(dataReader["price"]),
                            purchase = new PurchaseDal().GetByid(Convert.ToInt32(dataReader["idPurchase"])),
                            date = Convert.ToDateTime(dataReader["date"])
                        };
                        return expense;
                    }
                }
            }
            return null;
        }

        public Expense GetByid(int idExpense)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Expense WHERE idExpense = @idExpense";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idExpense", idExpense);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Expense expense = new Expense
                        {
                            idExpense = Convert.ToInt32(dataReader["idExpense"]),
                            description = dataReader["description"].ToString(),
                            price = Convert.ToDecimal(dataReader["price"]),
                            purchase = new PurchaseDal().GetByid(Convert.ToInt32(dataReader["idPurchase"])),
                            date = Convert.ToDateTime(dataReader["date"])
                        };
                        return expense;
                    }
                }
            }
            return null;
        }
        public void Update(Expense expense)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Expense SET description = @description, price = @price, idPurchase = @idPurchase, " +
                    "date = @date " +
                    "WHERE idExpense = @idExpense";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idExpense", expense.idExpense);
                    command.Parameters.AddWithValue("@description", expense.description);
                    command.Parameters.AddWithValue("@price", expense.price);
                    command.Parameters.AddWithValue("@idPurchase", expense.purchase.idPurchase);
                    command.Parameters.AddWithValue("@date", expense.date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idExpense)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Expense WHERE idExpense = @idExpense";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idExpense", idExpense);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
