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
            #region Mátrix teszt
            Console.WriteLine("A Mátrix: ");
            for (int i = 1; i < sorokSzama;i++)
            {
                for (int j = 0;j < 4; j++)
                {
                    Console.Write(ketDMatrix[i, j]+ " ");
                }
            }
            #endregion
            Console.ReadLine();
        }
    }
}
