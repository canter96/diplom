using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.res
{
    class Optimization : BazAlgoritm
    {
        public double[] E;
        public double[] k1;
        public double[] k2;
        public double[] KFE_max = new double[4];
        int[] radius = new int[4];
        double k1_X1_mid;
        double k2_X1_mid;
        double k1_X2_mid;
        double k2_X2_mid;
        double k1_X3_mid;
        double k2_X3_mid;
        double k1_X4_mid;
        double k2_X4_mid;
        //double k1_X5_mid;
        //double k2_X5_mid;

        public double[] E_consistent_1;
        public double[] E_consistent_2;
        public double[] E_consistent_3;
        public double[] E_consistent_all;
        
        int E_max_index;
        public double E_max = 0;

        
        
        Functions functions = new Functions();
        Form1 form1 = new Form1();

        public Optimization(double[,] classX1, double[,] classX2, double[,] classX3, double[,] classX4) : base(classX1, classX2, classX3, classX4)
        {
        }
        public void main(string TYPE)
        {
            
            E = new double[classX1.GetLength(0)];
            k1 = new double[classX1.GetLength(0)];
            k2 = new double[classX1.GetLength(0)];
            if (TYPE == "parallel")
            {
                for (int i = 0; i <= 100; i++)
                {
                    base.alg(i);
                    repeat(i);
                }
            }
            else if (TYPE == "consistent")
            {
                E_consistent_1 = new double[form1.sourseData.Length];
                E_consistent_2 = new double[form1.sourseData.Length];
                E_consistent_3 = new double[form1.sourseData.Length];
                E_consistent_all = new double[form1.sourseData.Length * 3];


                double opt = 0;
                int index = 0;
                base.start();
                for (int progon = 0; progon < 3; progon++)
                {
                    for (int oznaka = 0; oznaka < 120; oznaka++)
                    {
                        index = E_max_index;

                        opt = E_max;
                        E_max = 0;

                        for (int delta = 0; delta < 50; delta++)
                        {
                            base.alg(oznaka, delta, index, progon);
                            repeat(delta);

                            //if (k1[delta] >= 0.5 && k2[delta] < 0.5) {
                            //if (E[delta] > opt) {
                            //    opt = E[delta];
                            //    index = delta;
                            //}
                            //}
                        }



                        if (E_max == opt)
                        {
                            // break;
                        }

                        switch (progon)
                        {
                            case 0:
                                E_consistent_1[oznaka] = E_max;
                                break;
                            case 1:
                                E_consistent_2[oznaka] = E_max;
                                break;
                            case 2:
                                E_consistent_3[oznaka] = E_max;
                                break;

                        }                       
                    }

                    limitUp[form1.sourseData.Length - 1] = limitUpSave[form1.sourseData.Length - 1] + E_max_index;
                    limitDown[form1.sourseData.Length - 1] = limitDownSave[form1.sourseData.Length - 1] - E_max_index;
                }//PA

                base.SaveLimit();

                for (int i = 0; i < form1.sourseData.Length * 3; i++)
                {
                    if (i < form1.sourseData.Length)
                    {
                        E_consistent_all[i] = E_consistent_1[i];

                    }
                    else if (i < form1.sourseData.Length * 2)
                    {
                        E_consistent_all[i] = E_consistent_2[i - form1.sourseData.Length];

                    }
                    else if (i < form1.sourseData.Length * 3)
                    {
                        E_consistent_all[i] = E_consistent_3[i - (form1.sourseData.Length * 2)];
                    }
                }




                //double optDelta = 0;
                //int optDeltaIndex = 0;

                //for (int i = 0; i < 169; i++) {
                //    base.alg(i, 16);
                //    repeat(i);

                //    if (k1[i] >= 0.5 && k2[i] < 0.5) {
                //        if (E[i] > optDelta) {
                //            optDelta = E[i];
                //            optDeltaIndex = i;
                //        }
                //    }
                //}

                for (int cl = 0; cl < Form1.countClasses; cl++)
                {


                    //if (functions.FindMaxCount(E) > max) {
                    //    E_max = E;
                    //    k1_max = k1;
                    //    k2_max = k2;
                    //    max = functions.FindMaxCount(E);

                    //    op_class = cl;
                    //}

                }
            }


        }
        private void repeat(int i)
        {
        
            base.algFind_K_KFE();

            KFE_max[0] = functions.FindMaxCount(E_X1);
            KFE_max[1] = functions.FindMaxCount(E_X2);
            KFE_max[2] = functions.FindMaxCount(E_X3);
            KFE_max[3] = functions.FindMaxCount(E_X4);
            //KFE_max[4] = functions.FindMaxCount(E_X5);

            radius[0] = functions.findWorkArea(k1_X1, k2_X1);
            radius[1] = functions.findWorkArea(k1_X2, k2_X2);
            radius[2] = functions.findWorkArea(k1_X3, k2_X3);
            radius[3] = functions.findWorkArea(k1_X4, k2_X4);
            //radius[4] = functions.findWorkArea(k1_X5, k2_X5);

            k1_X1_mid = functions.isFindWorkArea(E_X1, KFE_max[0], k1_X1, radius[0]);
            k2_X1_mid = functions.isFindWorkArea(E_X1, KFE_max[0], k2_X1, radius[0]);
            k1_X2_mid = functions.isFindWorkArea(E_X2, KFE_max[1], k1_X2, radius[1]);
            k2_X2_mid = functions.isFindWorkArea(E_X2, KFE_max[1], k2_X2, radius[1]);
            k1_X3_mid = functions.isFindWorkArea(E_X3, KFE_max[2], k1_X3, radius[2]);
            k2_X3_mid = functions.isFindWorkArea(E_X3, KFE_max[2], k2_X3, radius[2]);
            k1_X4_mid = functions.isFindWorkArea(E_X4, KFE_max[3], k1_X4, radius[3]);
            k2_X4_mid = functions.isFindWorkArea(E_X4, KFE_max[3], k2_X4, radius[3]);
            //k1_X5_mid = functions.isFindWorkArea(E_X5, KFE_max[4], k1_X5, radius[4]);
            //k2_X5_mid = functions.isFindWorkArea(E_X5, KFE_max[4], k2_X5, radius[4]);



            //KFE_max[0] = radius[0] == 0 ? 0 : KFE_max[0];

            //KFE_max[1] = radius[1] == 0 ? 0 : KFE_max[1];

            //KFE_max[2] = radius[2] == 0 ? 0 : KFE_max[2];

            k1_sum = k1_X1_mid + k1_X2_mid + k1_X3_mid + k1_X4_mid;
            k2_sum = k2_X1_mid + k2_X2_mid + k2_X3_mid + k2_X4_mid;

            E_sum = KFE_max[0] + KFE_max[1] + KFE_max[2] + KFE_max[3];

            k1[i] = k1_sum / 4d;
            k2[i] = k2_sum / 4d;
            E[i] = E_sum / 4d;

            //if (radius[0] == 0 || radius[1] == 0 || radius[2] == 0)
            //{
            //    if (prevE < E[i])
            //    {
            //        E[i] = 0;
            //    }
            //}
            //prevE = i != 0 ? E[i - 1] : 0;
            if (k1[i] >= 0.5 && k2[i] < 0.5)
            {
                if (E[i] > E_max)
                {
                    E_max = E[i];
                    E_max_index = i;
                }
            }
        }
    }
}
