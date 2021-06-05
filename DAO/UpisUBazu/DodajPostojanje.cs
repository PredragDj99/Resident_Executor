using Common.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DodajPostojanje : IDodajPostojanje
    {
        public bool DodajPodrucje(string id, string naziv)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM postojecapd WHERE sifrapd = ?sifrapd or nazivpd = ?nazivpd;";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("sifrapd", id));
                cmd.Parameters.Add(new MySqlParameter("nazivpd", naziv));
                var result = Convert.ToInt32(cmd.ExecuteScalar());

                if(result > 0 )
                {
                    return false;
                }
                else
                {
                    query = "INSERT INTO postojecapd (sifrapd, nazivpd) VALUES(?sifrapd, ?nazivpd)";
                    cmd.CommandText = query;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new MySqlParameter("sifrapd", id));
                    cmd.Parameters.Add(new MySqlParameter("nazivpd", naziv));
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
        }
    }
}

