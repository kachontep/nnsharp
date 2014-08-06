using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NNSharp;

namespace FuzzyARTMapGUI
{
    public partial class Form2 : Form
    {
        private string outputFile;

        private ProcessPerformanceCounter performance;

        public Form2()
        {
            InitializeComponent();
        }

        public string OutputFile
        {
            get { return outputFile; }
            set { outputFile = value; }
        }

        public ProcessPerformanceCounter Performance
        {
            get { return performance; }
            set { performance = value; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Performance != null)
            {
                txtCorrect.Text = Performance.Right.ToString();
                txtIncorrect.Text = Performance.Wrong.ToString();
                txtTotal.Text = Performance.Total.ToString();
                txtPerformance.Text = Performance.AccuracyPercentage.ToString("0.00");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewOutputFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(OutputFile);
        }
    }
}
