using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyaki
{
    internal class Program
    {
        //Átalakítottam egy kicsit OOP központúvabbá, így a változókat már bárhonnan elérheted és
        //használhatod őket.
        public const int szelesseg = 640;
        public const int magassag = 360;
        public static int[,,] matrix = new int[magassag, szelesseg, 3];
        public static void Main(string[] args)
        {

            //Új Gyaki mappa 2023 emelt infó progizás feladatsorból

            #region 1. Feladat Bence

            //Alapok a fájl beolvasásához
            StreamReader sr = new StreamReader("kep.txt");


            for (int i = 0; i < magassag; i++)
            {
                string egySor = sr.ReadLine();
                //Átmenetileg tárolja az RGB infókat ez a tömb
                string[] tomb = egySor.Split(' ');
                int szelessegIndex = 0;
                for (int j = 0; j < tomb.Length; j += 3)
                {
                    matrix[i, szelessegIndex, 0] = int.Parse(tomb[j]);
                    matrix[i, szelessegIndex, 1] = int.Parse(tomb[j + 1]);
                    matrix[i, szelessegIndex, 2] = int.Parse(tomb[j + 2]);
                    szelessegIndex++;
                }
            }


            #endregion
            #region 2. feladat

            Console.Write("Sor:");
            int sorIndex = int.Parse(Console.ReadLine());
            Console.Write("Oszlop:");
            int oszlopIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("A képpont színe RGB({0},{1},{2})", matrix[oszlopIndex, sorIndex, 0], matrix[oszlopIndex, sorIndex, 1], matrix[oszlopIndex, sorIndex, 2]);

            #endregion
            #region 3. feladat
            int VilagosKeppontokSzama = 0;
            int RGBOsszeg = 0;
            for (int i = 0; i < magassag; i++)
            {
                for (int j = 0; j < szelesseg; j++)
                {
                    RGBOsszeg += matrix[i, j, 0] + matrix[i, j, 1] + matrix[i, j, 2];
                    if (RGBOsszeg > 600)
                        VilagosKeppontokSzama++;
                    RGBOsszeg = 0;
                }
            }
            Console.WriteLine("3. feladat:");
            Console.WriteLine("A világos képpontok száma: {0}", VilagosKeppontokSzama);
            #endregion
            #region 4. feladat

            int minÖsszeg = int.MaxValue;

            for (int i = 0; i < magassag; i++)
            {
                for (int j = 0; j < szelesseg; j++)
                {
                    RGBOsszeg = 0;
                    RGBOsszeg += matrix[i, j, 0] + matrix[i, j, 1] + matrix[i, j, 2];
                    if (minÖsszeg > RGBOsszeg)
                        minÖsszeg = RGBOsszeg;
                }//////
            }
            Console.WriteLine("4.Feladat:");
            Console.WriteLine("A legsötétebb pont RGB összege: {0}", minÖsszeg);
            Console.WriteLine("A legsötétebb pixelek színe:");

            for (int i = 0; i < magassag; i++)
            {
                for (int j = 0; j < szelesseg; j++)
                {
                    if (minÖsszeg == matrix[i, j, 0] + matrix[i, j, 1] + matrix[i, j, 2])
                        Console.WriteLine("RGB({0},{1},{2})", matrix[i, j, 0], matrix[i, j, 1], matrix[i, j, 2]);
                }
            }


            #endregion

            #region 5. Feladat

            #region Ezt nem kérte a feladat
            //A feladat szerint nincs tényleges bekérés!!!
            /*  int sorSzam, elteresErteke;
              Console.WriteLine("Adja meg az adott sor számát: ");
              sorSzam = int.Parse(Console.ReadLine());
              Console.WriteLine("Adja meg az eltérés értékének mennyiségét (1-255): ");
              elteresErteke = int.Parse(Console.ReadLine());

              if (elteresErteke < 1 && elteresErteke > 255)
              {
                  Console.WriteLine("A megadott érték a megszabott intervallumon kívül esik, adjon meg egy új értéket!");
                  Console.WriteLine("Adja meg az eltérés értékének mennyiségét (1-255): ");
                  elteresErteke = int.Parse(Console.ReadLine());
              }*/

            #endregion

            #region itt max tesztelheted, de a feladat nem kéri
            /*
            bool Igaz;
            Igaz = hatar(40, 10);
            if (Igaz)
            {
                Console.WriteLine("Volt ekkora eltérés, sőt talán nagyobb is!");

            }
            else
            {
                Console.WriteLine("Nem volt ekkora eltérés az adott sorban!");
            }
            */

            #endregion
            #endregion
            //Asztalos egy evangélikus faszlélek

            Console.ReadLine();
        }

        #region 5. feladat, ez csak a függvény
        public static bool hatar(int hatarsorSzam, int hatarelteresErteke)
        {
            bool eredmeny = false;
            int elsoKek;
            int masodikKek;

            //Mivel a következő elemet is nézed, az utolsó elemnél már 640+1. elemre fog hivatkozni, ezért ki fog mutatni a tömbből és 
            //IndexOutOfRangeException-t fogsz kapni
            //Itt kicseréltem a konstant változóra a 640-et, mivel már eléred bárhonnan így
            for (int i = 0; i < szelesseg-1; i++)
            {
                elsoKek = matrix[hatarsorSzam, i, 2];
                masodikKek = matrix[hatarsorSzam, i + 1, 2];
                if (Math.Abs(elsoKek - masodikKek) > hatarelteresErteke)
                {
                    eredmeny = true;
                }
            }
            return eredmeny;
        }
        #endregion
    }
}
