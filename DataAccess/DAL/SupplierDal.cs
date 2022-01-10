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
                    "INSERT INTO Supplier (name, needInvoice) VALUES (@name, @needInvoice)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", supplier.name);
                    command.Parameters.AddWithValue("@needInvoice", supplier.needInvoice);
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
                const string sqlQuery = "SELECT * FROM Supplier ORDER BY idSupplier ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            idSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            name = Convert.ToString(dataReader["name"]),
                            needInvoice = Convert.ToBoolean(dataReader["needInvoice"])
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
                const string sqlGetById = "SELECT * FROM Supplier WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            idSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            name = Convert.ToString(dataReader["name"]),
                            needInvoice = Convert.ToBoolean(dataReader["needInvoice"])
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
                const string sqlGetById = "SELECT * FROM Supplier WHERE idSupplier = @idSupplier";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idSupplier", idSupplier);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            idSupplier = Convert.ToInt32(dataReader["idSupplier"]),
                            name = Convert.ToString(dataReader["name"]),
                            needInvoice = Convert.ToBoolean(dataReader["needInvoice"])
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
                    "UPDATE Supplier SET name = @name, needInvoice = @needInvoice WHERE idSupplier = @idSUpplier";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", supplier.name);
                    command.Parameters.AddWithValue("@needInvoice", supplier.needInvoice);
                    command.Parameters.AddWithValue("@idSupplier", supplier.idSupplier);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idSupplier)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Supplier WHERE idSupplier = @idSupplier";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSupplier", idSupplier);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
