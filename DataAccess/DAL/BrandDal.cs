using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class BrandDal:ConnectionToSql
    {
        public void Insert(Brand brand)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO brand (name) VALUES (@name)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", brand.Name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Brand> GetAll()
        {
            List<Brand> brands = new List<Brand>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM brand b ORDER BY b.name ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Brand brand = new Brand
                        {
                            IdBrand = Convert.ToInt32(dataReader["idBrand"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        brands.Add(brand);
                    }
                }
            }
            return brands;
        }

        public List<Brand> GetAllByName(string name)
        {
            List<Brand> brands = new List<Brand>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM brand b WHERE b.name like @name order by b.name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Brand brand = new Brand
                        {
                            IdBrand = Convert.ToInt32(dataReader["idBrand"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        brands.Add(brand);
                    }
                }
            }
            return brands;
        }

        public Brand GetByName(string name)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM brand WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Brand brand = new Brand
                        {
                            IdBrand = Convert.ToInt32(dataReader["idBrand"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        return brand;
                    }
                }
            }
            return null;
        }

        public Brand GetByid(int idBrand)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM brand WHERE idBrand = @idBrand";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idBrand", idBrand);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Brand brand = new Brand
                        {
                            IdBrand = Convert.ToInt32(dataReader["idBrand"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        return brand;
                    }
                }
            }
            return null;
        }
        public void Update(Brand brand)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE brand SET name = @name WHERE idBrand = @idBrand";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", brand.Name);
                    command.Parameters.AddWithValue("@idBrand", brand.IdBrand);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idBrand)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM brand WHERE idBrand = @idBrand";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idBrand", idBrand);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
