using Functions;
using KonkretneKlase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Functions
{
    [TestFixture]
    class PodaciListaTest
    {
        [Test]
        public void PodaciTest()
        {
            Assert.DoesNotThrow(() => PodaciLista.Podaci = new BindingList<FunkcijaKlasa>());
            Assert.AreEqual(PodaciLista.Podaci, PodaciLista.Podaci);
        }
    }
}
