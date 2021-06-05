using DAO;
using KonkretneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{

    public class Posrednik
    {
        public bool DodajPostojanje(string id, string naziv)
        {
             return new DodajPostojanje().DodajPodrucje(id, naziv);
        }

        public int BrojIzmerenih()
        {
            return new BrojIzmerenih().BrojIzmerenihPodrucija();
        }

        public string VratiNaziv(string sifra)
        {
            return new VratiNaziv().VratiNazivPodrucja(sifra);
        }

        public void UpisiIzmereno(Izmereno iz)
        {
            new UpisiIzmereno().Upis(iz);
        }

        public List<string> VratiListu()
        {
            return new VratiListu().VratiListuSifra();
        }
    }
}
