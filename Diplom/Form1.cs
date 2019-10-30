﻿using Diplom.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public int verticalLength = 40;
        public double[] sourseData = new double[120];

        Functions functions = new Functions();
        UsingFiles usingFiles = new UsingFiles();
        CreateMatrix matrix = new CreateMatrix();

        public Form1()
        {
            InitializeComponent();
        }
        public void callCreateWriteClasses()
        {
            classX1 = matrix.createX1();
            classX2 = matrix.createX2(); 
            classX3 = matrix.createX3();
            classX4 = matrix.createX4();
            classX5 = matrix.createX5();
            //classX1 = matrix.create(80,100);
            //classX2 = matrix.create(70,90);
            //classX3 = matrix.create(60,80);
            //classX4 = matrix.create(50,70);
            //classX5 = matrix.create(40,60);

            usingFiles.writeFile(classX1, "classX1");
            usingFiles.writeFile(classX2, "classX2");
            usingFiles.writeFile(classX3, "classX3");
            usingFiles.writeFile(classX4, "classX4");
            usingFiles.writeFile(classX5, "classX5");

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(usingFiles.url + "classX1" + usingFiles.format) && File.Exists(usingFiles.url + "classX2" + usingFiles.format) && File.Exists(usingFiles.url + "classX3" + usingFiles.format) && File.Exists(usingFiles.url + "classX4" + usingFiles.format) && File.Exists(usingFiles.url + "classX5" + usingFiles.format))
            {
                classX1 = usingFiles.readFile("classX1");
                classX2 = usingFiles.readFile("classX2");
                classX3 = usingFiles.readFile("classX3");
                classX4 = usingFiles.readFile("classX4");
                classX5 = usingFiles.readFile("classX5");
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
    }
}
