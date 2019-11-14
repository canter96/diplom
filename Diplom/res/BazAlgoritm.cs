using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.res
{
    class BazAlgoritm
    {
        public double[,] classX1;
        public double[,] classX2;
        public double[,] classX3;
        public double[,] classX4;
        //public double[,] classX5;

        static double[] limitUpStart;
        static double[] limitDownStart;
        public static double[] limitUpSave;
        public static double[] limitDownSave;
        public static int prog = 0;

        public double[] meanValues;


        public double[] limitUp;
        public double[] limitDown;
        double[,] binX1;
        double[,] binX2;
        double[,] binX3;
        double[,] binX4;
        //double[,] binX5;

        double[] meanBinX1;
        protected double[] EtalVecBinX1;
        double[] meanBinX2;
        protected double[] EtalVecBinX2;
        double[] meanBinX3;
        protected double[] EtalVecBinX3;
        double[] meanBinX4;
        protected double[] EtalVecBinX4;
        //double[] meanBinX5;
        //double[] EtalVecBinX5;

        double[] dck_xkX1; // к своим 
        double[] dck_xnX1;// к чужим 
        double[] dck_xkX2; // к своим 
        double[] dck_xnX2; // к чужим 
        double[] dck_xkX3; // к своим 
        double[] dck_xnX3; // к чужим
        double[] dck_xkX4; // к своим 
        double[] dck_xnX4; // к чужим
        //double[] dck_xkX5; // к своим 
        //double[] dck_xnX5; // к чужим

        public double[] k1_X1;
        public double[] k2_X1;
        public double[] k1_X2;
        public double[] k2_X2;
        public double[] k1_X3;
        public double[] k2_X3;
        public double[] k1_X4;
        public double[] k2_X4;
        //public double[] k1_X5;
        //public double[] k2_X5;

        public double[] E_X1;
        public double[] E_X2;
        public double[] E_X3;
        public double[] E_X4;
        //public double[] E_X5;

        public double k1_sum;
        public double k2_sum;
        public double E_sum;

        Functions functions = new Functions();


        public BazAlgoritm(double[,] classX1, double[,] classX2, double[,] classX3, double[,] classX4)
        {
            this.classX1 = classX1;
            this.classX2 = classX2;
            this.classX3 = classX3;
            this.classX4 = classX4;
            //this.classX5 = classX5;
        }

        public void alg(double delta)
        {
            meanValues = functions.findMean(classX1); //Поиск среднего значения
            limitUp = functions.findLimit(meanValues, "Up", delta); //верехний допуск по среднем значении classA
            limitDown = functions.findLimit(meanValues, "Down", delta); //нижний допуск по среднем значении classA

            //limitUp[0] = limitUp[0] + 14;
            //limitDown[0] = limitDown[0] - 14;
            //limitUp[1] = limitUp[1] + 5;
            //limitDown[1] = limitDown[1] - 5;
            //limitUp[2] = limitUp[2] + 28;
            //limitDown[2] = limitDown[2] - 28;
            //limitUp[3] = limitUp[3] + 4;
            //limitDown[3] = limitDown[3] - 4;
            //limitUp[4] = limitUp[4] + 4;
            //limitDown[4] = limitDown[4] - 4;
            //limitUp[5] = limitUp[5] + 4;
            //limitDown[5] = limitDown[5] - 4;


            algMain();
        }

        public void start()
        {
            meanValues = functions.findMean(classX1); //Поиск среднего значения
            limitUpStart = functions.findLimit(meanValues, "Up", OutputGraphics.op_delta); //верехний допуск по среднем значении classA
            limitDownStart = functions.findLimit(meanValues, "Down", OutputGraphics.op_delta); //нижний допуск по среднем значении classA
            limitUp = new double[meanValues.Length];
            limitDown = new double[meanValues.Length];

            limitUpSave = new double[meanValues.Length];
            limitDownSave = new double[meanValues.Length];

            for (int i = 0; i < meanValues.Length; i++)
            {
                limitUp[i] = limitUpStart[i];
                limitDown[i] = limitDownStart[i];

                limitUpSave[i] = limitUpStart[i];
                limitDownSave[i] = limitDownStart[i];
            }


        }

        public void SaveLimit()
        {
            //limitUpSave = new double[meanValues.Length];
            //limitDownSave = new double[meanValues.Length];
            for (int i = 0; i < Form1.Length; i++)
            {
                limitUpSave[i] = limitUp[i];
                limitDownSave[i] = limitDown[i];
            }

        }
        public void alg(int oznaka, int i, double optDelta, int progon)
        {
            if (prog != progon)
            {
                SaveLimit();
            }

            if (oznaka != 0)
            {
                limitUp[oznaka - 1] = limitUpSave[oznaka - 1] + optDelta;
                limitDown[oznaka - 1] = limitDownSave[oznaka - 1] - optDelta;
            }

            limitUp[oznaka] = limitUpSave[oznaka] + i;
            limitDown[oznaka] = limitDownSave[oznaka] - i;

            // if (oznaka != 0) {
            //    limitUp[oznaka - 1] = limitUpStart[oznaka - 1] + optDelta;
            //    limitDown[oznaka - 1] = limitDownStart[oznaka - 1] - optDelta;
            //}

            //limitUp[oznaka] = limitUpStart[oznaka] + i;
            //limitDown[oznaka] = limitDownStart[oznaka] - i;

            algMain();

            prog = progon;
        }

        public void alg(string TYPE)
        {
            if (TYPE == "consistent")
            {
                meanValues = functions.findMean(classX1); //Поиск среднего значения
                limitUp = new double[meanValues.Length];
                limitDown = new double[meanValues.Length];


                for (int i = 0; i < Form1.Length; i++)
                {
                    limitUp[i] = limitUpSave[i];
                    limitDown[i] = limitDownSave[i];
                }


            }
            algMain();
        }

        private void algMain()
        {
            //limitUp = functions.findLimit(meanValues, "Up", delta); //верехний допуск по среднем значении classA
            //limitDown = functions.findLimit(meanValues, "Down", delta); //нижний допуск по среднем значении classA

            binX1 = functions.BinMatrix(classX1, limitDown, limitUp);
            binX2 = functions.BinMatrix(classX2, limitDown, limitUp);
            binX3 = functions.BinMatrix(classX3, limitDown, limitUp);
            binX4 = functions.BinMatrix(classX4, limitDown, limitUp);
            //binX5 = functions.BinMatrix(classX5, limitDown, limitUp);

            meanBinX1 = functions.findMean(binX1); //Поиск среднего значения bin A 0,54 - 0,6 - 0,3
            EtalVecBinX1 = functions.FindEtalVecBin(meanBinX1); //Поиск еталоного вектора meanBinA 1, 0, 1
            meanBinX2 = functions.findMean(binX2); //Поиск среднего значения bin B 0,54 - 0,6 - 0,3
            EtalVecBinX2 = functions.FindEtalVecBin(meanBinX2); //Поиск еталоного вектора meanBinB 1, 0, 1
            meanBinX3 = functions.findMean(binX3); //Поиск среднего значения bin C 0,54 - 0,6 - 0,3
            EtalVecBinX3 = functions.FindEtalVecBin(meanBinX3); //Поиск еталоного вектора meanBinC 1, 0, 1
            meanBinX4 = functions.findMean(binX4); //Поиск среднего значения bin C 0,54 - 0,6 - 0,3
            EtalVecBinX4 = functions.FindEtalVecBin(meanBinX4); //Поиск еталоного вектора meanBinC 1, 0, 1
            //meanBinX5 = functions.findMean(binX5); //Поиск среднего значения bin C 0,54 - 0,6 - 0,3
            //EtalVecBinX5 = functions.FindEtalVecBin(meanBinX5); //Поиск еталоного вектора meanBinC 1, 0, 1

            double[] distancesX1 = new double[3];
            double[] distancesX2 = new double[3];
            double[] distancesX3 = new double[3];
            double[] distancesX4 = new double[3];
            //double[] distancesX5 = new double[4];
            double[] minDistances = new double[4];
            int[] index = new int[4];

            distancesX1[0] = functions.findCountXOR(EtalVecBinX1, EtalVecBinX2);//0 9 0
            distancesX1[1] = functions.findCountXOR(EtalVecBinX1, EtalVecBinX3);
            distancesX1[2] = functions.findCountXOR(EtalVecBinX1, EtalVecBinX4);
            //distancesX1[3] = functions.findCountXOR(EtalVecBinX1, EtalVecBinX5);

            distancesX2[0] = functions.findCountXOR(EtalVecBinX2, EtalVecBinX1); //9 0 9
            distancesX2[1] = functions.findCountXOR(EtalVecBinX2, EtalVecBinX3);
            distancesX2[2] = functions.findCountXOR(EtalVecBinX2, EtalVecBinX4);
            //distancesX2[3] = functions.findCountXOR(EtalVecBinX2, EtalVecBinX5);

            distancesX3[0] = functions.findCountXOR(EtalVecBinX3, EtalVecBinX1); //0 9 0
            distancesX3[1] = functions.findCountXOR(EtalVecBinX3, EtalVecBinX2);
            distancesX3[2] = functions.findCountXOR(EtalVecBinX3, EtalVecBinX4);
            //distancesX3[3] = functions.findCountXOR(EtalVecBinX3, EtalVecBinX5);

            distancesX4[0] = functions.findCountXOR(EtalVecBinX4, EtalVecBinX1); //0 9 0
            distancesX4[1] = functions.findCountXOR(EtalVecBinX4, EtalVecBinX2);
            distancesX4[2] = functions.findCountXOR(EtalVecBinX4, EtalVecBinX3);
            //distancesX4[3] = functions.findCountXOR(EtalVecBinX4, EtalVecBinX5);

            //distancesX5[0] = functions.findCountXOR(EtalVecBinX5, EtalVecBinX1); //0 9 0
            //distancesX5[1] = functions.findCountXOR(EtalVecBinX5, EtalVecBinX2);
            //distancesX5[2] = functions.findCountXOR(EtalVecBinX5, EtalVecBinX3);
            //distancesX5[3] = functions.findCountXOR(EtalVecBinX5, EtalVecBinX4);


            minDistances[0] = functions.FindMinCount(distancesX1); // поиск минимально значения 
            minDistances[1] = functions.FindMinCount(distancesX2); // поиск минимально значения 
            minDistances[2] = functions.FindMinCount(distancesX3); // поиск минимально значения 
            minDistances[3] = functions.FindMinCount(distancesX4); // поиск минимально значения 
            //minDistances[4] = functions.FindMinCount(distancesX5); // поиск минимально значения 

            index[0] = Array.IndexOf(distancesX1, minDistances[0]); //ижем индекс минимального числа в масиве distances
            index[1] = Array.IndexOf(distancesX2, minDistances[1]); //ижем индекс минимального числа в масиве distances
            index[2] = Array.IndexOf(distancesX3, minDistances[2]); //ижем индекс минимального числа в масиве distances
            index[3] = Array.IndexOf(distancesX4, minDistances[3]); //ижем индекс минимального числа в масиве distances
            //index[4] = Array.IndexOf(distancesX5, minDistances[4]); //ижем индекс минимального числа в масиве distances


            dck_xkX1 = functions.findCountXORforEachLinesMatrix(EtalVecBinX1, binX1); // поиск несовпадений для каждой строки матрицы  74	37	41	32	41	38	45	39	40	32	34	37	37	35	30	48	37	45	40	37	45
            switch (index[0])
            {
                case 0:
                    dck_xnX1 = functions.findCountXORforEachLinesMatrix(EtalVecBinX1, binX2);
                    break;
                case 1:
                    dck_xnX1 = functions.findCountXORforEachLinesMatrix(EtalVecBinX1, binX3); // 71	37	41	33	41	38	44	39	38	32	34	36	37
                    break;
                case 2:
                    dck_xnX1 = functions.findCountXORforEachLinesMatrix(EtalVecBinX1, binX4); // 71	37	41	33	41	38	44	39	38	32	34	36	37
                    break;
                //case 3:
                //    dck_xnX1 = functions.findCountXORforEachLinesMatrix(EtalVecBinX1, binX5); // 71	37	41	33	41	38	44	39	38	32	34	36	37
                //    break;
            }

            dck_xkX2 = functions.findCountXORforEachLinesMatrix(EtalVecBinX2, binX2);
            switch (index[1])
            {
                case 0:
                    dck_xnX2 = functions.findCountXORforEachLinesMatrix(EtalVecBinX2, binX1);
                    break;
                case 1:
                    dck_xnX2 = functions.findCountXORforEachLinesMatrix(EtalVecBinX2, binX3);
                    break;
                case 2:
                    dck_xnX2 = functions.findCountXORforEachLinesMatrix(EtalVecBinX2, binX4);
                    break;
                //case 3:
                //    dck_xnX2 = functions.findCountXORforEachLinesMatrix(EtalVecBinX2, binX5);
                //    break;
            }

            dck_xkX3 = functions.findCountXORforEachLinesMatrix(EtalVecBinX3, binX3);
            switch (index[2])
            {
                case 0:
                    dck_xnX3 = functions.findCountXORforEachLinesMatrix(EtalVecBinX3, binX1);
                    break;
                case 1:
                    dck_xnX3 = functions.findCountXORforEachLinesMatrix(EtalVecBinX3, binX2);
                    break;
                case 2:
                    dck_xnX3 = functions.findCountXORforEachLinesMatrix(EtalVecBinX3, binX4);
                    break;
                //case 3:
                //    dck_xnX3 = functions.findCountXORforEachLinesMatrix(EtalVecBinX3, binX5);
                //    break;
            }
            dck_xkX4 = functions.findCountXORforEachLinesMatrix(EtalVecBinX4, binX4);
            switch (index[3])
            {
                case 0:
                    dck_xnX4 = functions.findCountXORforEachLinesMatrix(EtalVecBinX4, binX1);
                    break;
                case 1:
                    dck_xnX4 = functions.findCountXORforEachLinesMatrix(EtalVecBinX4, binX2);
                    break;
                case 2:
                    dck_xnX4 = functions.findCountXORforEachLinesMatrix(EtalVecBinX4, binX3);
                    break;
                //case 3:
                //    dck_xnX4 = functions.findCountXORforEachLinesMatrix(EtalVecBinX4, binX5);
                //    break;
            }
            //dck_xkX5 = functions.findCountXORforEachLinesMatrix(EtalVecBinX5, binX5);
            //switch (index[4])
            //{
            //    case 0:
            //        dck_xnX5 = functions.findCountXORforEachLinesMatrix(EtalVecBinX5, binX1);
            //        break;
            //    case 1:
            //        dck_xnX5 = functions.findCountXORforEachLinesMatrix(EtalVecBinX5, binX2);
            //        break;
            //    case 2:
            //        dck_xnX5 = functions.findCountXORforEachLinesMatrix(EtalVecBinX5, binX3);
            //        break;
            //    case 3:
            //        dck_xnX5 = functions.findCountXORforEachLinesMatrix(EtalVecBinX5, binX4);
            //        break;
            //}
        }


        public void algFind_K_KFE()
        {
            k1_X1 = functions.findK(dck_xkX1, meanValues.Length);
            k2_X1 = functions.findK(dck_xnX1, meanValues.Length);
            k1_X2 = functions.findK(dck_xkX2, meanValues.Length);
            k2_X2 = functions.findK(dck_xnX2, meanValues.Length);
            k1_X3 = functions.findK(dck_xkX3, meanValues.Length);
            k2_X3 = functions.findK(dck_xnX3, meanValues.Length);
            k1_X4 = functions.findK(dck_xkX4, meanValues.Length);
            k2_X4 = functions.findK(dck_xnX4, meanValues.Length);
            //k1_X5 = functions.findK(dck_xkX5, meanValues.Length);
            //k2_X5 = functions.findK(dck_xnX5, meanValues.Length);

            E_X1 = functions.find_KFE(k1_X1, k2_X1, meanValues.Length);
            E_X2 = functions.find_KFE(k1_X2, k2_X2, meanValues.Length);
            E_X3 = functions.find_KFE(k1_X3, k2_X3, meanValues.Length);
            E_X4 = functions.find_KFE(k1_X4, k2_X4, meanValues.Length);
            //E_X5 = functions.find_KFE(k1_X5, k2_X5, meanValues.Length);



            //for (int i = 0; i < meanValues.Length; i++) {
            //    if (radius[1] != 0) {
            //        if (E_A[i] ==  KFE_max[1]) {
            //            k1_A_mid = k1_A[i];
            //            k2_A_mid = k2_A[i];
            //        }
            //    }
            //    else {
            //        k1_A_mid = k1_A[i] + double.PositiveInfinity;
            //        k2_A_mid = k2_A[i] + double.PositiveInfinity;
            //    }
            //}
        }
    }
}
