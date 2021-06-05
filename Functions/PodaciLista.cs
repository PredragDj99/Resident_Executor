using KonkretneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class PodaciLista
    {
        private static BindingList<FunkcijaKlasa> podaci = new BindingList<FunkcijaKlasa>();

        public static BindingList<FunkcijaKlasa> Podaci { get => podaci; set => podaci = value; }
    }
}
