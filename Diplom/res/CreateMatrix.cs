﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.res
{
    class CreateMatrix
    {
        public double[,] createX1()
        {
            Form1 form1 = new Form1();
            Functions functions = new Functions();
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
            for (int i = 0; i < form1.sourseData.Length;i++)
            {
                for ( int j = 0; j < form1.verticalLength;j++) {
                    matrix[i, j] = functions.getRandom(80, 100);
                }    
            }

            return matrix;
        }
        public double[,] createX2()
        {
            Form1 form1 = new Form1();
            Functions functions = new Functions();
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
          
            return matrix;
        }
        public double[,] createX3()
        {
            Form1 form1 = new Form1();
            Functions functions = new Functions();
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
        
            return matrix;
        }
        public double[,] createX4()
        {
            Form1 form1 = new Form1();
            Functions functions = new Functions();
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
          
            return matrix;
        }
        public double[,] createX5()
        {
            Form1 form1 = new Form1();
            Functions functions = new Functions();
            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];
          
            return matrix;
        }
    }
}
