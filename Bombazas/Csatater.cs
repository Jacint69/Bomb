using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombazas
{
    public class Csatater
    {
        public char[,] csatater { get; set; }
        public char[,] _csatater { get; }
        
        public char katonaKarakter;
        public char epuletKarakter;
        public char uresKarakter;
        public int katona;
        public int epulet;
        public int ures;

        
        public Csatater(char katonaKarakter, char epuletKarakter, char uresKarakter, string filename)
        {
            var txt = File.ReadAllLines(filename);
            int n = txt.Length;
            csatater = new char[n, n];
            _csatater = new char[n, n];
            this.katonaKarakter = katonaKarakter;
            this.epuletKarakter = epuletKarakter;
            this.uresKarakter = uresKarakter;
            //Csatater feltöltése txt-ből
            for (int i = 0; i < csatater.GetLength(0); i++)
            {
                for (int j = 0; j < csatater.GetLength(1); j++)
                {
                    _csatater[i, j] = txt[i][j];
                }
            }
            CsataterMasolas();

        }
        //Csatater masolasa temp változoba
        private void CsataterMasolas()
        {
            for (int i = 0; i < csatater.GetLength(0); i++)
            {
                for (int j = 0; j < csatater.GetLength(1); j++)
                {
                    csatater[i, j] = _csatater[i, j];
                }
            }
        }
        
        //Ledobott bombák árainak számítása
        private int KoltsegSzamolas(int[,] e)
        {
            int db = 0;
            for (int i = 0; i < e.GetLength(0); i++)
            {
                for (int j = 0; j < e.GetLength(1); j++)
                {
                    switch (e[i,j])
                    {
                        case 3:
                            db += 1;
                            break;
                        case 5:
                            db += 4;
                            break;
                        case 10:
                            db += 15;
                            break;
                        case 0:
                                db += 0;
                            break;
                    }
                }
            }
            return db;
        }

        //Bt
        public void BackTrack(IBomba[] r, int sor, int oszlop, int[,] e, ref bool van, int[,] josag)
        {
            int i = -1;
            while (i < r.Length - 1)
            {
                i++;
                if (Fk(i,e, sor,oszlop, r))
                {
                    
                    if (katona+epulet==0 && (!van ||KoltsegSzamolas(e) < KoltsegSzamolas(josag)))
                    {
                        
                        for (int k = 0; k < e.GetLength(0); k++)
                        {
                            for (int f = 0; f < e.GetLength(0); f++)
                            {
                                josag[k,f] = e[k, f];
                            }
                        }
                        Console.WriteLine(KoltsegSzamolas(e));
                        van = true;
                    }
                    else
                    {
                        if (sor % 2 == 0)
                        {
                            

                            if (sor + 1 == csatater.GetLength(0) && oszlop == csatater.GetLength(0) - 1)
                            {
                            }

                            else if (oszlop == csatater.GetLength(0) - 1)
                            {
                                BackTrack(r, sor + 1, csatater.GetLength(0)-1, e, ref van, josag);
                            }
                            else
                            {
                                BackTrack(r, sor, oszlop + 1, e, ref van, josag);
                            }
                        }
                        else
                        {
                            if (sor + 1 == csatater.GetLength(0) && oszlop == csatater.GetLength(0) - 1)
                            {
                            }

                            else if (oszlop == 0)
                            {
                                BackTrack(r, sor + 1, 0, e, ref van, josag);
                            }
                            else
                            {
                                BackTrack(r, sor, oszlop -1, e, ref van, josag);
                            }

                        }
                    }
                }
            }
        }
        //Ellenséges csapatok számolása
        private void CsataterSzamlalo()
        {
            epulet = 0;
            katona = 0;

            for (int i = 0; i < csatater.GetLength(0); i++)
            {
                for (int j = 0; j < csatater.GetLength(1); j++)
                {
                    if (csatater[i,j]==katonaKarakter)
                    {
                        katona++;
                    }
                    else if (csatater[i,j]==epuletKarakter)
                    {
                        epulet++;
                    }
                }
            }
        }
        //Súly mérése, eredmény feltöltése
        public bool Fk(int szint, int[,] e, int sor, int oszlop, IBomba[] r)
        {
           
            int suly = 0;

            if (sor%2==0)
            {
                for (int i = 0; i < e.GetLength(0); i++)
                {
                    for (int j = 0; j < e.GetLength(0); j++)
                    {
                        if (i < sor)
                        {
                            suly += e[i, j];
                        }
                        else if (i == sor && j <= oszlop)
                        {
                            suly += e[i, j];
                        }
                    }
                }
            }
            else
            {
                for (int i = e.GetLength(0)-1; i >=0; i--)
                {
                    for (int j = e.GetLength(0)-1; j >=0; j--)
                    {
                        if (i < sor)
                        {
                            suly += e[i, j];
                        }
                        else if (i == sor && j >= oszlop)
                        {
                            suly += e[i, j];
                        }
                    }
                }
            }
           
            suly -= e[sor, oszlop];
            

           

            return SulySzamlalas(szint,e,sor,oszlop,r,suly);
        }
        public bool SulySzamlalas(int szint, int[,] e, int sor, int oszlop, IBomba[] r, int suly)
        {
            
            bool lehet = true;
            if (suly + r[szint].Suly > 25)
            {
                lehet = false;
            }
            else
            {
                e[sor, oszlop] = r[szint].Suly;
                CsataterMasolas();
                switch (szint)
                {
                    case 0:
                        for (int j = sor - 1; j < sor - 1 + 3; j++)
                        {
                            for (int k = oszlop - 1; k < oszlop - 1 + 3; k++)
                            {
                                if (!(j < 0 || k < 0 || j > this.csatater.GetLength(0) - 1 || k > this.csatater.GetLength(0) - 1))
                                {
                                    this.csatater[j, k] = uresKarakter;
                                }
                            }
                        }
                        CsataterSzamlalo();
                        break;
                    case 1:
                        for (int j = sor - 2; j < sor - 2 + 5; j++)
                        {
                            for (int k = oszlop - 2; k < oszlop - 2 + 5; k++)
                            {
                                if (!(j < 0 || k < 0 || j > this.csatater.GetLength(0) - 1 || k > this.csatater.GetLength(0) - 1))
                                {
                                    this.csatater[j, k] = uresKarakter;
                                }
                            }
                        }
                        CsataterSzamlalo();
                        break;
                    case 2:
                        for (int j = sor - 4; j < sor - 4 + 10; j++)
                        {
                            for (int k = oszlop - 5; k < oszlop - 5 + 10; k++)
                            {
                                if (!(j < 0 || k < 0 || j > this.csatater.GetLength(0) - 1 || k > this.csatater.GetLength(0) - 1))
                                {
                                    this.csatater[j, k] = uresKarakter;
                                }
                            }
                        }
                        CsataterSzamlalo();
                        break;
                    case 3:
                        CsataterSzamlalo();
                        break;


                
                }
                
            }
            return lehet;
        }
    }
}
