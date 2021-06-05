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
    class IzmerenoTest
    {

        [Test]
        public void IdTest()
        {
            Assert.DoesNotThrow(() => new Izmereno().id = 1);
            Assert.AreEqual(new Izmereno().id, new Izmereno().id);
        }

        [Test]
        public void SifraPdTest()
        {
            Assert.DoesNotThrow(() => new Izmereno().sifrapd = "ns");
            Assert.AreEqual(new Izmereno().sifrapd, new Izmereno().sifrapd);
        }

        [Test]
        public void NazivTest()
        {
            Assert.DoesNotThrow(() => new Izmereno().nazivpd = "Novi Sad");
            Assert.AreEqual(new Izmereno().nazivpd, new Izmereno().nazivpd);
        }

        [Test]
        public void VrednostTest()
        {
            Assert.DoesNotThrow(() => new Izmereno().vrednost = 45);
            Assert.AreEqual(new Izmereno().vrednost, new Izmereno().vrednost);
        }

        [Test]
        public void DatumvremeTest()
        {
            Assert.DoesNotThrow(() => new Izmereno().datumvreme = DateTime.Now);
            Assert.AreEqual(new Izmereno().datumvreme, new Izmereno().datumvreme);
        }


    }
}
