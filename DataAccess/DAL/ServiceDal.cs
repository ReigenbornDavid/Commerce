using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ServiceDal:ConnectionToSql
    {
        public void Insert(Service service)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Service (description, details, price, date, state, client, tel) " +
                    "VALUES (@description, @details, @price, @date, @state, @client, @tel)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", service.Description);
                    command.Parameters.AddWithValue("@details", service.Details);
                    command.Parameters.AddWithValue("@price", service.Price);
                    command.Parameters.AddWithValue("@date", service.Date);
                    command.Parameters.AddWithValue("@state", service.State);
                    command.Parameters.AddWithValue("@client", service.Client);
                    command.Parameters.AddWithValue("@tel", service.Tel);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int GetLastId()
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT s.idService as last FROM Service s " +
                    "ORDER BY s.idService DESC LIMIT 1";
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
        public List<Service> GetAll()
        {
            List<Service> services = new List<Service>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "SELECT * FROM Service s ORDER BY idService ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Service service = new Service
                        {
                            IdService = Convert.ToInt32(dataReader["idService"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Details = Convert.ToString(dataReader["details"]),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            State = Convert.ToString(dataReader["state"]),
                            Client = Convert.ToString(dataReader["client"]),
                            Tel = Convert.ToString(dataReader["tel"]),
                        };
                        services.Add(service);
                    }
                }
            }
            return services;
        }

        public List<Service> GetByName(string description, string query, string filter)
        {
            List<Service> services = new List<Service>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", "%" + description + "%");
                    command.Parameters.AddWithValue("@Filter", filter);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Service service = new Service
                        {
                            IdService = Convert.ToInt32(dataReader["idService"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Details = Convert.ToString(dataReader["details"]),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            State = Convert.ToString(dataReader["state"]),
                            Client = Convert.ToString(dataReader["client"]),
                            Tel = Convert.ToString(dataReader["tel"]),
                        };
                        services.Add(service);
                    }
                }
            }
            return services;
        }

        public Service GetByid(int idService)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Service WHERE idService = @idService";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idService", idService);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Service service = new Service
                        {
                            IdService = Convert.ToInt32(dataReader["idService"]),
                            Description = Convert.ToString(dataReader["description"]),
                            Details = Convert.ToString(dataReader["details"]),
                            Price = Convert.ToDecimal(dataReader["price"]),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            State = Convert.ToString(dataReader["state"]),
                            Client = Convert.ToString(dataReader["client"]),
                            Tel = Convert.ToString(dataReader["tel"]),
                        };
                        return service;
                    }
                }
            }
            return null;
        }

        public void Update(Service service)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Service SET description = @description, details = @details, price = @price, " +
                    "date = @date, state = @state, client = @client, tel = @tel " +
                    "WHERE idService = @idService";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idService", service.IdService);
                    command.Parameters.AddWithValue("@description", service.Description);
                    command.Parameters.AddWithValue("@details", service.Details);
                    command.Parameters.AddWithValue("@price", service.Price);
                    command.Parameters.AddWithValue("@date", service.Date);
                    command.Parameters.AddWithValue("@state", service.State);
                    command.Parameters.AddWithValue("@client", service.Client);
                    command.Parameters.AddWithValue("@tel", service.Tel);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idService)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Service WHERE idService = @idService";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idService", idService);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
