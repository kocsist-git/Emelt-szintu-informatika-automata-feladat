using System;
using System.Collections.Generic;
using System.IO;

namespace automata
{
    class csoki
    {
        public int rekesz;
        public int db;
        public int ar;
    }
    class vasarlas
    {
        public int rekesz;
        public int db;
        public int c_1;
        public int c_2;
        public int c_5;
        public int c_10;
        public int c_20;
        public int c_50;
        public int c_100;
    }
    class Program
    {
        public static List<csoki> csokik = new List<csoki>();
        public static List<vasarlas> vasarlasok = new List<vasarlas>();
        static void Main(string[] args)
        {
            task1("csoki.txt");
            task1_2 ("vasarlas.txt");
            task2();
            task3();
            task4();
            task5();
            task6();
        }

        private static void task6()
        {

            int csokikSzama = csokik[6].db;
            StreamWriter sw = new StreamWriter("rekesz7.txt");

            for (int i = 0; i < vasarlasok.Count; i++)
            {
                if (vasarlasok[i].rekesz==7)
                {
                    if (csokikSzama>=vasarlasok[i].db)
                    {
                        if (csokik[6].ar*vasarlasok[i].db<=(vasarlasok[i].c_1*1)+ (vasarlasok[i].c_2 * 2)+ (vasarlasok[i].c_5 * 5)+ (vasarlasok[i].c_10 * 10)+ (vasarlasok[i].c_20 * 20)+ (vasarlasok[i].c_50 * 50)+ (vasarlasok[i].c_100 * 100))
                        {
                            csokikSzama -= vasarlasok[i].db;
                            sw.WriteLine(i+1 +"\t"+ vasarlasok[i].db);
                        }
                        else { sw.WriteLine("Nem volt elég pénz"); }
                    }
                    else
                    {
                        sw.WriteLine("Kevés a csoki!");
                    }
                }
            }


            sw.Flush();
            sw.Close();
        }

        private static void task5()
        {
            Console.Write("\n5. Feladat\nKérek egy sorszámot: ");
            int sorszam = int.Parse(Console.ReadLine());
            Console.Write("Kérek egy darabszámot: ");
            int db = int.Parse(Console.ReadLine());

            int fizetendo = csokik[sorszam - 1].ar * db;

            int[] cimletek = new int[] { 1, 2, 5, 10, 20, 50, 100 };
            int[] dimletek = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            ujra:
            for (int i = cimletek.Length-1; i != 0; i--)
            {
                if (fizetendo >= cimletek[i])
                {
                    fizetendo -= cimletek[i];
                    dimletek[i]++;
                    goto ujra;
                }
            }
            
                Console.WriteLine("1 : "+ dimletek[0]);
                Console.WriteLine("2 : "+ dimletek[1]);
                Console.WriteLine("5 : "+ dimletek[2]);
                Console.WriteLine("10 : "+ dimletek[3]);
                Console.WriteLine("20 : "+ dimletek[4]);
                Console.WriteLine("50 : "+ dimletek[5]);
                Console.WriteLine("100 : "+ dimletek[6]);
           
        }

        private static void task4()
        {
            Console.Write("\n4. Feladat\nKérek egy pénzösszeget: ");
            int osszeg = int.Parse(Console.ReadLine());
            Console.Write("\nA következő rekeszekből választhat: ");
            foreach (var item in csokik)
            {
                if (item.db >= 7 && item.ar * 7 <= osszeg) Console.Write(item.rekesz + " ");
            }
        }

        private static void task3()
        {
            HashSet<int> rekeszek = new HashSet<int>();
            foreach (var item in vasarlasok)
            {
                rekeszek.Add(item.rekesz);
            }
            Console.Write("\n3. Feladat\nEzekből a rekeszekből próbáltak vásárolni: ");
            foreach (var item in rekeszek)
            {
                Console.Write(item + " ");
            }
        }

        private static void task2()
        {
            int ertek = 0;
            for (int i = 0; i < csokik.Count; i++)
            {
                ertek += csokik[i].db * csokik[i].ar;

            }
            Console.WriteLine("2. Feladat\nAz automatában {0} fabatka értékű csokoládé van.", ertek);
        }

        private static void task1(string fName)
        {
            StreamReader sr = new StreamReader(fName);
            int rekeszekSzama = int.Parse(sr.ReadLine());

            while (!sr.EndOfStream)
            {
                string ujSor = sr.ReadLine();
                string[] temp = ujSor.Split(" ");
                csoki a = new csoki();
                a.rekesz = int.Parse(temp[0]);
                a.db = int.Parse(temp[1]);
                a.ar = int.Parse(temp[2]);
                csokik.Add(a);
            }
            sr.Close();
        }
        private static void task1_2(string fName)
        {
            StreamReader sr = new StreamReader(fName);
            int vasarlasokSzama = int.Parse(sr.ReadLine());

            while (!sr.EndOfStream)
            {
                string ujSor = sr.ReadLine();
                string[] temp = ujSor.Split(" ");
                vasarlas a = new vasarlas();
                a.rekesz = int.Parse(temp[0]);
                a.db = int.Parse(temp[1]);
                a.c_1 = int.Parse(temp[2]);
                a.c_2 = int.Parse(temp[3]);
                a.c_5 = int.Parse(temp[4]);
                a.c_10 = int.Parse(temp[5]);
                a.c_20 = int.Parse(temp[6]);
                a.c_50 = int.Parse(temp[7]);
                a.c_100 = int.Parse(temp[8]);
                vasarlasok.Add(a);
            }
            sr.Close();
        }
    }
}
