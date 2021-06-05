using Common.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VratiNaziv : IVratiNaziv
    {
        public string VratiNazivPodrucja(string id)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nazivpd FROM postojecapd WHERE sifrapd = ?sifrapd";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("sifrapd", id));
                string naziv = "";

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        naziv = reader.GetValue(0).ToString();
                    }
                }

                return naziv;

            }
        }
    }
}
