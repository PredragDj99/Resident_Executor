using Common.KonkretneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonkretneKlase
{
    public class Izmereno : IIzmereno
    {
        public int id { get; set; }
        public string sifrapd { get; set; }
        public string nazivpd { get; set; }
        public double vrednost { get; set; }
        public DateTime datumvreme { get; set; }
    }
}
