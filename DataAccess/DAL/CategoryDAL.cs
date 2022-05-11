using Common.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class CategoryDal : ConnectionToSql
    {
        public void Insert(Category category)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "INSERT INTO category (name) VALUES (@name)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", category.Name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM category c ORDER BY c.name ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            IdCategory = Convert.ToInt32(dataReader["idCategory"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public List<Category> GetAllByName(string name)
        {
            List<Category> categories = new List<Category>();

            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "SELECT * FROM category c WHERE c.name like @name order by c.name";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", name + "%");
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            IdCategory = Convert.ToInt32(dataReader["idCategory"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public Category GetByName(string name)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM category WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            IdCategory = Convert.ToInt32(dataReader["idCategory"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        return category;
                    }
                }
            }
            return null;
        }

        public Category GetByid(int idCategory)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlGetById = "SELECT * FROM category WHERE idCategory = @idCategory";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idCategory", idCategory);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            IdCategory = Convert.ToInt32(dataReader["idCategory"]),
                            Name = Convert.ToString(dataReader["name"])
                        };
                        return category;
                    }
                }
            }
            return null;
        }
        public void Update(Category category)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery =
                    "UPDATE category SET name = @name WHERE idCategory = @idCategory";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", category.Name);
                    command.Parameters.AddWithValue("@idCategory", category.IdCategory);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idCategory)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM category WHERE idCategory = @idCategory";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idCategory", idCategory);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
