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
    public partial class Form3 : Form
    {
        private SimplifiedFuzzyARTMap fArtMap;

        private ModifiedFuzzyARTMap mArtMap;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Set default selected index of cbWeights.
            cbWeights.SelectedIndex = 0;
            UpdateWeightsData();
        }

        void UpdateWeightsData()
        {
            NeuronLayer layer = null;
            int numberOfColumns = 0;
            switch (cbWeights.SelectedIndex)
            {
                case 0: layer = FArtMap.ArtA.F2;
                        numberOfColumns = FArtMap.ArtA.InputSize;
                    break;
                case 1: layer = FArtMap.ArtB.F2;
                        numberOfColumns = FArtMap.ArtB.InputSize;
                    break;
                case 2: layer = FArtMap.Map;
                        numberOfColumns = FArtMap.ArtB.InputSize;
                    break;
            }

            // Clear columns data grid view.
            dgvWeights.Columns.Clear();
            for(int i = 1; i <= numberOfColumns; i++)
                dgvWeights.Columns.Add( "Weight" + i, "Weight " + i);

            // Clear weights data grid view.
            dgvWeights.Rows.Clear();
            for (int i = 0; i < layer.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = (i + 1).ToString();
                foreach (double weight in layer.Neurons(i).Weights)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.Value = weight.ToString("0.0000");
                    row.Cells.Add(cell);
                }
                dgvWeights.Rows.Add(row);
            }
        }

        private void cbWeights_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWeightsData();
        }

        public SimplifiedFuzzyARTMap FArtMap
        {
            get { return fArtMap; }
            set { fArtMap = value; }
        }

        public ModifiedFuzzyARTMap MArtMap
        {
            get { return mArtMap; }
            set { mArtMap = value; }
        }
    }
}
