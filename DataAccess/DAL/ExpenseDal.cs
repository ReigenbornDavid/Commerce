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
                    "INSERT INTO Expense (description, price, date) " +
                    "VALUES (@description, @price, @date)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", expense.Description);
                    command.Parameters.AddWithValue("@price", expense.Price);
                    command.Parameters.AddWithValue("@date", expense.Date);
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
                            IdExpense = Convert.ToInt32(dataReader["idExpense"]),
                            Description = dataReader["description"].ToString(),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
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
                            IdExpense = Convert.ToInt32(dataReader["idExpense"]),
                            Description = dataReader["description"].ToString(),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
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
                            IdExpense = Convert.ToInt32(dataReader["idExpense"]),
                            Description = dataReader["description"].ToString(),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
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
                    "UPDATE Expense SET description = @description, price = @price, " +
                    "date = @date " +
                    "WHERE idExpense = @idExpense";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idExpense", expense.IdExpense);
                    command.Parameters.AddWithValue("@description", expense.Description);
                    command.Parameters.AddWithValue("@price", expense.Price);
                    command.Parameters.AddWithValue("@date", expense.Date);
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
