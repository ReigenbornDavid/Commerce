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
                    "INSERT INTO Service (description, price, date, dniClient, dniEmployee) " +
                    "VALUES (@description, @price, @date, @dniClient, @dniEmployee)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@description", service.description);
                    command.Parameters.AddWithValue("@price", service.price);
                    command.Parameters.AddWithValue("@date", service.date);
                    command.Parameters.AddWithValue("@dniClient", service.client.idClient);
                    command.Parameters.AddWithValue("@dniEmployee", service.employee.idEmployee);
                    command.ExecuteNonQuery();
                }
            }
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
                            idService = Convert.ToInt32(dataReader["idService"]),
                            description = Convert.ToString(dataReader["description"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            date = Convert.ToDateTime(dataReader["date"]),
                            client = new ClientDal().GetByid(Convert.ToInt32(dataReader["idClient"])),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["idEmployee"]))
                        };
                        services.Add(service);
                    }
                }
            }
            return services;
        }

        public List<Service> GetByName(string description)
        {
            List<Service> services = new List<Service>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById =
                "SELECT * FROM Service WHERE description like @Description";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@Description", "%" + description + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Service service = new Service
                        {
                            idService = Convert.ToInt32(dataReader["idService"]),
                            description = Convert.ToString(dataReader["description"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            date = Convert.ToDateTime(dataReader["date"]),
                            client = new ClientDal().GetByid(Convert.ToInt32(dataReader["idClient"])),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["idEmployee"]))
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
                            idService = Convert.ToInt32(dataReader["idService"]),
                            description = Convert.ToString(dataReader["description"]),
                            price = Convert.ToDecimal(dataReader["price"]),
                            date = Convert.ToDateTime(dataReader["date"]),
                            client = new ClientDal().GetByid(Convert.ToInt32(dataReader["idClient"])),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["idEmployee"]))
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
                    "UPDATE Service SET description = @description, price = @price, date = @date, dniClient = @dniClient, " +
                    "dniEmployee = @dniEmployee WHERE idService = @idService";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idService", service.idService);
                    command.Parameters.AddWithValue("@description", service.description);
                    command.Parameters.AddWithValue("@price", service.price);
                    command.Parameters.AddWithValue("@date", service.date);
                    command.Parameters.AddWithValue("@dniClient", service.client.idClient);
                    command.Parameters.AddWithValue("@dniEmployee", service.employee.idEmployee);
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
