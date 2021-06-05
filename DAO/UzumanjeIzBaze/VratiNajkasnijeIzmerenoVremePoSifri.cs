using Common.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VratiNajkasnijeIzmerenoVremePoSifri : IVratiNajkasnijeIzmerenoVremePoSifri
    {
        public DateTime VratiVreme(string s)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT vreme FROM izmereno WHERE sifrapd = ?sifrapd && vreme >= all(select vreme from izmereno where sifrapd = ?sifrapg);";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("sifrapd", s));
                cmd.Parameters.Add(new MySqlParameter("sifrapg", s));

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                       reader.Read();
                       return DateTime.Parse(reader.GetValue(0).ToString());
                }

            }
        }
    }
}
