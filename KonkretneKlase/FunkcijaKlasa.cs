using Common.KonkretneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonkretneKlase
{
    public class FunkcijaKlasa : IFunkcijaKlasa
    {
        public string sifrapd { get; set; }
        public string nazivpd { get; set; }
        public DateTime vremeproracuna { get; set; }
        public DateTime poslednjevreme { get; set; }
        public double vrednost { get; set; }
    }
}
