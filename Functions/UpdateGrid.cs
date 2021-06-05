using Common.Functions;
using Common.KonkretneKlase;
using DAO;
using DAO.UzumanjeIzBaze;
using KonkretneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class UpdateGrid : IUpdateGrid
    {
        public void Update(string tabela)
        {
            List<IFunkcijaKlasa> lista = new List<IFunkcijaKlasa>();

            switch(tabela)
            {
                case "Mininalna potrosnja": lista = new VratiTabeluFunkcije().VratiListu("minimalna"); break;
                case "Maximalna potrosnja": lista =  new VratiTabeluFunkcije().VratiListu("maximalna"); break;
                case "Standardna devijacija": lista = new VratiTabeluFunkcije().VratiListu("devijacija"); break;
            }
            PodaciLista.Podaci.Clear();
            foreach(FunkcijaKlasa item in lista)
            {
                PodaciLista.Podaci.Add(item);
            }
        }
    }
}
