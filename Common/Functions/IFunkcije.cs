using Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Functions
{
    public interface IFunkcije
    {

        bool CalculationFunction1(List<string> sifre, IVratiListuIzmerenihPoSifri vlips, IUpisiMinimalno um, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps);

        bool CalculationFunction2(List<string> sifre, IVratiListuIzmerenihPoSifri vlips, IUpisiMaximalno um, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps);

        bool CalculationFunction3(List<string> sifre, IVratiListuIzmerenihPoSifri vlips, IUpisiDevijacija ud, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps);
        
        bool Provera(string tabela, string s, IVratiNajkasnijeIzmerenoVremePoSifri vnkivps, IVratiNajkasnijeFunkcVremePoSifri vnkifvps);

    }

}