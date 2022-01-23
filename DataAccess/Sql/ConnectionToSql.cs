using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {
        private readonly string connectionString;
        private readonly string connectionStringCasa;
        private readonly string connectionStringCasa2;
        private readonly string connectionStringLocal;
        public ConnectionToSql()
        {
            //localhost
            connectionString = "Database=commerce; Data Source=localhost; User Id=root; Password=toor";
            //localhost
            connectionStringCasa = "Database=commerce; Server=192.168.1.41; Port=3306; Uid=root; Pwd=toor";
            //localhost
            connectionStringCasa2 = "Database=commerce2; Server=192.168.1.41; Port=3306; Uid=root; Pwd=toor";
            //localhost
            connectionStringLocal = "Database=commerce; Server=192.168.100.5; Port=3306; Uid=root; Pwd=toor";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionStringCasa);
        }
    }
}
