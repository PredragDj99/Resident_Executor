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
    public class UpisiIzmereno : IUpisiIzmereno
    {
        public void Upis(IIzmereno iz)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO izmereno (id, sifrapd, nazivpd, vrednost, datum, vreme) VALUES(?id, ?sifrapd, ?nazivpd, ?vrednost, ?datum, ?vreme)";


                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("id", iz.id));
                cmd.Parameters.Add(new MySqlParameter("sifrapd", iz.sifrapd));
                cmd.Parameters.Add(new MySqlParameter("nazivpd", iz.nazivpd));
                cmd.Parameters.Add(new MySqlParameter("vrednost", iz.vrednost));
                cmd.Parameters.Add(new MySqlParameter("datum", iz.datumvreme.Date));
                cmd.Parameters.Add(new MySqlParameter("vreme", iz.datumvreme.TimeOfDay));
                

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                connection.Clone();
            }
        }
    }
}
