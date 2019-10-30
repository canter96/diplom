using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.res
{
    class MatrixX2
    {
        public double[,] create()
        {
            Form1 form1 = new Form1();
            Functions functions = new Functions();

            double[,] matrix = new double[form1.sourseData.Length, form1.verticalLength];

            return matrix;
        }
    }
}
