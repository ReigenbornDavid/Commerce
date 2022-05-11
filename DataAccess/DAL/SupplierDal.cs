using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class SupplierDal:ConnectionToSql
    {
        public void Insert(Supplier supplier)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO supplier (name, needInvoice) VALUES (@name, @needInvoice)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", supplier.Name);
                    command.Parameters.AddWithValue("@needInvoice", supplier.NeedInvoice);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Supplier> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM supplier s ORDER BY s.name ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            IdSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            Name = Convert.ToString(dataReader["name"]),
                            NeedInvoice = Convert.ToBoolean(dataReader["needInvoice"]),
                        };
                        suppliers.Add(supplier);
                    }
                }
            }
            return suppliers;
        }

        public List<Supplier> GetAllByName(string name)
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM supplier s WHERE s.name like @name order by s.name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            IdSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            Name = Convert.ToString(dataReader["name"]),
                            NeedInvoice = Convert.ToBoolean(dataReader["needInvoice"]),
                        };
                        suppliers.Add(supplier);
                    }
                }
            }
            return suppliers;
        }

        public Supplier GetByName(string name)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM supplier WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            IdSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            Name = Convert.ToString(dataReader["name"]),
                            NeedInvoice = Convert.ToBoolean(dataReader["needInvoice"]),
                        };
                        return supplier;
                    }
                }
            }
            return null;
        }

        public Supplier GetByid(int idSupplier)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM supplier WHERE idSupplier = @idSupplier";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idSupplier", idSupplier);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            IdSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            Name = Convert.ToString(dataReader["name"]),
                            NeedInvoice = Convert.ToBoolean(dataReader["needInvoice"]),
                        };
                        return supplier;
                    }
                }
            }
            return null;
        }
        public void Update(Supplier supplier)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE supplier SET name = @name, needInvoice = @needInvoice WHERE idSupplier = @idSUpplier";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", supplier.Name);
                    command.Parameters.AddWithValue("@needInvoice", supplier.NeedInvoice);
                    command.Parameters.AddWithValue("@idSupplier", supplier.IdSupplier);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idSupplier)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM supplier WHERE idSupplier = @idSupplier";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSupplier", idSupplier);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
