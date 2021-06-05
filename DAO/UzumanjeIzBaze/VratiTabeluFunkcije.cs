using Common.DAO;
using Common.KonkretneKlase;
using KonkretneKlase;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.UzumanjeIzBaze
{
    public class VratiTabeluFunkcije : IVratiTabeluFunkcije
    {
        public List<IFunkcijaKlasa> VratiListu(string tabela)
        {
            ConnectionLink cl = new ConnectionLink();
            string connectionString = cl.TakeConnectionString();

            List<IFunkcijaKlasa> lista = new List<IFunkcijaKlasa>();


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM " + tabela;


                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FunkcijaKlasa f = new FunkcijaKlasa();
                        f.sifrapd = reader.GetValue(0).ToString();
                        f.nazivpd = reader.GetValue(1).ToString();
                        f.vremeproracuna = DateTime.Parse(reader.GetValue(2).ToString());
                        f.poslednjevreme = DateTime.Parse(reader.GetValue(3).ToString());
                        f.vrednost = Double.Parse(reader.GetValue(4).ToString());
                        lista.Add(f);
                    }
                }

            }
            return lista;
        }
    }
}
