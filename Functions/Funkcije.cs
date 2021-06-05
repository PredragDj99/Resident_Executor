using Common.DAO;
using Common.Functions;
using Common.KonkretneKlase;
using DAO;
using DAO.UpisUBazu;
using KonkretneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Funkcije : IFunkcije
    {
        public bool CalculationFunction1(List<string> sifre, IVratiListuIzmerenihPoSifri vlips, IUpisiMinimalno um, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps)
        {
            bool prosao = false;
            List<IIzmereno> iz = new List<IIzmereno>();
            foreach (string s in sifre)
            {
                iz = vlips.ListaPoSifri(s);
                if (!iz.Any())
                {
                    continue;       //OVO JE RASCLANJENO DA NE BIH RADIO PROVERU DA LI VREME POSTOJI ZA OVO JER AKO POSOTJI SIFRA POSTOJI I VREME
                }
                if (Provera("minimalna", s, vnkivps, vnkifvps))
                {
                    continue;
                }

                var min = iz[0];
                foreach (Izmereno item in iz)
                {
                    if (item.vrednost < min.vrednost)
                    {
                        min = item;
                    }
                }

                FunkcijaKlasa vrednost = new FunkcijaKlasa();

                vrednost.sifrapd = min.sifrapd;
                vrednost.nazivpd = min.nazivpd;
                vrednost.vremeproracuna = DateTime.Now;
                vrednost.poslednjevreme = vnkivps.VratiVreme(min.sifrapd);
                vrednost.vrednost = min.vrednost;
                prosao = true;
                um.Upisi(vrednost);

            }
            return prosao;
        }


        public bool CalculationFunction2(List<string> sifre, IVratiListuIzmerenihPoSifri vlips, IUpisiMaximalno um, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps)
        {
            bool prosao = false;
            List<IIzmereno> iz = new List<IIzmereno>();
            foreach (string s in sifre)
            {
                iz = vlips.ListaPoSifri(s);
                if (!iz.Any())
                {
                    continue;       //OVO JE RASCLANJENO DA NE BIH RADIO PROVERU DA LI VREME POSTOJI ZA OVO JER AKO POSOTJI SIFRA POSTOJI I VREME
                }
                if (Provera("maximalna", s, vnkivps, vnkifvps))
                {
                    continue;
                }

                var max = iz[0];
                foreach (Izmereno item in iz)
                {
                    if (item.vrednost > max.vrednost)
                    {
                        max = item;
                    }
                }

                FunkcijaKlasa vrednost = new FunkcijaKlasa();

                vrednost.sifrapd = max.sifrapd;
                vrednost.nazivpd = max.nazivpd;
                vrednost.vremeproracuna = DateTime.Now;
                vrednost.poslednjevreme = vnkivps.VratiVreme(max.sifrapd);
                vrednost.vrednost = max.vrednost;
                prosao = true;
                um.Upisi(vrednost);
            }
            return prosao;

        }
        public bool CalculationFunction3(List<string> sifre, IVratiListuIzmerenihPoSifri vlips, IUpisiDevijacija ud, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps)
        {
            bool prosao = false;
            List<IIzmereno> iz = new List<IIzmereno>();
            foreach (string s in sifre)
            {
                iz = vlips.ListaPoSifri(s);
                if (!iz.Any())
                {
                    continue;       //OVO JE RASCLANJENO DA NE BIH RADIO PROVERU DA LI VREME POSTOJI ZA OVO JER AKO POSOTJI SIFRA POSTOJI I VREME
                }
                if (Provera("devijacija", s, vnkivps, vnkifvps))
                { 
                    continue;
                }

                List<double> lista = new List<double>();
                foreach(var item in iz)
                {
                    lista.Add(item.vrednost);
                }

                double standardDeviation = 0;
                if(lista.Count() > 1)
                {
                    double avg = lista.Average();
                    double sum = lista.Sum(d => Math.Pow(d - avg, 2));
                    standardDeviation = Math.Sqrt((sum) / (lista.Count() - 1));
                }

                FunkcijaKlasa vrednost = new FunkcijaKlasa();

                vrednost.sifrapd = iz[0].sifrapd;
                vrednost.nazivpd = iz[0].nazivpd;
                vrednost.vremeproracuna = DateTime.Now;
                vrednost.poslednjevreme = vnkivps.VratiVreme(iz[0].sifrapd);
                vrednost.vrednost = standardDeviation;
                prosao = true;


                ud.Upisi(vrednost);
            }
            return prosao;
        }

        public bool Provera(string tabela, string s, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps)
        {
            bool radi = true;

            DateTime poslednjeUneto = vnkivps.VratiVreme(s);
            DateTime funkcijinoPoslednjeVreme = vnkifvps.VratiVreme(tabela, s);
            int result = DateTime.Compare(funkcijinoPoslednjeVreme, poslednjeUneto);

            if (result <= 0)
            {
                radi = false;
            }
            else
            {
                radi = true;
            }
                
            
            return radi;
        }

    }
}
