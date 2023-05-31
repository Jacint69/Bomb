using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
    public class KozepesBomba:Bomba
    {
        public override string Meret { get; }
        public override int Ar { get; }
        public override int Suly { get; }
        public KozepesBomba()
        {
            Meret = "5x5";
            Ar = 4;
            Suly = 5;
            
        }
    }
}
