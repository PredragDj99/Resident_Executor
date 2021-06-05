using Common.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BrojIzmerenih : IBrojIzmerenih
    {
        public int BrojIzmerenihPodrucija()
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM izmereno";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                var result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
        }
    }
}
