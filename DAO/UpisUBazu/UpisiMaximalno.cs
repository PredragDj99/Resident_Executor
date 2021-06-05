using Common.DAO;
using Common.KonkretneKlase;
using KonkretneKlase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.UpisUBazu
{
    public class UpisiMaximalno : IUpisiMaximalno
    {
        public void Upisi(IFunkcijaKlasa fk)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM maximalna WHERE sifrapd = ?sifrapd";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.Add(new MySqlParameter("sifrapd", fk.sifrapd));

                cmd.ExecuteNonQuery();

                query = "INSERT INTO maximalna (sifrapd, nazivpd, vremeproracuna, poslednjevreme, maximalnapotrosnja) VALUES(?sifrapd, ?nazivpd, ?vremeproracuna, ?poslednjevreme, ?maximalnapotrosnja)";
                cmd.CommandText = query;
                cmd.Parameters.Clear();

                cmd.Parameters.Add(new MySqlParameter("sifrapd", fk.sifrapd));
                cmd.Parameters.Add(new MySqlParameter("nazivpd", fk.nazivpd));
                cmd.Parameters.Add(new MySqlParameter("vremeproracuna", fk.vremeproracuna));
                cmd.Parameters.Add(new MySqlParameter("poslednjevreme", fk.poslednjevreme));
                cmd.Parameters.Add(new MySqlParameter("maximalnapotrosnja", fk.vrednost));

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                connection.Clone();
            }
        }
    }
}
