using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.res
{
    class Optimization : BazAlgoritm
    {
        private double prevE;
        public double[] E;
        public double[] k1;
        public double[] k2;
        public double[] KFE_max = new double[5];
        int[] radius = new int[5];
        double k1_X1_mid;
        double k2_X1_mid;
        double k1_X2_mid;
        double k2_X2_mid;
        double k1_X3_mid;
        double k2_X3_mid;
        double k1_X4_mid;
        double k2_X4_mid;
        double k1_X5_mid;
        double k2_X5_mid;

        public double[] E_max;
        public double[] k1_max;
        public double[] k2_max;
        Functions functions = new Functions();

        public Optimization(double[,] classX1, double[,] classX2, double[,] classX3, double[,] classX4, double[,] classX5) : base(classX1, classX2, classX3, classX4, classX5)
        {
        }
        public void main(string TYPE)
        {
            
            E = new double[classX1.GetLength(0)];
            k1 = new double[classX1.GetLength(0)];
            k2 = new double[classX1.GetLength(0)];

            for (int i = 0; i <= 100; i++)
            {
                base.alg(i);
                repeat(i);
            }



        }
        private void repeat(int i)
        {
        
            base.algFind_K_KFE();

            KFE_max[0] = functions.FindMaxCount(E_X1);
            KFE_max[1] = functions.FindMaxCount(E_X2);
            KFE_max[2] = functions.FindMaxCount(E_X3);
            KFE_max[3] = functions.FindMaxCount(E_X4);
            KFE_max[4] = functions.FindMaxCount(E_X5);

            radius[0] = functions.findWorkArea(k1_X1, k2_X1);
            radius[1] = functions.findWorkArea(k1_X2, k2_X2);
            radius[2] = functions.findWorkArea(k1_X3, k2_X3);
            radius[3] = functions.findWorkArea(k1_X4, k2_X4);
            radius[4] = functions.findWorkArea(k1_X5, k2_X5);

            k1_X1_mid = functions.isFindWorkArea(E_X1, KFE_max[0], k1_X1, radius[0]);
            k2_X1_mid = functions.isFindWorkArea(E_X1, KFE_max[0], k2_X1, radius[0]);
            k1_X2_mid = functions.isFindWorkArea(E_X2, KFE_max[1], k1_X2, radius[1]);
            k2_X2_mid = functions.isFindWorkArea(E_X2, KFE_max[1], k2_X2, radius[1]);
            k1_X3_mid = functions.isFindWorkArea(E_X3, KFE_max[2], k1_X3, radius[2]);
            k2_X3_mid = functions.isFindWorkArea(E_X3, KFE_max[2], k2_X3, radius[2]);
            k1_X4_mid = functions.isFindWorkArea(E_X4, KFE_max[3], k1_X4, radius[3]);
            k2_X4_mid = functions.isFindWorkArea(E_X4, KFE_max[3], k2_X4, radius[3]);
            k1_X5_mid = functions.isFindWorkArea(E_X5, KFE_max[4], k1_X5, radius[4]);
            k2_X5_mid = functions.isFindWorkArea(E_X5, KFE_max[4], k2_X5, radius[4]);



            //KFE_max[0] = radius[0] == 0 ? 0 : KFE_max[0];

            //KFE_max[1] = radius[1] == 0 ? 0 : KFE_max[1];

            //KFE_max[2] = radius[2] == 0 ? 0 : KFE_max[2];

            k1_sum = k1_X1_mid + k1_X2_mid + k1_X3_mid + k1_X4_mid + k1_X5_mid;
            k2_sum = k2_X1_mid + k2_X2_mid + k2_X3_mid + k2_X4_mid + k2_X5_mid;

            E_sum = KFE_max[0] + KFE_max[1] + KFE_max[2] + KFE_max[3] + KFE_max[4];

            k1[i] = k1_sum / 5d;
            k2[i] = k2_sum / 5d;
            E[i] = E_sum / 5d;

            //if (radius[0] == 0 || radius[1] == 0 || radius[2] == 0)
            //{
            //    if (prevE < E[i])
            //    {
            //        E[i] = 0;
            //    }
            //}
            //prevE = i != 0 ? E[i - 1] : 0;
        }
    }
}
