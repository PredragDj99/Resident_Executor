using Common.DAO;
using Common.Functions;
using Common.KonkretneKlase;
using DAO;
using DAO.UpisUBazu;
using Functions;
using KonkretneKlase;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Functions
{
    [TestFixture]
    class FunkcijeTest
    {
        Mock<IVratiListuIzmerenihPoSifri> listeposifri = new Mock<IVratiListuIzmerenihPoSifri>();
        Mock<IUpisiMinimalno> upisiminimalno = new Mock<IUpisiMinimalno>();
        Mock<IUpisiMaximalno> upisimaximalno = new Mock<IUpisiMaximalno>();
        Mock<IUpisiDevijacija> upisidevijacija = new Mock<IUpisiDevijacija>();
        Mock<IVratiNajkasnijeIzmerenoVremePoSifri> najskasnijeposifri = new Mock<IVratiNajkasnijeIzmerenoVremePoSifri>();
        Mock<IVratiNajkasnijeFunkcVremePoSifri> najkasnijeposifrifunkc = new Mock<IVratiNajkasnijeFunkcVremePoSifri>();


        IFunkcije testingObject;

        [SetUp]
        public void Funkcije()
        {
            testingObject = new Funkcije();

        }

        
        [Test]
        public void FunctionMinTestSuccessNoSkipIteration() //sve regularno
        {
            listeposifri.Reset();
            upisiminimalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Now;
            iz.vrednost = 45;
            List < IIzmereno > lista = new List<IIzmereno>();
            lista.Add(iz);
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("minimalna", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.CalculationFunction1(sifre, listeposifri.Object, upisiminimalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }


        [Test]
        public void FunctionMinTestFailEmptyListSifre() //kada ne postoji ni jendo podrucje u postojecim
        {
            listeposifri.Reset();
            upisiminimalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();


            List<string> sifre = new List<string>();
            List<IIzmereno> lista = new List<IIzmereno>();
            Assert.IsFalse(testingObject.CalculationFunction1(sifre, listeposifri.Object, upisiminimalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Never);

        }


        [Test]
        public void FunctionMinTestFailEmptyListIzmereno() // kada nema izmerene vrednosti za sifru
        {
            listeposifri.Reset();
            upisiminimalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();


            List<string> sifre = new List<string>();
            sifre.Add("ns");
            List<IIzmereno> lista = new List<IIzmereno>();                      //Kreira praznu listu
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);       //Kaze mu da to vraca
            Assert.IsFalse(testingObject.CalculationFunction1(sifre, listeposifri.Object, upisiminimalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once); //provera koliko puta je pozvao (to je sifre iz foreach)

        }

        [Test]
        public void FunctionMinTestFailProvera() //nece raditi jer je vec uradjeno
        {
            listeposifri.Reset();
            upisiminimalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Parse("7/10/1974 7:10:24 AM");
            iz.vrednost = 45;
            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);
            
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM")); //uneo
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("minimalna", "ns")).Returns(DateTime.Now);   //poslednj put odradila sada


            Assert.IsFalse(testingObject.CalculationFunction1(sifre, listeposifri.Object, upisiminimalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }


        [Test]
        public void FunctionMinTestSuccessSetMin() //dobije novu minimalnu
        {
            listeposifri.Reset();
            upisiminimalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            listeposifri = new Mock<IVratiListuIzmerenihPoSifri>();
            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Now;
            iz.vrednost = 45;



            Izmereno iz1 = new Izmereno();
            iz1.id = 3;
            iz1.sifrapd = "ns";
            iz1.nazivpd = "Novi Sad";
            iz1.datumvreme = DateTime.Now;
            iz1.vrednost = 31;


            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);
            lista.Add(iz1);
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("minimalna", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.CalculationFunction1(sifre, listeposifri.Object, upisiminimalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }

        //////////////////////////////////////////////////////////////////////////

        [Test]
        public void FunctionMaxTestSuccessNoSkipIteration()
        {
            listeposifri.Reset();
            upisimaximalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset(); 
            
            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Now;
            iz.vrednost = 45;
            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("maximalna", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.CalculationFunction2(sifre, listeposifri.Object, upisimaximalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }



        [Test]
        public void FunctionMaxTestFailEmptyListSifre()
        {
            listeposifri.Reset();
            upisimaximalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();


            List<string> sifre = new List<string>();
            List<IIzmereno> lista = new List<IIzmereno>();
            Assert.IsFalse(testingObject.CalculationFunction2(sifre, listeposifri.Object, upisimaximalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Never);

        }


        [Test]
        public void FunctionMaxTestFailEmptyListIzmereno()
        {
            listeposifri.Reset();
            upisimaximalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            List<IIzmereno> lista = new List<IIzmereno>();
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            Assert.IsFalse(testingObject.CalculationFunction2(sifre, listeposifri.Object, upisimaximalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }

        [Test]
        public void FunctionMaxTestFailProvera()
        {
            listeposifri.Reset();
            upisimaximalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Parse("7/10/1974 7:10:24 AM");
            iz.vrednost = 45;
            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);

            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("maximalna", "ns")).Returns(DateTime.Now);


            Assert.IsFalse(testingObject.CalculationFunction2(sifre, listeposifri.Object, upisimaximalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }


        [Test]
        public void FunctionMaxTestSuccessSetMax()
        {
            listeposifri.Reset();
            upisimaximalno.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();

            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Now;
            iz.vrednost = 45;



            Izmereno iz1 = new Izmereno();
            iz1.id = 3;
            iz1.sifrapd = "ns";
            iz1.nazivpd = "Novi Sad";
            iz1.datumvreme = DateTime.Now;
            iz1.vrednost = 700;


            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);
            lista.Add(iz1);
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("maximalna", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.CalculationFunction2(sifre, listeposifri.Object, upisimaximalno.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }


        ///////////////////////////////////////////////////////////////////////////

        [Test]
        public void FunctionDevTestSuccessNoSkipIteration()
        {
            listeposifri.Reset();
            upisidevijacija.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Now;
            iz.vrednost = 45;
            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("devijacija", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.CalculationFunction3(sifre, listeposifri.Object, upisidevijacija.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }

        [Test]
        public void FunctionDevTestFailEmptyListSifre()
        {
            listeposifri.Reset();
            upisidevijacija.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();


            List<string> sifre = new List<string>();
            List<IIzmereno> lista = new List<IIzmereno>();
            Assert.IsFalse(testingObject.CalculationFunction3(sifre, listeposifri.Object, upisidevijacija.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Never);

        }


        [Test]
        public void FunctionDevTestFailEmptyListIzmereno()
        {
            listeposifri.Reset();
            upisidevijacija.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();


            List<string> sifre = new List<string>();
            sifre.Add("ns");
            List<IIzmereno> lista = new List<IIzmereno>();
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            Assert.IsFalse(testingObject.CalculationFunction3(sifre, listeposifri.Object, upisidevijacija.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }

        [Test]
        public void FunctionDevTestFailProvera()
        {
            listeposifri.Reset();
            upisidevijacija.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();
            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Parse("7/10/1974 7:10:24 AM");
            iz.vrednost = 45;
            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);

            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("devijacija", "ns")).Returns(DateTime.Now);


            Assert.IsFalse(testingObject.CalculationFunction3(sifre, listeposifri.Object, upisidevijacija.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);

        }


        [Test]
        public void FunctionDevTestSuccessCalculate()  //devijacija radi kada ima 2 elem
        {
            listeposifri.Reset();
            upisidevijacija.Reset();
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            listeposifri = new Mock<IVratiListuIzmerenihPoSifri>();
            List<string> sifre = new List<string>();
            sifre.Add("ns");
            Izmereno iz = new Izmereno();

            iz.id = 2;
            iz.sifrapd = "ns";
            iz.nazivpd = "Novi Sad";
            iz.datumvreme = DateTime.Now;
            iz.vrednost = 45;



            Izmereno iz1 = new Izmereno();
            iz1.id = 3;
            iz1.sifrapd = "ns";
            iz1.nazivpd = "Novi Sad";
            iz1.datumvreme = DateTime.Now;
            iz1.vrednost = 31;


            List<IIzmereno> lista = new List<IIzmereno>();
            lista.Add(iz);
            lista.Add(iz1);
            listeposifri.Setup(t => t.ListaPoSifri("ns")).Returns(lista);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("devijacija", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.CalculationFunction3(sifre, listeposifri.Object, upisidevijacija.Object, najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            listeposifri.Verify(t => t.ListaPoSifri("ns"), Times.Once);



           



        }

        ///////////////////////////////////////////////////////////////////////////
        
        
        [Test]
        public void ProveraTestSuccess()
        {
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("minimalna","ns")).Returns(DateTime.Now);
            Assert.IsTrue(testingObject.Provera("minimalna", "ns", najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            najskasnijeposifri.Verify(t => t.VratiVreme("ns"), Times.Once);
            najkasnijeposifrifunkc.Verify(t => t.VratiVreme("minimalna", "ns"), Times.Once);

        }


        [Test]
        public void ProveraTestFail() //vraca false, funkcija treba da radi
        {
            najskasnijeposifri.Reset();
            najkasnijeposifrifunkc.Reset();

            najskasnijeposifri.Setup(t => t.VratiVreme("ns")).Returns(DateTime.Now);
            najkasnijeposifrifunkc.Setup(t => t.VratiVreme("minimalna", "ns")).Returns(DateTime.Parse("7/10/1974 7:10:24 AM"));
            Assert.IsFalse(testingObject.Provera("minimalna", "ns", najskasnijeposifri.Object, najkasnijeposifrifunkc.Object));
            najskasnijeposifri.Verify(t => t.VratiVreme("ns"), Times.Once);
            najkasnijeposifrifunkc.Verify(t => t.VratiVreme("minimalna", "ns"), Times.Once);
        }
    }
}
