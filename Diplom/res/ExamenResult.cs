using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.res
{
    public partial class ExamenResult : Form
    {
        UsingFiles usingFiles = new UsingFiles();
        public double[,] classX1;
        public double[,] classX2;
        public double[,] classX3;
        public double[,] classX4;
        public ExamenResult()
        {
            InitializeComponent();
        }

        private void ExamenResult_Load(object sender, EventArgs e)
        {
            OutInTextBox.txt1 = textBox1;
            OutInTextBox.txt2 = textBox2;
            OutInTextBox.txt3 = textBox3;
            OutInTextBox.txt4 = textBox4;
            OutInTextBox.txt5 = textBox5;
            classX1 = usingFiles.readFile("classX1");
            classX2 = usingFiles.readFile("classX2");
            classX3 = usingFiles.readFile("classX3");
            classX4 = usingFiles.readFile("classX4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Examen examen = new Examen(classX1, classX2, classX3, classX4, classX1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
