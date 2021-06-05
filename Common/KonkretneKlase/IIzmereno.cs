using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.KonkretneKlase
{
    public interface IIzmereno
    {
        int id { get; set; }
        string sifrapd { get; set; }
        string nazivpd { get; set; }
        double vrednost { get; set; }
        DateTime datumvreme { get; set; }
    }
}
