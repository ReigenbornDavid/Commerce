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
                    "INSERT INTO employee (dniEmployee, firstName, lastName, user, pass, email, position, active) " +
                    "VALUES (@dniEmployee, @firstName, @lastName, @user, @pass, @email, @position, @active)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", employee.IdEmployee);
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@user", employee.User);
                    command.Parameters.AddWithValue("@pass", employee.Pass);
                    command.Parameters.AddWithValue("@email", employee.Email);
                    command.Parameters.AddWithValue("@position", employee.Position);
                    command.Parameters.AddWithValue("@active", employee.Active);
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
                const string sqlQuery = "SELECT * FROM employee ORDER BY dniClient ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee
                        {
                            IdEmployee = Convert.ToInt32(dataReader["dniEmployee"]),
                            FirstName = Convert.ToString(dataReader["firstName"]),
                            LastName = Convert.ToString(dataReader["lastName"]),
                            User = Convert.ToString(dataReader["user"]),
                            Pass = Convert.ToString(dataReader["pass"]),
                            Email = Convert.ToString(dataReader["email"]),
                            Position = Convert.ToString(dataReader["position"]),
                            Active = Convert.ToBoolean(dataReader["active"]),
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
                const string sqlQuery = "SELECT * FROM employee WHERE firstName like @Name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Employee employee = new Employee
                        {
                            IdEmployee = Convert.ToInt32(dataReader["dniEmployee"]),
                            FirstName = Convert.ToString(dataReader["firstName"]),
                            LastName = Convert.ToString(dataReader["lastName"]),
                            User = Convert.ToString(dataReader["user"]),
                            Pass = Convert.ToString(dataReader["pass"]),
                            Email = Convert.ToString(dataReader["email"]),
                            Position = Convert.ToString(dataReader["position"]),
                            Active = Convert.ToBoolean(dataReader["active"]),
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
                const string sqlGetById = "SELECT * FROM employee WHERE dniEmployee = @idEmployee";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idEmployee", idEmployee);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Employee employee = new Employee
                        {
                            IdEmployee = Convert.ToInt32(dataReader["dniEmployee"]),
                            FirstName = Convert.ToString(dataReader["firstName"]),
                            LastName = Convert.ToString(dataReader["lastName"]),
                            User = Convert.ToString(dataReader["user"]),
                            Pass = Convert.ToString(dataReader["pass"]),
                            Email = Convert.ToString(dataReader["email"]),
                            Position = Convert.ToString(dataReader["position"]),
                            Active = Convert.ToBoolean(dataReader["active"]),
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
                    "UPDATE employee SET dniEmployee = @dniEmployee, firstName = @firstName, " +
                    "lastName = @lastName, user = @user, pass = @pass, " +
                    "email = @email, position = @position, active = @active " +
                    "WHERE dniEmployee = @dniEmployee";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", employee.IdEmployee);
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@user", employee.User);
                    command.Parameters.AddWithValue("@pass", employee.Pass);
                    command.Parameters.AddWithValue("@email", employee.Email);
                    command.Parameters.AddWithValue("@position", employee.Position);
                    command.Parameters.AddWithValue("@active", employee.Active);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int dniEmployee)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM employee WHERE dniEmployee = @dniEmployee";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniEmployee", dniEmployee);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
