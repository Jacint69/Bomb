using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Csatater cs = new Csatater('K', 'H','X',"bemenet-5x5.txt");
            Bomba uresbomba=new UresBomba();
            Bomba kisbomba = new KisBomba();
            Bomba kozepesbomba = new KozepesBomba();
            Bomba nagybomba = new NagyBomba();
            IBomba[] bombak = new IBomba[4] {kisbomba, kozepesbomba, nagybomba, uresbomba};
            int[,]e=new int[cs.csatater.GetLength(0), cs.csatater.GetLength(0)];
            int[,] josag = new int[cs.csatater.GetLength(0), cs.csatater.GetLength(0)];

            bool van = false;
            cs.BackTrack(bombak, 0, 0, e, ref van, josag);
            
            for (int i = 0; i < josag.GetLength(0); i++)
            {
                for (int j = 0; j < josag.GetLength(0); j++)
                {
                    Console.Write(josag[i,j] + " ");
                }
                Console.WriteLine();
            }
           
            Console.ReadKey();
            
        }
    }
}
