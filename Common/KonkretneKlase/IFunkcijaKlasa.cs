using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.KonkretneKlase
{
    public interface IFunkcijaKlasa
    {
        string sifrapd { get; set; }
        string nazivpd { get; set; }
        DateTime vremeproracuna { get; set; }
        DateTime poslednjevreme { get; set; }
        double vrednost{ get; set; }
    }
}
