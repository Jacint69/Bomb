using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
    public class NagyBomba:Bomba
    {
        public override string Meret { get; }
        public override int Ar { get; }
        public override int Suly { get; }
        public NagyBomba()
        {
            Meret = "10x10";
            Ar = 15;
            Suly = 10;
        }
    }
}
