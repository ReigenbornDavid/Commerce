using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class TransactionDal : ConnectionToSql
    {
        public void Insert(Transaction transaction)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "INSERT INTO Transaction (idClient, amount, date) " +
                                "VALUES (@idClient, @amount, @date)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idClient", transaction.IdClient);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@date", transaction.Date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Transaction> GetTransactionById(long idClient)
        {
            List<Transaction> transactions = new List<Transaction>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM transaction t WHERE t.idClient = @idClient";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idClient", idClient);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Transaction transaction = new Transaction
                        {
                            IdTransaction = Convert.ToInt32(dataReader["idTransaction"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Amount = Convert.ToDouble(dataReader["amount"]),
                        };
                        transactions.Add(transaction);
                    }
                }
            }
            return transactions;
        }
    }
}
