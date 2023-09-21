using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyaki4
{

    internal class Program
    {
        public static int[,] KetDMatrix=new int[1000, 8];
        public static int MatrixIndex = 0;
        public static List<string> Rendszamlista = new List<string>();

        static void Main(string[] args)
        {
            //Gyaki 4 2022 Idegen infó érettségi: Szakaszseb. ell.

            #region 1.Feladat
            StreamReader sr = new StreamReader("meresek.txt");

            while (!sr.EndOfStream)
            {
                string[]EgySorAdatai=sr.ReadLine().Split(' ');
                for (int i = 1;i<EgySorAdatai.Length;i++)
                {
                    KetDMatrix[MatrixIndex, i-1] = int.Parse(EgySorAdatai[i]);
                }
                MatrixIndex++;
                Rendszamlista.Add(EgySorAdatai[0]);
            }
            Console.WriteLine("{0}", Rendszamlista[1]);
            #endregion

            #region 2.Feladat
            Console.WriteLine("A mérés során {0} jármű adatait rögzítették.",MatrixIndex);

            #endregion


            #region 3.Feladat
            int elhaladt = 0;
            for (int i = 0;i<MatrixIndex;i++)
            {
                if (KetDMatrix[i, 4] < 9)
                {
                    elhaladt++;
                }
            }
            Console.WriteLine("9 óra előtt {0} jármű haladt el a végpontnál.",elhaladt);
            #endregion

            #region 4.Feladat
            int bekertOra, bekertPerc;
            Console.Write("Adjon meg egy óra, perc értéket: ");
            bekertOra=int.Parse(Console.ReadLine());
            Console.Write("Adjon meg egy percet: ");
            bekertPerc = int.Parse(Console.ReadLine());
            int eredmeny = 0;
            for (int i = 0; i<MatrixIndex;i++)
            {
                if (KetDMatrix[i,1] ==bekertPerc&& KetDMatrix[i, 0] == bekertOra)
                {
                    eredmeny++;
                }
            }
            Console.WriteLine("Kezdeti mérőpontnál elhaladt járművek száma: {0}",eredmeny);
            #endregion

            #region 5.Feladat

            #endregion
            Console.ReadLine();
        }
    }
}
