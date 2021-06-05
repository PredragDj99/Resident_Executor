using Common.DAO;
using Common.ResidentExecutor;
using DAO;
using DAO.UpisUBazu;
using Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class Caller : ICaller
    {
        public bool funkc1 { get; set; }
        public  bool funkc2 { get; set; }
        public  bool funkc3 { get; set; }

        public void Call()
        {
            
            string startupPath = Environment.CurrentDirectory;
            string filePath = startupPath.Remove(startupPath.Count() - 27);
            filePath = filePath + "FileSystem/rezidentne_funkcije.csv";

            using (var reader = new StreamReader(filePath))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }

                for (int i = 0; i < listA.Count; i++)
                {
                    if (Int32.TryParse(listA[i], out int n) && Int32.TryParse(listB[i], out int f))
                    {
                        switch (n)
                        {
                            case 1: funkc1 = (f == 1) ? true : false; break;
                            case 2: funkc2 = (f == 1) ? true : false; break;
                            case 3: funkc3 = (f == 1) ? true : false; break;
                            default: break;
                        }
                    }
                }



            }

            Thread t = new Thread(FunctionCall);
            t.IsBackground = true;
            t.Start();
        }

     


        public void FunctionCall()
        {

            while (true)
            {
                
                if (funkc1)
                {
                    List<string> sifre = new VratiListu().VratiListuSifra();
                    IVratiListuIzmerenihPoSifri vlips = new VratiListuIzmerenihPoSifri();
                    IVratiNajkasnijeIzmerenoVremePoSifri izm = new VratiNajkasnijeIzmerenoVremePoSifri();
                    IVratiNajkasnijeFunkcVremePoSifri funkvreme = new VratiNajkasnijeFunkcVremePoSifri();
                    IUpisiMinimalno min = new UpisiMinimalno();
                    new Funkcije().CalculationFunction1(sifre, vlips, min, izm, funkvreme);
                }
                if (funkc2)
                {
                    List<string> sifre = new VratiListu().VratiListuSifra();
                    IVratiListuIzmerenihPoSifri vlips = new VratiListuIzmerenihPoSifri();
                    IVratiNajkasnijeIzmerenoVremePoSifri izm = new VratiNajkasnijeIzmerenoVremePoSifri();
                    IVratiNajkasnijeFunkcVremePoSifri funkvreme = new VratiNajkasnijeFunkcVremePoSifri();
                    IUpisiMaximalno max = new UpisiMaximalno();
                    new Funkcije().CalculationFunction2(sifre, vlips, max, izm, funkvreme);
                }
                if (funkc3)
                {
                    List<string> sifre = new VratiListu().VratiListuSifra();
                    IVratiListuIzmerenihPoSifri vlips = new VratiListuIzmerenihPoSifri();
                    IVratiNajkasnijeIzmerenoVremePoSifri izm = new VratiNajkasnijeIzmerenoVremePoSifri();
                    IVratiNajkasnijeFunkcVremePoSifri funkvreme = new VratiNajkasnijeFunkcVremePoSifri();
                    IUpisiDevijacija dev = new UpisiDevijacija();
                    new Funkcije().CalculationFunction3(sifre, vlips, dev, izm, funkvreme);
                }
                Thread.Sleep(10000);

            }



        }

    }
}
