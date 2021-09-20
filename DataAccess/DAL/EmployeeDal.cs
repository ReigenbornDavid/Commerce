using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class EmployeeDal:ConnectionToSql
    {
        public void Insert(Employee employee)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Employee (dniEmployee, firstName, lastName, user, pass, email, position, active) " +
                    "VALUES (@dniEmployee, @firstName, @lastName, @user, @pass, @email, @position, @active)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", employee.idEmployee);
                    command.Parameters.AddWithValue("@firstName", employee.firstName);
                    command.Parameters.AddWithValue("@lastName", employee.lastName);
                    command.Parameters.AddWithValue("@user", employee.user);
                    command.Parameters.AddWithValue("@pass", employee.pass);
                    command.Parameters.AddWithValue("@email", employee.email);
                    command.Parameters.AddWithValue("@position", employee.position);
                    command.Parameters.AddWithValue("@active", employee.active);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM Employee ORDER BY dniClient ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee
                        {
                            idEmployee = Convert.ToInt32(dataReader["dniEmployee"]),
                            firstName = Convert.ToString(dataReader["firstName"]),
                            lastName = Convert.ToString(dataReader["lastName"]),
                            user = Convert.ToString(dataReader["user"]),
                            pass = Convert.ToString(dataReader["pass"]),
                            email = Convert.ToString(dataReader["email"]),
                            position = Convert.ToString(dataReader["position"]),
                            active = Convert.ToBoolean(dataReader["active"])
                        };
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public List<Employee> GetByName(string name)
        {
            List<Employee> employees = new List<Employee>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM Employee WHERE firstName like @Name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee
                        {
                            idEmployee = Convert.ToInt32(dataReader["dniEmployee"]),
                            firstName = Convert.ToString(dataReader["firstName"]),
                            lastName = Convert.ToString(dataReader["lastName"]),
                            user = Convert.ToString(dataReader["user"]),
                            pass = Convert.ToString(dataReader["pass"]),
                            email = Convert.ToString(dataReader["email"]),
                            position = Convert.ToString(dataReader["position"]),
                            active = Convert.ToBoolean(dataReader["active"])
                        };
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public Employee GetByid(int idEmployee)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Employee WHERE dniEmployee = @idEmployee";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idEmployee", idEmployee);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Employee employee = new Employee
                        {
                            idEmployee = Convert.ToInt32(dataReader["dniEmployee"]),
                            firstName = Convert.ToString(dataReader["firstName"]),
                            lastName = Convert.ToString(dataReader["lastName"]),
                            user = Convert.ToString(dataReader["user"]),
                            pass = Convert.ToString(dataReader["pass"]),
                            email = Convert.ToString(dataReader["email"]),
                            position = Convert.ToString(dataReader["position"]),
                            active = Convert.ToBoolean(dataReader["active"])
                        };
                        return employee;
                    }
                }
            }
            return null;
        }
        public void Update(Employee employee)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Employee SET dniEmployee = @dniEmployee, firstName = @firstName, " +
                    "lastName = @lastName, user = @user, pass = @pass, " +
                    "email = @email, position = @position, active = @active " +
                    "WHERE dniEmployee = @dniEmployee";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", employee.idEmployee);
                    command.Parameters.AddWithValue("@firstName", employee.firstName);
                    command.Parameters.AddWithValue("@lastName", employee.lastName);
                    command.Parameters.AddWithValue("@user", employee.user);
                    command.Parameters.AddWithValue("@pass", employee.pass);
                    command.Parameters.AddWithValue("@email", employee.email);
                    command.Parameters.AddWithValue("@position", employee.position);
                    command.Parameters.AddWithValue("@active", employee.active);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int dniEmployee)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Employee WHERE dniEmployee = @dniEmployee";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", dniEmployee);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
