using KonkretneKlase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.KonkretneKlase
{
    [TestFixture]
    class FunkcijaKlasaTest
    {
        
        [Test]
        public void SifraPdTest()
        {
            Assert.DoesNotThrow(() => new FunkcijaKlasa().sifrapd = "ns");
            Assert.AreEqual(new FunkcijaKlasa().sifrapd, new FunkcijaKlasa().sifrapd);
        }

        [Test]
        public void NazivPdTest()
        {
            Assert.DoesNotThrow(() => new FunkcijaKlasa().nazivpd = "Novi Sad");
            Assert.AreEqual(new FunkcijaKlasa().nazivpd, new FunkcijaKlasa().nazivpd);
        }

        [Test]
        public void VremeProracunaPdTest()
        {
            Assert.DoesNotThrow(() => new FunkcijaKlasa().vremeproracuna = DateTime.Now);
            Assert.AreEqual(new FunkcijaKlasa().vremeproracuna, new FunkcijaKlasa().vremeproracuna);
        }

        [Test]
        public void PoslednjeVremePdTest()
        {
            Assert.DoesNotThrow(() => new FunkcijaKlasa().poslednjevreme = DateTime.Now);
            Assert.AreEqual(new FunkcijaKlasa().poslednjevreme, new FunkcijaKlasa().poslednjevreme);
        }

        [Test]
        public void VrednostTest()
        {
            Assert.DoesNotThrow(() => new FunkcijaKlasa().vrednost = 45);
            Assert.AreEqual(new FunkcijaKlasa().vrednost, new FunkcijaKlasa().vrednost);
        } 
    }
}
