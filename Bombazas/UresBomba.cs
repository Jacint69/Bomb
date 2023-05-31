using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
     class UresBomba:Bomba
    {
        
            public override string Meret { get; }
            public override int Ar { get; }
            public override int Suly { get; }
            public UresBomba()
            {
                Meret = "0x0";
                Ar = 0;
                Suly = 0;
            }
        
    }
}
