using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAO
{
    public interface IDodajPostojanje
    {
        bool DodajPodrucje(string id, string naziv);
    }
}
