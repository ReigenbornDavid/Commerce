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
                    "INSERT INTO Client (dniClient, firstName, lastName, address) " +
                    "VALUES (@dniClient, @firstName, @lastName, @address)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", client.idClient);
                    command.Parameters.AddWithValue("@firstName", client.firstName);
                    command.Parameters.AddWithValue("@lastName", client.lastName);
                    command.Parameters.AddWithValue("@address", client.address);
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
                const string sqlQuery = "SELECT * FROM Client ORDER BY dniClient ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client
                        {
                            idClient = Convert.ToInt32(dataReader["dniClient"]),
                            firstName = Convert.ToString(dataReader["firstName"]),
                            lastName = Convert.ToString(dataReader["lastName"]),
                            address = Convert.ToString(dataReader["address"]),
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
                const string sqlQuery = "SELECT * FROM Client WHERE firstName like @Name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Client client = new Client
                        {
                            idClient = Convert.ToInt32(dataReader["dniClient"]),
                            firstName = Convert.ToString(dataReader["firstName"]),
                            lastName = Convert.ToString(dataReader["lastName"]),
                            address = Convert.ToString(dataReader["address"]),
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
                const string sqlGetById = "SELECT * FROM Client WHERE dniClient = @idClient";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idClient", idClient);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Client client = new Client
                        {
                            idClient = Convert.ToInt32(dataReader["dniClient"]),
                            firstName = Convert.ToString(dataReader["firstName"]),
                            lastName = Convert.ToString(dataReader["lastName"]),
                            address = Convert.ToString(dataReader["address"]),
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
                    "UPDATE Client SET dniClient = @dniClient, firstName = @firstName, " +
                    "lastName = @lastName, address = @address " +
                    "WHERE dniClient = @dniClient";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", client.idClient);
                    command.Parameters.AddWithValue("@firstName", client.firstName);
                    command.Parameters.AddWithValue("@lastName", client.lastName);
                    command.Parameters.AddWithValue("@address", client.address);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Int64 dniClient)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Client WHERE dniClient = @dniClient";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", dniClient);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
