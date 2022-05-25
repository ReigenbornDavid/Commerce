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

        public bool Insert(Sale sale)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        try
                        {
                            //Insert New Sale
                            InsertSale(command, sale);
                            //Get Last IdSale
                            command.CommandText = "SELECT LAST_INSERT_ID() as last;";
                            MySqlDataReader dataReader = command.ExecuteReader();
                            if (dataReader.Read())
                            {
                                sale.IdSale = Convert.ToInt32(dataReader["last"]);
                            }
                            dataReader.Close();
                            
                            //Insert All DetailSales
                            foreach (var item in sale.DetailSales)
                            {
                                //Insert New DetailSale
                                InsertDetailSale(command, item, sale);
                                //Update Quantity Product
                                UpdateQuantityProduct(command, item);
                            }
                            UpdateClientBalance(command, sale);
                            if (sale.Client.Transactions != null)
                            {
                                foreach (var item in sale.Client.Transactions)
                                {
                                    InsertTransaction(command, item);
                                }
                            }
                            //Commit Transaction
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
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

        private void InsertSale(MySqlCommand command, Sale sale)
        {
            command.CommandText = "INSERT INTO sale (dniClient, dniEmployee, date, total) " +
                                "VALUES (@dniClient, @dniEmployee, @date, @total)";
            command.Parameters.AddWithValue("@dniClient", sale.Client.IdClient);
            command.Parameters.AddWithValue("@dniEmployee", sale.Employee.IdEmployee);
            command.Parameters.AddWithValue("@date", sale.Date);
            command.Parameters.AddWithValue("@total", sale.Total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        private void InsertDetailSale(MySqlCommand command, DetailSale item, Sale sale)
        {
            command.CommandText = "INSERT INTO DetailSale (idSale, price, quantity, idProduct) " +
                                            "VALUES (@idSale, @price, @quantity, @idProduct)";
            item.Sale = sale;
            command.Parameters.AddWithValue("@idSale", item.Sale.IdSale);
            command.Parameters.AddWithValue("@price", item.Price);
            //command.Parameters.AddWithValue("@price", "H");
            command.Parameters.AddWithValue("@quantity", item.Quantity);
            command.Parameters.AddWithValue("@idProduct", item.Product.IdProduct);
            string a = command.CommandText;
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        private void UpdateQuantityProduct(MySqlCommand command, DetailSale item)
        {
            command.CommandText = "UPDATE product SET quantity = @quantity WHERE idProduct = @idProduct";
            item.Product.Quantity -= item.Quantity;
            command.Parameters.AddWithValue("@quantity", item.Product.Quantity);
            command.Parameters.AddWithValue("@idProduct", item.Product.IdProduct);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        private void UpdateClientBalance(MySqlCommand command, Sale sale)
        {
            command.CommandText = "UPDATE client SET balance = @balance " +
                                "WHERE dniClient = @dniClient";
            command.Parameters.AddWithValue("@dniClient", sale.Client.IdClient);
            command.Parameters.AddWithValue("@balance", sale.Client.Balance);
            command.ExecuteNonQuery();
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
                            IdSale = Convert.ToInt32(dataReader["idSale"]),
                            Client = new ClientDal().GetByid(Convert.ToInt64(dataReader["dniClient"])),
                            Employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Total = Convert.ToDouble(dataReader["total"])
                        };
                        sales.Add(sale);
                    }
                }
            }
            return sales;
        }
        public int GetLastIdSale()
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT s.idSale as last FROM sale s " +
                    "ORDER BY s.idSale DESC LIMIT 1";
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
                            IdSale = Convert.ToInt32(dataReader["idSale"]),
                            Client = new ClientDal().GetByid(Convert.ToInt64(dataReader["dniClient"])),
                            Employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Total = Convert.ToDouble(dataReader["total"])
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
                const string sqlGetById = "SELECT * FROM sale WHERE idSale = @idSale";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idSale", idSale);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Sale sale = new Sale
                        {
                            IdSale = Convert.ToInt32(dataReader["idSale"]),
                            Client = new ClientDal().GetByid(Convert.ToInt64(dataReader["dniClient"])),
                            Employee = new EmployeeDal().GetByid(Convert.ToInt32(dataReader["dniEmployee"])),
                            Date = Convert.ToDateTime(dataReader["date"]),
                            Total = Convert.ToDouble(dataReader["total"])
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
                    "UPDATE Sale SET dniClient = @dniClient, dniEmployee = @dniEmployee, " +
                    "date = @date, total = @total " +
                    "WHERE idSale = @idSale";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSale", sale.IdSale);
                    command.Parameters.AddWithValue("@dniClient", sale.Client.IdClient);
                    command.Parameters.AddWithValue("@dniEmployee", sale.Employee.IdEmployee);
                    command.Parameters.AddWithValue("@date", sale.Date);
                    command.Parameters.AddWithValue("@total", sale.Total);
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
