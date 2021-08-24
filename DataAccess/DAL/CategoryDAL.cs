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
                    "INSERT INTO Category (name) VALUES (@name)";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", category.name);
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
                const string sqlQuery = "SELECT * FROM Category ORDER BY idCategory ASC";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            idCategory = Convert.ToInt32(dataReader["idCategory"]),
                            name = Convert.ToString(dataReader["name"])
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
                const string sqlGetById = "SELECT * FROM Category WHERE name = @name";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            idCategory = Convert.ToInt32(dataReader["idCategory"]),
                            name = Convert.ToString(dataReader["name"])
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
                const string sqlGetById = "SELECT * FROM Category WHERE idCategory = @idCategory";
                using (MySqlCommand command = new MySqlCommand(sqlGetById, connection))
                {
                    command.Parameters.AddWithValue("@idCategory", idCategory);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Category category = new Category
                        {
                            idCategory = Convert.ToInt32(dataReader["idCategory"]),
                            name = Convert.ToString(dataReader["description"])
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
                    "UPDATE Category SET name = @name WHERE idCategory = @idCategory";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", category.name);
                    command.Parameters.AddWithValue("@idCategory", category.idCategory);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idCategory)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                const string sqlQuery = "DELETE FROM Category WHERE idCategory = @idCategory";
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@idCategory", idCategory);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
