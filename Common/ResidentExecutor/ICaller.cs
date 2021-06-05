using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResidentExecutor
{
    public interface ICaller
    {
        bool funkc1 { get; set; }
        bool funkc2 { get; set; }
        bool funkc3 { get; set; }

        void Call();

        void FunctionCall();
    }
}
