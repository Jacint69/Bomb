using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
    public class KisBomba : Bomba
    {
        public override string Meret { get;}
        public override int Ar {get;}
        public override int Suly {get;}
        public KisBomba()
        {
            Meret = "3x3";
            Ar = 1;
            Suly = 3;
        }
    }
   
}
