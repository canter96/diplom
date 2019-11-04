using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Diplom.res
{
    class CreateMatrix
    {
        Functions functions = new Functions();
        public double[,] createX1()
        {
            Form1 form1 = new Form1();
            
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            for ( int j = 0; j < form1.verticalLength;j++)
            {
                for (int i = 0; i < form1.sourseData.Length;i++)
            {
                    matrix[i, j] = functions.getRandom(80, 101);
                }    
            }
            return matrix;
        }
        public double[,] createX2()
        {
            Form1 form1 = new Form1();
            
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            for (int j = 0; j < form1.verticalLength; j++)
        {
                for (int i = 0; i < form1.sourseData.Length; i++) 
                {
                    matrix[i, j] = functions.getRandom(70, 91);
                }
            }
            return matrix;
        }
        public double[,] createX3()
        {
            Form1 form1 = new Form1();
            
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            for (int j = 0; j < form1.verticalLength; j++)
            {
                for (int i = 0; i < form1.sourseData.Length; i++)
                {
                    matrix[i, j] = functions.getRandom(60, 81);
                }
            }
            return matrix;
        }
        public double[,] createX4()
        {
            Form1 form1 = new Form1();
            
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            for (int j = 0; j < form1.verticalLength; j++)
            {
                for (int i = 0; i < form1.sourseData.Length; i++) 
                {
                    matrix[i, j] = functions.getRandom(50, 71);
                }
            }
            return matrix;
        }
        public double[,] createX5()
        {
            Form1 form1 = new Form1();
            
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            for (int j = 0; j < form1.verticalLength; j++)
            {
                for (int i = 0; i < form1.sourseData.Length; i++) 
                {
                    matrix[i, j] = functions.getRandom(40, 61);
                }
            }
            return matrix;
        }
        public double[,] create(int centr, int vidhilenna)
        {
            Form1 form1 = new Form1();
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            //double mean = 100;
            //double stdDev = 10;
            MathNet.Numerics.Distributions.Normal normalRandom = new Normal(centr, vidhilenna);
            
            for (int j = 0; j < form1.verticalLength; j ++)
            {
                for (int i = 0; i < form1.sourseData.Length; i++)
                {
                    //int random = functions.getRandom(randNachalo, randKonec);
                    int randomGaussianValue = Convert.ToInt32(normalRandom.Sample());
                    matrix[i, j] = randomGaussianValue;
                }
            }
            return matrix;
        }
    }

}
