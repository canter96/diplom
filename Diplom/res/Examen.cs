using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.res
{
    class Examen:BazAlgoritm
    {
        double[,] examen;
        double[,] examenBin;
        double[] sk1;
        double[] sk2;
        double[] sk3;
        double[] sk4;
        double EmaxIndexX1;
        double EmaxIndexX2;
        double EmaxIndexX3;
        double EmaxIndexX4;
        double[] M = new double[4];



        Functions functions = new Functions();
        Form1 form1 = new Form1();

        public Examen(double[,] classX1, double[,] classX2, double[,] classX3, double[,] classX4, double[,] examen) : base(classX1, classX2, classX3,classX4)
        {
            base.alg(25);
            this.examenBin = functions.BinMatrix(examen, limitDown, limitUp);
            base.algFind_K_KFE();
            this.examen = examen;
            main();
        }

        void main()
        {
            double[] funNaLX1 = new double[form1.verticalLength];
            double[] funNaLX2 = new double[form1.verticalLength];
            double[] funNaLX3 = new double[form1.verticalLength];
            double[] funNaLX4 = new double[form1.verticalLength];
            sk1 = functions.findCountXORforEachLinesMatrix(base.EtalVecBinX1, this.examenBin);
            sk2 = functions.findCountXORforEachLinesMatrix(base.EtalVecBinX2, this.examenBin);
            sk3 = functions.findCountXORforEachLinesMatrix(base.EtalVecBinX3, this.examenBin);
            sk4 = functions.findCountXORforEachLinesMatrix(base.EtalVecBinX4, this.examenBin);

            EmaxIndexX1 = functions.FindMaxInxex(E_X1);
            EmaxIndexX2 = functions.FindMaxInxex(E_X2);
            EmaxIndexX3 = functions.FindMaxInxex(E_X3);
            EmaxIndexX4 = functions.FindMaxInxex(E_X4);

            for (int i = 0; i < form1.verticalLength; i++)
            {
                funNaLX1[i] = 1 - (sk1[i] / EmaxIndexX1);
                funNaLX2[i] = 1 - (sk2[i] / EmaxIndexX2);
                funNaLX3[i] = 1 - (sk3[i] / EmaxIndexX3);
                funNaLX4[i] = 1 - (sk4[i] / EmaxIndexX4);

            }

            M[0] = functions.findMean(funNaLX1);
            M[1] = functions.findMean(funNaLX2);
            M[2] = functions.findMean(funNaLX3);
            M[3] = functions.findMean(funNaLX4);

            OutInTextBox.txt1.Text = Convert.ToString(M[0]);
            OutInTextBox.txt2.Text = Convert.ToString(M[1]);
            OutInTextBox.txt3.Text = Convert.ToString(M[2]);
            OutInTextBox.txt4.Text = Convert.ToString(M[3]);


            double M_max = functions.FindMaxCount(M);
            int M_max_Index = Convert.ToInt32(functions.FindMaxInxex(M));

            if (M_max <= 0)
            {
                OutInTextBox.txt5.Text = "Не відноситься до жодного класу";
            }
            else
            {
                switch (M_max_Index)
                {
                    case 0:
                        OutInTextBox.txt5.Text = "Відноситься до 1 класу";
                        break;
                    case 1:
                        OutInTextBox.txt5.Text = "Відноситься до 2 класу";
                        break;
                    case 2:
                        OutInTextBox.txt5.Text = "Відноситься до 3 класу";
                        break;
                    case 3:
                        OutInTextBox.txt5.Text = "Відноситься до 4 класу";
                        break;
                    default:
                        OutInTextBox.txt5.Text = "Не відноситься до жодного класу";
                        break;
                }
            }
        }
    }
}
