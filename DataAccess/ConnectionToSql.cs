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
            connectionString = "Database=mesaentrada; Data Source=localhost; User Id=root; Password=toor";
            //localhost
            connectionStringRedLocal = "Database=mesaentrada; Server=192.168.0.140; Port=3306; Uid=dev; Pwd=Dr753159852460?&";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
