using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Gyaki3._1
{
    internal class Program
    {


        public static int arrayIndex = -1;
        public static int[,] array2D = new int[1000, 5];

        //3. feladat függvény
        public static int eltelt(List<int> innentol, List<int> idaig)
        {
            return (idaig[0] * 3600 + idaig[1] * 60 + idaig[2])- (innentol[0] * 3600 + innentol[1] * 60 + innentol[2]);
        }
        static void Main(string[] args)
        { 
            //Gyaki 3 2022 infó érettségi feladat: Jeladó

            #region 1. Feladat Milán Módra

            StreamReader sr = new StreamReader("jel.txt");

            
            while(!sr.EndOfStream)
            {
                arrayIndex++;
                string[] lineSplit = sr.ReadLine().Split(' ');
                //int dataIndex = 0;
                //foreach(string data in lineSplit)
                //{
                //    tomb2xD[tombIndex,dataIndex]=int.Parse(data);
                //    dataIndex++;
                //}
                for (int i = 0; i < lineSplit.Length; i++)
                {
                    array2D[arrayIndex, i] = int.Parse(lineSplit[i]);
                }
               
            }
            sr.Dispose();

            #endregion

            #region 2.Feladat
            Console.Write("Adja meg az adott sor számát: ");
            int sorSzam=int.Parse(Console.ReadLine());

            Console.WriteLine("Adott sor X és Y koordinátái: {0} {1}", array2D[sorSzam-1,3], array2D[sorSzam - 1, 4]);
            #endregion

            #region 3. és 4. Feladat

            List<int> innentol = new List<int>() { array2D[0,0],array2D[0,1], array2D[0,2] };
            List<int> idaig = new List<int>() { array2D[arrayIndex, 0], array2D[arrayIndex, 1], array2D[arrayIndex,2] };


            Console.WriteLine("{0}",eltelt(innentol,idaig));


            #endregion

            #region 5. Feladat
            int[] minXY = new int[2];
            int[] maxXY = new int[2];

            int Xtoltet =0; int Ytoltet =0;

            //Minimum keresés
            for (int i = 0;i < arrayIndex;i++) 
            {
                if (array2D[i,3] < Xtoltet && array2D[i, 4] < Ytoltet)
                {
                    Xtoltet = array2D[i,3];
                    Ytoltet = array2D[i,4];
                }
            }
            minXY[0] = Xtoltet; minXY[1] = Ytoltet;
            Xtoltet = 0; Ytoltet = 0;
            


            //Maximum keresés
            for (int i = 0; i < arrayIndex; i++)
            {
                if (array2D[i, 3] > Xtoltet&& array2D[i, 3] > Ytoltet)
                {
                    Xtoltet = array2D[i, 3];
                    Ytoltet = array2D[i, 4];
                }
            }
            maxXY[0] = Xtoltet; maxXY[1] = Ytoltet;
            Xtoltet = 0; Ytoltet = 0;

            Console.WriteLine("5. Feladat");
            Console.WriteLine("Bal alsó: {0} {1}, Jobb felső: {2} {3}", minXY[0], minXY[1], maxXY[0], maxXY[1]);
            #endregion


            Console.ReadLine();
        }
    }
}
