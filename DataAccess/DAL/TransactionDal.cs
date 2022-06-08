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

        public bool Insert(Transaction transaction, Client client)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlTransaction Transaction = connection.BeginTransaction())
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        try
                        {
                            //Insert Transaction
                            InsertTransaction(command, transaction);
                            //Update Clint Balance
                            UpdateClientBalance(command, client);
                            //Commit Transaction
                            Transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            return false;
                        }
                        finally
                        {
                            connection.Close();
                            command.Parameters.Clear();
                        }
                    }
                }
            }
        }

        private void InsertTransaction(MySqlCommand command, Transaction transaction)
        {
            command.CommandText = "INSERT INTO Transaction (idClient, amount, date) " +
                                "VALUES (@idClient, @amount, @date)";
            command.Parameters.AddWithValue("@idClient", transaction.IdClient);
            command.Parameters.AddWithValue("@amount", transaction.Amount);
            command.Parameters.AddWithValue("@date", transaction.Date);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        private void UpdateClientBalance(MySqlCommand command, Client client)
        {
            command.CommandText = "UPDATE client SET balance = @balance " +
                                "WHERE dniClient = @dniClient";
            command.Parameters.AddWithValue("@dniClient", client.IdClient);
            command.Parameters.AddWithValue("@balance", client.Balance);
            command.ExecuteNonQuery();
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
