using Common.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VratiNajkasnijeFunkcVremePoSifri : IVratiNajkasnijeFunkcVremePoSifri
    {
        public DateTime VratiVreme(string tabela, string s)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT vremeproracuna FROM " + tabela + " WHERE sifrapd = ?sifrapd";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("sifrapd", s));
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    if(reader.HasRows)
                    {
                        reader.Read();
                        return DateTime.Parse(reader.GetValue(0).ToString());
                    }
                    else
                    {
                        string dateString = "7/10/1974 7:10:24 AM";
                        return DateTime.Parse(dateString);
                    }

                }

            }
        }
    }
}
