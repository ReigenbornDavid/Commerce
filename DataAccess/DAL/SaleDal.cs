using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class SaleDal:ConnectionToSql
    {
        public void Insert(Sale sale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO Sale (dniClient, dniEmployee, date) " +
                    "VALUES (@dniClient, @dniEmployee, @date)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@dniClient", sale.client.idClient);
                    command.Parameters.AddWithValue("@dniEmployee", sale.employee.idEmployee);
                    command.Parameters.AddWithValue("@date", sale.date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM Sale ORDER BY idSale ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Sale sale = new Sale
                        {
                            idSale = Convert.ToInt32(dataReader["idSale"]),
                            client = new ClientDal().GetByid(Convert.ToInt64(dataReader["dniClient"])),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            date = Convert.ToDateTime(dataReader["date"]),
                            detailSales = new DetailSaleDal().GetBySale(Convert.ToInt32(dataReader["idSale"]))
                        };
                        sales.Add(sale);
                    }
                }
            }
            return sales;
        }

        public Sale GetByDate(DateTime date)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Sale WHERE date = @date";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@date", date);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Sale sale = new Sale
                        {
                            idSale = Convert.ToInt32(dataReader["idSale"]),
                            client = new ClientDal().GetByid(Convert.ToInt64(dataReader["dniClient"])),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            date = Convert.ToDateTime(dataReader["date"]),
                            detailSales = new DetailSaleDal().GetBySale(Convert.ToInt32(dataReader["idSale"]))
                        };
                        return sale;
                    }
                }
            }
            return null;
        }

        public Sale GetByid(int idSale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM Sale WHERE idSale = @idSale";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idSale", idSale);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Sale sale = new Sale
                        {
                            idSale = Convert.ToInt32(dataReader["idSale"]),
                            client = new ClientDal().GetByid(Convert.ToInt64(dataReader["dniClient"])),
                            employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            date = Convert.ToDateTime(dataReader["date"]),
                            detailSales = new DetailSaleDal().GetBySale(Convert.ToInt32(dataReader["idSale"]))
                        };
                        return sale;
                    }
                }
            }
            return null;
        }
        public void Update(Sale sale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE Sale SET dniClient = @dniClient, dniEmployee = @dniEmployee, date = @date " +
                    "WHERE idSale = @idSale";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSale", sale.idSale);
                    command.Parameters.AddWithValue("@dniClient", sale.client.idClient);
                    command.Parameters.AddWithValue("@dniEmployee", sale.employee.idEmployee);
                    command.Parameters.AddWithValue("@date", sale.date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idSale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Sale WHERE idSale = @idSale";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSale", idSale);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
