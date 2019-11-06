using Diplom.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Diplom
{
    public partial class Form1 : Form
    {

        public double[,] classX1;
        public double[,] classX2;
        public double[,] classX3;
        public double[,] classX4;
        public double[,] classX5;
        public double ro = 0.5d;
        public int verticalLength = 40;
        public double[] sourseData = new double[120];
        public static int countClasses = 4;
        public static double Length;

        public static bool parallel = false;
        public static bool consistent = false;

        Functions functions = new Functions();
        UsingFiles usingFiles = new UsingFiles();
        CreateMatrix matrix = new CreateMatrix();

        public Form1()
        {
            InitializeComponent();
            Length = sourseData.Length;
        }
        public void callCreateWriteClasses()
        {
            //classX1 = matrix.createX1();
            //classX2 = matrix.createX2(); 
            //classX3 = matrix.createX3();
            //classX4 = matrix.createX4();
            //classX5 = matrix.createX5();
            classX1 = matrix.create(90, 15);
            classX2 = matrix.create(80, 15);
            classX3 = matrix.create(70, 15);
            classX4 = matrix.create(60, 15);
            //classX5 = matrix.create(50, 10);

            usingFiles.writeFile(classX1, "classX1");
            usingFiles.writeFile(classX2, "classX2");
            usingFiles.writeFile(classX3, "classX3");
            usingFiles.writeFile(classX4, "classX4");
            //usingFiles.writeFile(classX5, "classX5");

        }
        private void Form1_Load(object sender, EventArgs e)
        {           
            if (File.Exists(usingFiles.url + "classX1" + usingFiles.format) && File.Exists(usingFiles.url + "classX2" + usingFiles.format) && File.Exists(usingFiles.url + "classX3" + usingFiles.format) && File.Exists(usingFiles.url + "classX4" + usingFiles.format))
            {
                classX1 = usingFiles.readFile("classX1");
                classX2 = usingFiles.readFile("classX2");
                classX3 = usingFiles.readFile("classX3");
                classX4 = usingFiles.readFile("classX4");
                //classX5 = usingFiles.readFile("classX5");
            }

            else
            {
                callCreateWriteClasses();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            callCreateWriteClasses();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (parallel == false && consistent == false)
            {
                OutputGraphics outputGraphics = new OutputGraphics();
                outputGraphics.Text = "Графіки залежності критерію Кульбака від радіусів контейнерів класів розпізнавання";

                BazAlgoritm bazAlgoritm = new BazAlgoritm(classX1, classX2, classX3, classX4);
                bazAlgoritm.alg(10d);
                bazAlgoritm.algFind_K_KFE();

                outputGraphics.main(outputGraphics.chart1, bazAlgoritm.E_X1, "Кульбак", 1, bazAlgoritm.k1_X1, bazAlgoritm.k2_X1);
                outputGraphics.main(outputGraphics.chart2, bazAlgoritm.E_X2, "Кульбак", 2, bazAlgoritm.k1_X2, bazAlgoritm.k2_X2);
                outputGraphics.main(outputGraphics.chart3, bazAlgoritm.E_X3, "Кульбак", 3, bazAlgoritm.k1_X3, bazAlgoritm.k2_X3);
                outputGraphics.main(outputGraphics.chart4, bazAlgoritm.E_X4, "Кульбак", 4, bazAlgoritm.k1_X4, bazAlgoritm.k2_X4);
                //outputGraphics.main(outputGraphics.chart5, bazAlgoritm.E_X5, "Кульбак", 5, bazAlgoritm.k1_X5, bazAlgoritm.k2_X5);
                outputGraphics.Show();
            }
            else if (parallel == true)
            {
                OutputGraphics outputGraphics = new OutputGraphics();
                outputGraphics.Text = "Графіки одержані при оптимальному значенні дельтая";

                BazAlgoritm bazAlgoritm = new BazAlgoritm(classX1, classX2, classX3, classX4);
                bazAlgoritm.alg(OutputGraphics.op_delta);
                bazAlgoritm.algFind_K_KFE();

                outputGraphics.main(outputGraphics.chart1, bazAlgoritm.E_X1, "Кульбак", 1, bazAlgoritm.k1_X1, bazAlgoritm.k2_X1);
                outputGraphics.main(outputGraphics.chart2, bazAlgoritm.E_X2, "Кульбак", 2, bazAlgoritm.k1_X2, bazAlgoritm.k2_X2);
                outputGraphics.main(outputGraphics.chart3, bazAlgoritm.E_X3, "Кульбак", 3, bazAlgoritm.k1_X3, bazAlgoritm.k2_X3);
                outputGraphics.main(outputGraphics.chart4, bazAlgoritm.E_X4, "Кульбак", 4, bazAlgoritm.k1_X4, bazAlgoritm.k2_X4);
                //outputGraphics.main(outputGraphics.chart5, bazAlgoritm.E_X5, "Кульбак", 5, bazAlgoritm.k1_X5, bazAlgoritm.k2_X5);
                outputGraphics.Show();
                parallel = false;
            }
            else if (consistent == true)
            {
                OutputGraphics outputGraphics = new OutputGraphics();
                outputGraphics.Text = "Графіки після послідовної оптимізації";

                BazAlgoritm bazAlgoritm = new BazAlgoritm(classX1, classX2, classX3, classX4);
                bazAlgoritm.alg("consistent");
                bazAlgoritm.algFind_K_KFE();

                outputGraphics.main(outputGraphics.chart1, bazAlgoritm.E_X1, "Кульбак", 1, bazAlgoritm.k1_X1, bazAlgoritm.k2_X1);
                outputGraphics.main(outputGraphics.chart2, bazAlgoritm.E_X2, "Кульбак", 2, bazAlgoritm.k1_X2, bazAlgoritm.k2_X2);
                outputGraphics.main(outputGraphics.chart3, bazAlgoritm.E_X3, "Кульбак", 3, bazAlgoritm.k1_X3, bazAlgoritm.k2_X3);
                outputGraphics.main(outputGraphics.chart4, bazAlgoritm.E_X4, "Кульбак", 4, bazAlgoritm.k1_X4, bazAlgoritm.k2_X4);
                //outputGraphics.main(outputGraphics.chart5, bazAlgoritm.E_X5, "Кульбак", 5, bazAlgoritm.k1_X5, bazAlgoritm.k2_X5);
                outputGraphics.Show();
                consistent = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parallel = true;
            consistent = false;
            OutputGraphics outputGraphics = new OutputGraphics();
            outputGraphics.Text = "Паралельна оптимізація КД";

            Optimization optimization = new Optimization(classX1, classX2, classX3, classX4);
            optimization.main("parallel");

            outputGraphics.chart2.Series.Clear();
            outputGraphics.chart3.Series.Clear();
            outputGraphics.chart4.Series.Clear();
            outputGraphics.main(outputGraphics.chart1, optimization.E, "Паралельна оптимізація КД", 4, optimization.k1, optimization.k2);
            outputGraphics.Show();
        }
        async void consistentAsync()
        {
            consistent = true;
            parallel = false;
            OutputGraphics outputGraphics = new OutputGraphics();
            outputGraphics.Text = "Послідовна оптимізація КД";

            Optimization optimization = new Optimization(classX1, classX2, classX3, classX4);
            await Task.Run(() => {
                optimization.main("consistent");             
            });
            outputGraphics.chart2.Series.Clear();
            outputGraphics.chart3.Series.Clear();
            outputGraphics.chart4.Series.Clear();

            outputGraphics.GetGraph(outputGraphics.chart1, optimization.E_consistent_all, "Послідовна оптимізація КД", 4);
            outputGraphics.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            consistentAsync();
        }
    }
}
