using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ClientDal : ConnectionToSql
    {
        public void Insert(Client client)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO client (dniClient, firstName, lastName, address, balance) " +
                    "VALUES (@dniClient, @firstName, @lastName, @address, @balance)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", client.IdClient);
                    command.Parameters.AddWithValue("@firstName", client.FirstName);
                    command.Parameters.AddWithValue("@lastName", client.LastName);
                    command.Parameters.AddWithValue("@address", client.Address);
                    command.Parameters.AddWithValue("@tel", client.Tel);
                    command.Parameters.AddWithValue("@balance", client.Balance);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM client ORDER BY dniClient ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client
                        {
                            IdClient = Convert.ToInt64(dataReader["dniClient"]),
                            FirstName = Convert.ToString(dataReader["firstName"]),
                            LastName = Convert.ToString(dataReader["lastName"]),
                            Address = Convert.ToString(dataReader["address"]),
                            Tel = Convert.ToString(dataReader["tel"]),
                            Balance = Convert.ToDouble(dataReader["balance"]),
                        };
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public List<Client> GetByName(string name)
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM client WHERE firstName like @Name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client
                        {
                            IdClient = Convert.ToInt64(dataReader["dniClient"]),
                            FirstName = Convert.ToString(dataReader["firstName"]),
                            LastName = Convert.ToString(dataReader["lastName"]),
                            Address = Convert.ToString(dataReader["address"]),
                            Tel = Convert.ToString(dataReader["tel"]),
                            Balance = Convert.ToDouble(dataReader["balance"]),
                        };
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }

        public Client GetByid(Int64 idClient)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM client WHERE dniClient = @idClient";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idClient", idClient);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Client client = new Client
                        {
                            IdClient = Convert.ToInt64(dataReader["dniClient"]),
                            FirstName = Convert.ToString(dataReader["firstName"]),
                            LastName = Convert.ToString(dataReader["lastName"]),
                            Address = Convert.ToString(dataReader["address"]),
                            Tel = Convert.ToString(dataReader["tel"]),
                            Balance = Convert.ToDouble(dataReader["balance"]),
                            Transactions = new TransactionDal().GetTransactionById(Convert.ToInt64(dataReader["dniClient"])),
                        };
                        return client;
                    }
                }
            }
            return null;
        }
        public void Update(Client client)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE client SET dniClient = @dniClient, firstName = @firstName, " +
                    "lastName = @lastName, address = @address, tel = @tel, balance = @balance " +
                    "WHERE dniClient = @dniClient";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", client.IdClient);
                    command.Parameters.AddWithValue("@firstName", client.FirstName);
                    command.Parameters.AddWithValue("@lastName", client.LastName);
                    command.Parameters.AddWithValue("@address", client.Address);
                    command.Parameters.AddWithValue("@tel", client.Tel);
                    command.Parameters.AddWithValue("@balance", client.Balance);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Int64 dniClient)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM client WHERE dniClient = @dniClient";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", dniClient);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
