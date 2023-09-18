using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gyaki2
{
    internal class Program
    {
        public const int teljesHossz = 200;
        public const int egysegIdo = 3;
        
        //3. feladat függvény
        public static int tav(int szalaghossz, int indulashelye, int erkezeshelye)
        {
            int SzallitasHossza = 0;
            if (indulashelye > erkezeshelye)
            {
                SzallitasHossza = szalaghossz - indulashelye+erkezeshelye;
            }
            else
            {
                SzallitasHossza=erkezeshelye - indulashelye;
            }
            return SzallitasHossza;
        }



        public static string listaKiiras(List<int> lista)
        {
            string eredmeny="";
            for (int i = 0; i < lista.Count; i++)
            {
                eredmeny += string.Format("{0}", lista[i])+" ";
            }
            return eredmeny;
        }



        static void Main(string[] args)
        {
            //Gyaki 2
            #region 1. Feladat 2023 Idegen

            string[] atmenetiTomb = File.ReadAllLines("szallit.txt");
            int sorokSzama=atmenetiTomb.Length;
            int[,] ketDMatrix = new int[sorokSzama, 4];
            
            for (int i = 1; i < sorokSzama; i++)
            {
                string[] feldarabolas = atmenetiTomb[i].Split(' ');
                for (int j = 0; j < 4; j++) 
                {
                    ketDMatrix[i, j] = int.Parse(feldarabolas[j]);
                }
            }
            #endregion

            #region 2.Feladat
            int SzallitasSzama;
            Console.WriteLine("Adja meg melyik adatsorra kíváncsi: ");
            SzallitasSzama=int.Parse(Console.ReadLine());
            Console.WriteLine("Honnan: {0} Hova: {1}", ketDMatrix[SzallitasSzama, 1], ketDMatrix[SzallitasSzama,2]);
            #endregion

            #region 3.Feladat

            #endregion

            #region 4.Feladat
            
            int LeghosszabbSzallitasTavja = 0;
            List<int> MaxSorszamok = new List<int>();
            int VaneTöbbMax = 0;
            //Végig megy az összeg soron és megnézi volt-e nagyobb megtett táv mint eddig
            for (int i = 1; i < sorokSzama;i++)
            {
                tav(teljesHossz, ketDMatrix[i, 1], ketDMatrix[i, 2]);
                if (tav(teljesHossz, ketDMatrix[i, 1], ketDMatrix[i, 2]) > LeghosszabbSzallitasTavja)
                {
                    LeghosszabbSzallitasTavja = tav(teljesHossz, ketDMatrix[i, 1], ketDMatrix[i, 2]);
                }

            }
            for (int i = 1;i < sorokSzama; i++)
            {
                if(tav(teljesHossz, ketDMatrix[i, 1], ketDMatrix[i, 2]) == LeghosszabbSzallitasTavja)
                {
                    MaxSorszamok.Add(i);
                }
            }

            Console.WriteLine("A leghosszabb szállítás távja: {0}",LeghosszabbSzallitasTavja);
            Console.WriteLine("A leghosszabb azonos távú szállítások sorszáma: {0}", listaKiiras(MaxSorszamok));


            #endregion

            #region 5.Feladat
            int tomeg = 0;
            for (int i = 1;i < sorokSzama; i++)
            {
                if (ketDMatrix[i, 1] > ketDMatrix[i, 2] && ketDMatrix[i, 1] != 0 && ketDMatrix[i, 1] != 0) 
                {
                    tomeg += ketDMatrix[i, 3];
                }
            }
            Console.WriteLine("A kezdőpnt előtt elhaladó rekeszek össztömege: {0}",tomeg);
            #endregion

            #region 6.Feladat

            int bekertIdoPont;
            Console.WriteLine("Adja meg a kívánt időpontot! ");
            bekertIdoPont = int.Parse(Console.ReadLine());

            List<int> utonLevoCsomagok = new List<int>();

            int adottKorStartPontja, adottKorEndPontja;
            string ures="";
            for (int i = 1; i < sorokSzama; i++)
            {
                adottKorStartPontja = ketDMatrix[i, 0];
                adottKorEndPontja = adottKorStartPontja + (tav(teljesHossz, ketDMatrix[i, 1], ketDMatrix[i, 2]) * 3);
                if (bekertIdoPont >= adottKorStartPontja && bekertIdoPont < adottKorEndPontja)
                {
                    utonLevoCsomagok.Add(i);
                }
            }
            if (utonLevoCsomagok.Count==0)
            {
                ures = "Üres";
            }

            Console.WriteLine("A szállított rekeszek sorszáma: {0} {1}",listaKiiras(utonLevoCsomagok),ures);

            #endregion

            #region 7.Feladat
            string txt = "tomeg.txt";
            string txtTartalom="";


            int[,] txtMatrix = new int[sorokSzama, 1];
            //List<int> KezdoHelyekLista = new List<int>();
           // List<int> tomeglista = new List<int>();
           List<int> KezdoHelyekEsTomegeik = new List<int>();

            for (int i = 1; i < sorokSzama; i++)
            {
                if (KezdoHelyekEsTomegeik.Contains(ketDMatrix[i, 1])==false)
                {
                    KezdoHelyekEsTomegeik.Add(ketDMatrix[i, 1]);
                    KezdoHelyekEsTomegeik.Add(ketDMatrix[i, 3]);
                }
                else if(KezdoHelyekEsTomegeik.Contains(ketDMatrix[i, 1]) == true)
                {
                    KezdoHelyekEsTomegeik.Insert(KezdoHelyekEsTomegeik.IndexOf(ketDMatrix[i, 1]) + 1, ketDMatrix[i,3]);
                }
            }

            int[] tombi= KezdoHelyekEsTomegeik.ToArray();
            int index = 0;
            for (int i = 0; i < sorokSzama-1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    txtMatrix[i, j] = tombi[index];
                    index++; //itt akadtam meg
                }
            }

            File.WriteAllText(txt, txtTartalom);

            #endregion

            /*#region Mátrix teszt
            Console.WriteLine("A Mátrix: ");
            for (int i = 1; i < sorokSzama;i++)
            {
                for (int j = 0;j < 4; j++)
                {
                    Console.Write(ketDMatrix[i, j]+ " ");
                }
            }
#endregion*/
            Console.ReadLine();
        }
    }
}
