using Common.DAO;
using Common.KonkretneKlase;
using KonkretneKlase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VratiListuIzmerenihPoSifri : IVratiListuIzmerenihPoSifri
    {
        public List<IIzmereno> ListaPoSifri(string s)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();

            List<IIzmereno> lista = new List<IIzmereno>();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM izmereno WHERE sifrapd = ?sifrapd";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("sifrapd", s));

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Izmereno iz = new Izmereno();

                        DateTime date;
                        DateTime time;
                        date = DateTime.Parse(reader.GetValue(4).ToString());
                        time = DateTime.Parse(reader.GetValue(5).ToString());
                        DateTime combined = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);

                        iz.id = Int32.Parse((reader.GetValue(0).ToString()));
                        iz.sifrapd = reader.GetValue(1).ToString();
                        iz.nazivpd = reader.GetValue(2).ToString();
                        iz.vrednost = Double.Parse(reader.GetValue(3).ToString());
                        iz.datumvreme = combined;

                        lista.Add(iz);
                    }
                }

            }
            return lista;
        }
        
    }
}
