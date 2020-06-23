using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Fifa
{
    class Program
    {
        static List<Fifa> FifaList;
        static List<int> ValtozasList;
        static void Main(string[] args)
        {
            Console.WriteLine("\n----------------------------\n");
            Feladat2Beolvasas(); Console.WriteLine("\n----------------------------\n");
            Feladat3CsapatokSzama(); Console.WriteLine("\n----------------------------\n");
            Feladat4PontszamAtlag(); Console.WriteLine("\n----------------------------\n");
            Feladat5LegtobbValt(); Console.WriteLine("\n----------------------------\n");
            Feladat6Magyar(); Console.WriteLine("\n----------------------------\n");
            Feladat7Statisztika(); Console.WriteLine("\n----------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat7Statisztika()
        {
            Console.WriteLine("7.Feladat: statisztikát a helyezések változása (Va1tozas)\n\talapján csoportosítva a csapatok számáról a minta szerint\n");
            ValtozasList = new List<int>();
            foreach (var f in FifaList)
            {
                if(!ValtozasList.Contains(f.Valtozas))
                {
                    ValtozasList.Add(f.Valtozas);
                }
            }
            foreach (var v in ValtozasList)
            {
                int db = 0;
                foreach (var f in FifaList)
                {
                    if(v==f.Valtozas)
                    {
                        db++;
                    }
                }
                if(db>1)
                {
                    Console.WriteLine("\t{0,-2} -> {1}",v,db);
                }
               
            }

        }

        private static void Feladat6Magyar()
        {
            Console.WriteLine("6.Feladat: forrásállományban megtalálható-e Magyarország csapata");
            int db = 0;
            foreach (var f in FifaList)
            {
                if(f.Csapat.ToLower()=="magyarorszag")
                {
                    db++;
                }
            }
            if(db>0)
            {
                Console.WriteLine("\tVan Magyarországnak csapata");
            }
            else
            {
                Console.WriteLine("\tNem található Magyarország csapata");
            }
        }

        private static void Feladat5LegtobbValt()
        {
            Console.WriteLine("5.Feladat: legtobbet javító (VaItozas) csapat adatai");
            int MaxValtozas = int.MinValue;
            string MaxCsapa = "cica";
            int MaxPont = 0;
            int MaxHelyezes = 0;
            foreach (var f in FifaList)
            {
                if(MaxValtozas<f.Valtozas)
                {
                    MaxValtozas = f.Valtozas;
                    MaxCsapa = f.Csapat;
                    MaxHelyezes = f.Helyezes;
                    MaxPont = f.Pontszam;
                }
            }
            Console.WriteLine("\tA legtöbbet javító csapat adatai:\n\tCsapat: {0}\n\tHelyezése: {1}\n\tPontszáma: {2}", MaxCsapa, MaxHelyezes, MaxPont);
        }

        private static void Feladat4PontszamAtlag()
        {
            Console.WriteLine("4.Feladat: a ranglistán szereplő csapatok pontszámának átlaga");
            double Osszeg = 0;
            double Atlag = 0;
            foreach (var f in FifaList)
            {
                Osszeg += f.Pontszam;
                Atlag = Osszeg / FifaList.Count;
            }
            Console.WriteLine("\tA listában szereplő csapatok pontszámának átlaga: {0:0.00}", Atlag);
        }

        private static void Feladat3CsapatokSzama()
        {
            Console.WriteLine("3.Feladat: a csapatok száma");
            Console.WriteLine("\tAz állományban szereplő csapatok száma: {0} csapat", FifaList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat: Adatok beolvasása");
            FifaList = new List<Fifa>();
            var sr = new StreamReader(@"fifa.txt", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                db++;
                FifaList.Add(new Fifa(sr.ReadLine()));
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tBeolvasás sikeres, beolvasott sorok száma: {0}",db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás, próbálja újra");
            }
        }
    }
}
