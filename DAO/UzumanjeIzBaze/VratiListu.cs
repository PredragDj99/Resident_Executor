using Common.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VratiListu : IVratiListu
    //DA POPUNI COMBOBOX NA MAIN_WINDOW-U I ZA FUNKCIJE
    {
        public List<String> VratiListuSifra()
        {
            List<String> lista = new List<string>();

            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM postojecapd";


                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(reader.GetValue(0).ToString());
                    }
                }

            }

            return lista;
        }
    }
}
