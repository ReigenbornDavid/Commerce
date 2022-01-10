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
        private readonly string connectionString2;
        private readonly string connectionStringRedLocal;
        public ConnectionToSql()
        {
            //localhost
            connectionString = "Database=commerce; Data Source=localhost; User Id=root; Password=toor";
            //localhost
            connectionStringRedLocal = "Database=commerce; Server=192.168.1.41; Port=3306; Uid=root; Pwd=toor";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionStringRedLocal);
        }
    }
}
