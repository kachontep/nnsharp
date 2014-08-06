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
    public partial class Form1 : Form
    {
        bool trainingCompleted;
        ProcessSimplifiedFuzzyARTMapParameter parameter;
        int selectedTypeOfFuzzyARTMAP;
        Object process;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbFuzzyARTMAPType.SelectedIndex = 0;
        }

        private void cbFuzzyARTMAPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check index changed during training process.
            if (backgroundWorker1.IsBusy)
            {
                if (MessageBox.Show(this, "Neural Network is during training process.Do you want to cancel it?",
                    "Warning") == DialogResult.OK)
                {
                    btnCancelTrain_Click(null, null);
                }
                else
                {
                    return;
                }
            }
            trainingCompleted = false;

            if (cbFuzzyARTMAPType.SelectedIndex == 1)
            {
                SetNoOfClusterEnabled(true, nudNoOfClasses.Value);
            }
            else
            {
                SetNoOfClusterEnabled(false, nudNoOfClusters.Value);
            }

            if (cbFuzzyARTMAPType.SelectedIndex == 3 || cbFuzzyARTMAPType.SelectedIndex == 4)
            {
                SetModifiedParametersControlsEnabled(true);
            }
            else
            {
                SetModifiedParametersControlsEnabled(false);
            }

            btnTrain.Enabled = true;
            btnCancelTrain.Enabled = false;
            btnTest.Enabled = false;
            ClearTrainingResult();
        }

        void SetNoOfClusterEnabled(bool enabled, decimal noOfCluster)
        {
            lblNoOfClusters.Enabled = nudNoOfClusters.Enabled = enabled;
            nudNoOfClusters.Value = noOfCluster;
        }

        void SetModifiedParametersControlsEnabled(bool enabled)
        {
            lblMaximumEntropy.Enabled = nudMaximumEntropy.Enabled = enabled;
            lblMaximumTotalEntropy.Enabled = nudMaximumTotalEntropy.Enabled = enabled;
            lblAdjustVigilanceRate.Enabled = nudAdjustVigilanceRate.Enabled = enabled;
        }

        void UpdateTrainingResult(SimplifiedFuzzyARTMap network, int epochs)
        {
            txtNoOfEpochs.Text = epochs.ToString();
            txtNoOfNeuronARTA.Text = network.ArtA.F2.Count.ToString();
            txtNoOfNeuronARTB.Text = network.ArtB.F2.Count.ToString();
            txtNoOfNeuronMAPField.Text = network.Map.Count.ToString();
            btnSaveWeights.Enabled = true;
            lnkMoreDetails.Visible = true;
        }

        void UpdateTrainingResult(ModifiedFuzzyARTMap network, int epochs)
        {
            txtNoOfEpochs.Text = epochs.ToString();
            txtNoOfNeuronARTA.Text = (network.Categories.GetUpperBound(0) + 1).ToString();
            txtNoOfNeuronARTB.Text = (network.NumberOfClasses).ToString();
            txtNoOfNeuronMAPField.Text = "Not used";
            btnSaveWeights.Enabled = true;
            lnkMoreDetails.Visible = true;
        }

        void ClearTrainingResult()
        {
            txtNoOfEpochs.Text = String.Empty;
            txtNoOfNeuronARTA.Text = String.Empty;
            txtNoOfNeuronARTB.Text = String.Empty;
            txtNoOfNeuronMAPField.Text = String.Empty;
            btnSaveWeights.Enabled = false;
            lnkMoreDetails.Visible = false;
        }

        void OpenFile(TextBox textBox)
        {
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Filter = "Text File (*.txt)|*.txt|Data File (*.dat)|*.dat";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog1.FileName;
            }
        }

        private void btnTrainingFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            OpenFile(txtTrainingFile);
        }

        private void btnTestFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            OpenFile(txtTestFile);
        }

        private void btnOutputFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = false;
            OpenFile(txtOutputFile);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            // Validate errors.
            if (txtTrainingFile.Text == string.Empty)
            {
                MessageBox.Show(this, "Training file mustn't be empty.", "Error");
                return;
            }
            if (txtTestFile.Text == string.Empty ||
                  txtOutputFile.Text == string.Empty)
            {
                MessageBox.Show(this, "Test file and output file mustn't be empty.", "Error");
                return;
            }
            if (nudInputSize.Value == 0)
            {
                MessageBox.Show(this, "Increment size mustn't be zero.");
                return;
            }
            if (nudTargetSize.Value == 0)
            {
                MessageBox.Show(this, "Target size mustn't be zero.");
                return;
            }
            if (nudNoOfClasses.Value == 0)
            {
                MessageBox.Show(this, "Number of Class mustn't be zero.");
                return;
            }
            // Get process parameter from GUI.
            if (cbFuzzyARTMAPType.SelectedIndex == 0)
            {
                parameter = new ProcessSimplifiedFuzzyARTMapParameter();
            }
            else if (cbFuzzyARTMAPType.SelectedIndex == 1)
            {
                parameter = new ProcessOrderedFuzzyARTMapParameter();
                ((ProcessOrderedFuzzyARTMapParameter)parameter).NoOfClusters
                    = Convert.ToInt32(nudNoOfClusters.Value);
            }
            else
            {
                ProcessModifiedHybridFuzzyARTMapParameter hybridParameter =
                    new ProcessModifiedHybridFuzzyARTMapParameter();

                if (cbFuzzyARTMAPType.SelectedIndex == 2)
                {
                    hybridParameter.Mode = ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL;
                }
                else
                {
                    // Recieve input from vigilance adjust rate, 
                    // maximum small entropy, maximum total entropy
                    hybridParameter.VigilanceAdjustRate = Convert.ToDouble(nudAdjustVigilanceRate.Value);
                    hybridParameter.MaximumEntropy = Convert.ToDouble(nudMaximumEntropy.Value);
                    hybridParameter.MaximumTotalEntropy = Convert.ToDouble(nudMaximumTotalEntropy.Value);

                    if (cbFuzzyARTMAPType.SelectedIndex == 3)
                    {
                        hybridParameter.Mode = ProcessModifiedHybridFuzzyARTMapMode.INTERNAL;
                    }
                    else if (cbFuzzyARTMAPType.SelectedIndex == 4)
                    {
                        hybridParameter.Mode = ProcessModifiedHybridFuzzyARTMapMode.DUAL;
                    }
                }
                parameter = hybridParameter;
            }

            // Set common properties of parameter.
            parameter.InputSize = Convert.ToInt32(nudInputSize.Value);
            parameter.TargetSize = Convert.ToInt32(nudTargetSize.Value);
            parameter.NoOfClasses = Convert.ToInt32(nudNoOfClasses.Value);
            parameter.TrainingFile = txtTrainingFile.Text;
            parameter.TestingFile = txtTestFile.Text;
            parameter.ArtABasedVigilance = Convert.ToDouble(nudARTABaseVigilance.Value);
            parameter.ChoicingParam = Convert.ToDouble(nudARTAChoiceValue.Value);
            parameter.ArtABeta = Convert.ToDouble(nudARTABeta.Value);
            parameter.LimitedMseValue = Convert.ToDouble(nudLimitedMSE.Value);
            parameter.LimitedEpochs = Convert.ToInt32(nudLimitedEpochs.Value);
            parameter.NormalizedValue = cbNormalizeInputData.Checked;

            // Process neural network.
            txtStatus.Text = "Waiting for training....";
            selectedTypeOfFuzzyARTMAP = cbFuzzyARTMAPType.SelectedIndex;
            btnTrain.Enabled = false;
            btnCancelTrain.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnCancelTrain_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.CancelAsync();
            //txtStatus.Text = "Cancel training process...";
            //btnTrain.Enabled = true;
            //btnCancelTrain.Enabled = false;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (trainingCompleted)
            {
                if (txtTestFile.Text == string.Empty ||
                    txtOutputFile.Text == string.Empty)
                {
                    MessageBox.Show(this, "Test file and output file mustn't be empty.", "Error");
                    return;
                }
                if (nudInputSize.Value == 0)
                {
                    MessageBox.Show(this, "Increment size mustn't be zero.");
                    return;
                }
                if (nudTargetSize.Value == 0)
                {
                    MessageBox.Show(this, "Target size mustn't be zero.");
                    return;
                }
                if (nudNoOfClasses.Value == 0)
                {
                    MessageBox.Show(this, "Number of Class mustn't be zero.");
                    return;
                }
                parameter.InputSize = Convert.ToInt32(nudInputSize.Value);
                parameter.TargetSize = Convert.ToInt32(nudTargetSize.Value);
                parameter.NoOfClasses = Convert.ToInt32(nudNoOfClasses.Value);
                parameter.TestingFile = txtTestFile.Text;
                parameter.OutputFile = txtOutputFile.Text;
                Form2 result = new Form2();
                result.OutputFile = txtOutputFile.Text;
                if (process is ProcessSimplifiedFuzzyARTMap)
                {
                    ProcessSimplifiedFuzzyARTMap processSimplified =
                        process as ProcessSimplifiedFuzzyARTMap;
                    processSimplified.Test();
                    result.Performance = processSimplified.Performance;
                }
                else if (process is ProcessOrderedFuzzyARTMap)
                {
                    ProcessOrderedFuzzyARTMap processOrdered =
                        process as ProcessOrderedFuzzyARTMap;
                    processOrdered.Test();
                    result.Performance = processOrdered.Performance;
                }
                else if (process is ProcessModifiedHybridFuzzyARTMap)
                {
                    ProcessModifiedHybridFuzzyARTMap processHybrid =
                        process as ProcessModifiedHybridFuzzyARTMap;
                    processHybrid.Test();
                    result.Performance = processHybrid.Performance;
                }
                result.ShowDialog();
            }
        }

        private void lnkMoreDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 moreDetails = new Form3();
            if (cbFuzzyARTMAPType.SelectedIndex == 0)
            {
                moreDetails.FArtMap = ((ProcessSimplifiedFuzzyARTMap)process).Network;
            }
            else if (cbFuzzyARTMAPType.SelectedIndex == 1)
            {
                moreDetails.FArtMap = ((ProcessOrderedFuzzyARTMap)process).Network.FuzzyARTMap;
            }
            else
            {
                ProcessModifiedHybridFuzzyARTMap processHybrid = (ProcessModifiedHybridFuzzyARTMap)process;
                if (processHybrid.Parameter.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL)
                {
                    moreDetails.FArtMap = processHybrid.FArtMap;
                }
                else
                {

                }
            }
            moreDetails.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (selectedTypeOfFuzzyARTMAP == 0)
                {
                    process = new ProcessSimplifiedFuzzyARTMap(parameter);
                    ((ProcessSimplifiedFuzzyARTMap)process).Train();
                }
                else if (selectedTypeOfFuzzyARTMAP == 1)
                {
                    process = new ProcessOrderedFuzzyARTMap(
                            (ProcessOrderedFuzzyARTMapParameter)parameter);
                    ((ProcessOrderedFuzzyARTMap)process).Train();
                }
                else
                {
                    process = new ProcessModifiedHybridFuzzyARTMap(
                        (ProcessModifiedHybridFuzzyARTMapParameter)parameter);
                    ((ProcessModifiedHybridFuzzyARTMap)process).Train();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Invalid dimension.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtStatus.Text = "Training Completed...and ready to testing.";
            btnCancelTrain.Enabled = false;
            btnTrain.Enabled = true;
            btnTest.Enabled = true;
            trainingCompleted = true;

            // Update training result panel.
            if (selectedTypeOfFuzzyARTMAP == 0)
            {
                ProcessSimplifiedFuzzyARTMap processSimplified = (ProcessSimplifiedFuzzyARTMap)process;
                UpdateTrainingResult(processSimplified.Network, processSimplified.Performance.Count);
            }
            else if (selectedTypeOfFuzzyARTMAP == 1)
            {
                ProcessOrderedFuzzyARTMap processOrdered = (ProcessOrderedFuzzyARTMap)process;
                UpdateTrainingResult(processOrdered.Network.FuzzyARTMap, processOrdered.Performance.Count);
            }
            else if (selectedTypeOfFuzzyARTMAP == 2)
            {
                ProcessModifiedHybridFuzzyARTMap processExternal = (ProcessModifiedHybridFuzzyARTMap)process;
                UpdateTrainingResult(processExternal.FArtMap, processExternal.Performance.Count);
            }
            else
            {
                ProcessModifiedHybridFuzzyARTMap processHybrid = (ProcessModifiedHybridFuzzyARTMap)process;
                UpdateTrainingResult(processHybrid.MArtMap, processHybrid.Performance.Count);
            }
        }

        private void btnLoadWeights_Click(object sender, EventArgs e)
        {
            //SimplifiedFuzzyARTMap network = null;

            //openFileDialog1.CheckFileExists = true;
            //openFileDialog1.FileName = String.Empty;
            //openFileDialog1.Filter = "Neural Network Data (*.nnd)|*.nnd";
            //openFileDialog1.FilterIndex = 1;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    SimplifiedFuzzyARTMapSerializer serializer =
            //        new SimplifiedFuzzyARTMapSerializer();
            //    network = serializer.DeSerialize(openFileDialog1.FileName);
            //}

            //if (network != null)
            //{
            //    if (cbFuzzyARTMAPType.SelectedIndex == 0)
            //    {
            //        ProcessSimplifiedFuzzyARTMap processSimplified = 
            //            new ProcessSimplifiedFuzzyARTMap();
            //        processSimplified.Network = network;
            //    }
            //    else if (cbFuzzyARTMAPType.SelectedIndex == 1)
            //    {
            //        ProcessOrderedFuzzyARTMap processOrdered =
            //            new ProcessOrderedFuzzyARTMap();
            //        processOrdered.Network = new OrderedFuzzyARTMap(
            //    }
            //    // Update form values.
            //    trainingCompleted = true;
            //    btnTest.Enabled = true;
            //}
        }

        private void btnSaveWeights_Click(object sender, EventArgs e)
        {
            //if (trainingCompleted)
            //{
            //    saveFileDialog1.FileName = String.Empty;
            //    saveFileDialog1.Filter = "Nerual Network Data (*.nnd)|*.nnd";
            //    saveFileDialog1.FilterIndex = 1;
            //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //    {
            //        SimplifiedFuzzyARTMapSerializer serializer =
            //            new SimplifiedFuzzyARTMapSerializer();
            //        if (cbFuzzyARTMAPType.SelectedIndex == 0)
            //            serializer.Serialize(saveFileDialog1.FileName, ((ProcessSimplifiedFuzzyARTMap)process).Network);
            //        else if (cbFuzzyARTMAPType.SelectedIndex == 1)
            //            serializer.Serialize(saveFileDialog1.FileName, ((ProcessOrderedFuzzyARTMap)process).Network.FuzzyARTMap);
            //    }
            //}
        }
    }
}
