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
        static void Main(string[] args)
        {
            //Új Gyaki mappa 2023 emelt infó progizás feladatsorból

            #region 1. Feladat Bence

            //Alapok a fájl beolvasásához
            StreamReader sr = new StreamReader("kep.txt");
            int szelesseg = 640;
            int magassag = 360;
            int[,,] matrix = new int[szelesseg, magassag, 3];

            for(int i = 0; i < szelesseg; i++)
            {
                string egySor = sr.ReadLine();
                //Átmenetileg tárolja az RGB infókat ez a tömb
                string[] tomb=egySor.Split(' ');
                int magassagIndex = 0;  
                for(int j = 0; j < tomb.Length; j+=3)
                {
                    matrix[i, magassagIndex, 0] = int.Parse(tomb[j]);
                    matrix[i, magassagIndex, 1] = int.Parse(tomb[j+1]);
                    matrix[i, magassagIndex, 2] = int.Parse(tomb[j+2]);
                    magassagIndex++;
                }
            }


            #endregion
            Console.ReadLine();
        }
    }
}
