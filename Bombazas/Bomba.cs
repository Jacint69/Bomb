using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
    public abstract class Bomba : IBomba
    {
        public abstract string Meret { get; }
        public abstract int Ar { get;}
        public abstract int Suly { get;}
    }
}
