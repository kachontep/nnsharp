namespace FuzzyARTMapGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFuzzyARTMapOptions = new System.Windows.Forms.GroupBox();
            this.nudMaximumTotalEntropy = new System.Windows.Forms.NumericUpDown();
            this.lblMaximumTotalEntropy = new System.Windows.Forms.Label();
            this.nudMaximumEntropy = new System.Windows.Forms.NumericUpDown();
            this.lblMaximumEntropy = new System.Windows.Forms.Label();
            this.nudAdjustVigilanceRate = new System.Windows.Forms.NumericUpDown();
            this.lblAdjustVigilanceRate = new System.Windows.Forms.Label();
            this.nudLimitedEpochs = new System.Windows.Forms.NumericUpDown();
            this.lblLimitedEpochs = new System.Windows.Forms.Label();
            this.nudLimitedMSE = new System.Windows.Forms.NumericUpDown();
            this.lblLimitedMSE = new System.Windows.Forms.Label();
            this.nudARTABeta = new System.Windows.Forms.NumericUpDown();
            this.lblARTABeta = new System.Windows.Forms.Label();
            this.nudNoOfClusters = new System.Windows.Forms.NumericUpDown();
            this.lblNoOfClusters = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudARTABaseVigilance = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudARTAChoiceValue = new System.Windows.Forms.NumericUpDown();
            this.gbTrainingResult = new System.Windows.Forms.GroupBox();
            this.btnLoadWeights = new System.Windows.Forms.Button();
            this.btnSaveWeights = new System.Windows.Forms.Button();
            this.lnkMoreDetails = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEpochTimes = new System.Windows.Forms.Label();
            this.txtNoOfNeuronMAPField = new System.Windows.Forms.TextBox();
            this.lblNoNeuronMF = new System.Windows.Forms.Label();
            this.txtNoOfNeuronARTB = new System.Windows.Forms.TextBox();
            this.txtNoOfEpochs = new System.Windows.Forms.TextBox();
            this.txtNoOfNeuronARTA = new System.Windows.Forms.TextBox();
            this.lblNoNeuronARTBF2 = new System.Windows.Forms.Label();
            this.lblNoNeuronARTAF2 = new System.Windows.Forms.Label();
            this.gbDataOptions = new System.Windows.Forms.GroupBox();
            this.cbNormalizeInputData = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudNoOfClasses = new System.Windows.Forms.NumericUpDown();
            this.lblNoOfClasses = new System.Windows.Forms.Label();
            this.nudTargetSize = new System.Windows.Forms.NumericUpDown();
            this.nudInputSize = new System.Windows.Forms.NumericUpDown();
            this.lblTargetSize = new System.Windows.Forms.Label();
            this.lblInputSize = new System.Windows.Forms.Label();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.btnTestFile = new System.Windows.Forms.Button();
            this.txtTestFile = new System.Windows.Forms.TextBox();
            this.lblTestFile = new System.Windows.Forms.Label();
            this.btnTrainingFile = new System.Windows.Forms.Button();
            this.txtTrainingFile = new System.Windows.Forms.TextBox();
            this.lblTrainingFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbFuzzyARTMAPType = new System.Windows.Forms.ComboBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnCancelTrain = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTypeOfFuzzyARTMAP = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gbFuzzyARTMapOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumTotalEntropy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumEntropy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdjustVigilanceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitedEpochs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitedMSE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudARTABeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudARTABaseVigilance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudARTAChoiceValue)).BeginInit();
            this.gbTrainingResult.SuspendLayout();
            this.gbDataOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInputSize)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFuzzyARTMapOptions
            // 
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudMaximumTotalEntropy);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblMaximumTotalEntropy);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudMaximumEntropy);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblMaximumEntropy);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudAdjustVigilanceRate);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblAdjustVigilanceRate);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudLimitedEpochs);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblLimitedEpochs);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudLimitedMSE);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblLimitedMSE);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudARTABeta);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblARTABeta);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudNoOfClusters);
            this.gbFuzzyARTMapOptions.Controls.Add(this.lblNoOfClusters);
            this.gbFuzzyARTMapOptions.Controls.Add(this.label8);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudARTABaseVigilance);
            this.gbFuzzyARTMapOptions.Controls.Add(this.label9);
            this.gbFuzzyARTMapOptions.Controls.Add(this.nudARTAChoiceValue);
            this.gbFuzzyARTMapOptions.Location = new System.Drawing.Point(12, 58);
            this.gbFuzzyARTMapOptions.Name = "gbFuzzyARTMapOptions";
            this.gbFuzzyARTMapOptions.Size = new System.Drawing.Size(227, 229);
            this.gbFuzzyARTMapOptions.TabIndex = 0;
            this.gbFuzzyARTMapOptions.TabStop = false;
            this.gbFuzzyARTMapOptions.Text = "Fuzzy ARTMAP Options";
            // 
            // nudMaximumTotalEntropy
            // 
            this.nudMaximumTotalEntropy.DecimalPlaces = 3;
            this.nudMaximumTotalEntropy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudMaximumTotalEntropy.Location = new System.Drawing.Point(138, 204);
            this.nudMaximumTotalEntropy.Name = "nudMaximumTotalEntropy";
            this.nudMaximumTotalEntropy.Size = new System.Drawing.Size(80, 20);
            this.nudMaximumTotalEntropy.TabIndex = 18;
            this.nudMaximumTotalEntropy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaximumTotalEntropy
            // 
            this.lblMaximumTotalEntropy.AutoSize = true;
            this.lblMaximumTotalEntropy.Location = new System.Drawing.Point(9, 207);
            this.lblMaximumTotalEntropy.Name = "lblMaximumTotalEntropy";
            this.lblMaximumTotalEntropy.Size = new System.Drawing.Size(117, 13);
            this.lblMaximumTotalEntropy.TabIndex = 17;
            this.lblMaximumTotalEntropy.Text = "Maximum Total Entropy";
            // 
            // nudMaximumEntropy
            // 
            this.nudMaximumEntropy.DecimalPlaces = 3;
            this.nudMaximumEntropy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudMaximumEntropy.Location = new System.Drawing.Point(138, 181);
            this.nudMaximumEntropy.Name = "nudMaximumEntropy";
            this.nudMaximumEntropy.Size = new System.Drawing.Size(80, 20);
            this.nudMaximumEntropy.TabIndex = 16;
            this.nudMaximumEntropy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaximumEntropy
            // 
            this.lblMaximumEntropy.AutoSize = true;
            this.lblMaximumEntropy.Location = new System.Drawing.Point(9, 184);
            this.lblMaximumEntropy.Name = "lblMaximumEntropy";
            this.lblMaximumEntropy.Size = new System.Drawing.Size(90, 13);
            this.lblMaximumEntropy.TabIndex = 15;
            this.lblMaximumEntropy.Text = "Maximum Entropy";
            // 
            // nudAdjustVigilanceRate
            // 
            this.nudAdjustVigilanceRate.DecimalPlaces = 3;
            this.nudAdjustVigilanceRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudAdjustVigilanceRate.Location = new System.Drawing.Point(138, 157);
            this.nudAdjustVigilanceRate.Name = "nudAdjustVigilanceRate";
            this.nudAdjustVigilanceRate.Size = new System.Drawing.Size(80, 20);
            this.nudAdjustVigilanceRate.TabIndex = 14;
            this.nudAdjustVigilanceRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAdjustVigilanceRate
            // 
            this.lblAdjustVigilanceRate.AutoSize = true;
            this.lblAdjustVigilanceRate.Location = new System.Drawing.Point(9, 160);
            this.lblAdjustVigilanceRate.Name = "lblAdjustVigilanceRate";
            this.lblAdjustVigilanceRate.Size = new System.Drawing.Size(108, 13);
            this.lblAdjustVigilanceRate.TabIndex = 13;
            this.lblAdjustVigilanceRate.Text = "Adjust Vigilance Rate";
            // 
            // nudLimitedEpochs
            // 
            this.nudLimitedEpochs.Location = new System.Drawing.Point(137, 85);
            this.nudLimitedEpochs.Name = "nudLimitedEpochs";
            this.nudLimitedEpochs.Size = new System.Drawing.Size(81, 20);
            this.nudLimitedEpochs.TabIndex = 12;
            this.nudLimitedEpochs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLimitedEpochs
            // 
            this.lblLimitedEpochs.AutoSize = true;
            this.lblLimitedEpochs.Location = new System.Drawing.Point(9, 87);
            this.lblLimitedEpochs.Name = "lblLimitedEpochs";
            this.lblLimitedEpochs.Size = new System.Drawing.Size(79, 13);
            this.lblLimitedEpochs.TabIndex = 11;
            this.lblLimitedEpochs.Text = "Limited Epochs";
            // 
            // nudLimitedMSE
            // 
            this.nudLimitedMSE.DecimalPlaces = 8;
            this.nudLimitedMSE.Increment = new decimal(new int[] {
            1,
            0,
            0,
            524288});
            this.nudLimitedMSE.Location = new System.Drawing.Point(137, 110);
            this.nudLimitedMSE.Name = "nudLimitedMSE";
            this.nudLimitedMSE.Size = new System.Drawing.Size(81, 20);
            this.nudLimitedMSE.TabIndex = 10;
            this.nudLimitedMSE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLimitedMSE.Value = new decimal(new int[] {
            1,
            0,
            0,
            524288});
            // 
            // lblLimitedMSE
            // 
            this.lblLimitedMSE.AutoSize = true;
            this.lblLimitedMSE.Location = new System.Drawing.Point(9, 112);
            this.lblLimitedMSE.Name = "lblLimitedMSE";
            this.lblLimitedMSE.Size = new System.Drawing.Size(66, 13);
            this.lblLimitedMSE.TabIndex = 9;
            this.lblLimitedMSE.Text = "Limited MSE";
            // 
            // nudARTABeta
            // 
            this.nudARTABeta.DecimalPlaces = 3;
            this.nudARTABeta.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.nudARTABeta.Location = new System.Drawing.Point(137, 60);
            this.nudARTABeta.Name = "nudARTABeta";
            this.nudARTABeta.Size = new System.Drawing.Size(81, 20);
            this.nudARTABeta.TabIndex = 8;
            this.nudARTABeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudARTABeta.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // lblARTABeta
            // 
            this.lblARTABeta.AutoSize = true;
            this.lblARTABeta.Location = new System.Drawing.Point(9, 63);
            this.lblARTABeta.Name = "lblARTABeta";
            this.lblARTABeta.Size = new System.Drawing.Size(74, 13);
            this.lblARTABeta.TabIndex = 7;
            this.lblARTABeta.Text = "Learning Rate";
            // 
            // nudNoOfClusters
            // 
            this.nudNoOfClusters.Location = new System.Drawing.Point(137, 133);
            this.nudNoOfClusters.Name = "nudNoOfClusters";
            this.nudNoOfClusters.Size = new System.Drawing.Size(81, 20);
            this.nudNoOfClusters.TabIndex = 6;
            this.nudNoOfClusters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNoOfClusters
            // 
            this.lblNoOfClusters.AutoSize = true;
            this.lblNoOfClusters.Location = new System.Drawing.Point(8, 137);
            this.lblNoOfClusters.Name = "lblNoOfClusters";
            this.lblNoOfClusters.Size = new System.Drawing.Size(96, 13);
            this.lblNoOfClusters.TabIndex = 5;
            this.lblNoOfClusters.Text = "Number of Clusters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "ART-A Vigilance";
            // 
            // nudARTABaseVigilance
            // 
            this.nudARTABaseVigilance.DecimalPlaces = 3;
            this.nudARTABaseVigilance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.nudARTABaseVigilance.Location = new System.Drawing.Point(137, 13);
            this.nudARTABaseVigilance.Name = "nudARTABaseVigilance";
            this.nudARTABaseVigilance.Size = new System.Drawing.Size(81, 20);
            this.nudARTABaseVigilance.TabIndex = 3;
            this.nudARTABaseVigilance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudARTABaseVigilance.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "ART-A Choice Value";
            // 
            // nudARTAChoiceValue
            // 
            this.nudARTAChoiceValue.DecimalPlaces = 3;
            this.nudARTAChoiceValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudARTAChoiceValue.Location = new System.Drawing.Point(137, 36);
            this.nudARTAChoiceValue.Name = "nudARTAChoiceValue";
            this.nudARTAChoiceValue.Size = new System.Drawing.Size(81, 20);
            this.nudARTAChoiceValue.TabIndex = 4;
            this.nudARTAChoiceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudARTAChoiceValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // gbTrainingResult
            // 
            this.gbTrainingResult.Controls.Add(this.btnLoadWeights);
            this.gbTrainingResult.Controls.Add(this.btnSaveWeights);
            this.gbTrainingResult.Controls.Add(this.lnkMoreDetails);
            this.gbTrainingResult.Controls.Add(this.label7);
            this.gbTrainingResult.Controls.Add(this.label6);
            this.gbTrainingResult.Controls.Add(this.label5);
            this.gbTrainingResult.Controls.Add(this.label4);
            this.gbTrainingResult.Controls.Add(this.lblEpochTimes);
            this.gbTrainingResult.Controls.Add(this.txtNoOfNeuronMAPField);
            this.gbTrainingResult.Controls.Add(this.lblNoNeuronMF);
            this.gbTrainingResult.Controls.Add(this.txtNoOfNeuronARTB);
            this.gbTrainingResult.Controls.Add(this.txtNoOfEpochs);
            this.gbTrainingResult.Controls.Add(this.txtNoOfNeuronARTA);
            this.gbTrainingResult.Controls.Add(this.lblNoNeuronARTBF2);
            this.gbTrainingResult.Controls.Add(this.lblNoNeuronARTAF2);
            this.gbTrainingResult.Location = new System.Drawing.Point(245, 243);
            this.gbTrainingResult.Name = "gbTrainingResult";
            this.gbTrainingResult.Size = new System.Drawing.Size(375, 191);
            this.gbTrainingResult.TabIndex = 1;
            this.gbTrainingResult.TabStop = false;
            this.gbTrainingResult.Text = "Training Result";
            // 
            // btnLoadWeights
            // 
            this.btnLoadWeights.Location = new System.Drawing.Point(130, 156);
            this.btnLoadWeights.Name = "btnLoadWeights";
            this.btnLoadWeights.Size = new System.Drawing.Size(96, 23);
            this.btnLoadWeights.TabIndex = 9;
            this.btnLoadWeights.Text = "Load Weights";
            this.btnLoadWeights.UseVisualStyleBackColor = true;
            this.btnLoadWeights.Visible = false;
            this.btnLoadWeights.Click += new System.EventHandler(this.btnLoadWeights_Click);
            // 
            // btnSaveWeights
            // 
            this.btnSaveWeights.Enabled = false;
            this.btnSaveWeights.Location = new System.Drawing.Point(15, 156);
            this.btnSaveWeights.Name = "btnSaveWeights";
            this.btnSaveWeights.Size = new System.Drawing.Size(109, 23);
            this.btnSaveWeights.TabIndex = 8;
            this.btnSaveWeights.Text = "Save Weights";
            this.btnSaveWeights.UseVisualStyleBackColor = true;
            this.btnSaveWeights.Visible = false;
            this.btnSaveWeights.Click += new System.EventHandler(this.btnSaveWeights_Click);
            // 
            // lnkMoreDetails
            // 
            this.lnkMoreDetails.AutoSize = true;
            this.lnkMoreDetails.Location = new System.Drawing.Point(286, 161);
            this.lnkMoreDetails.Name = "lnkMoreDetails";
            this.lnkMoreDetails.Size = new System.Drawing.Size(75, 13);
            this.lnkMoreDetails.TabIndex = 7;
            this.lnkMoreDetails.TabStop = true;
            this.lnkMoreDetails.Text = "More Details ..";
            this.lnkMoreDetails.Visible = false;
            this.lnkMoreDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMoreDetails_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Neuron(s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(288, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Neuron(s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Neuron(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Epoch(s)";
            // 
            // lblEpochTimes
            // 
            this.lblEpochTimes.AutoSize = true;
            this.lblEpochTimes.Location = new System.Drawing.Point(71, 31);
            this.lblEpochTimes.Name = "lblEpochTimes";
            this.lblEpochTimes.Size = new System.Drawing.Size(97, 13);
            this.lblEpochTimes.TabIndex = 5;
            this.lblEpochTimes.Text = "Number of Training";
            // 
            // txtNoOfNeuronMAPField
            // 
            this.txtNoOfNeuronMAPField.Location = new System.Drawing.Point(188, 121);
            this.txtNoOfNeuronMAPField.Name = "txtNoOfNeuronMAPField";
            this.txtNoOfNeuronMAPField.ReadOnly = true;
            this.txtNoOfNeuronMAPField.Size = new System.Drawing.Size(95, 20);
            this.txtNoOfNeuronMAPField.TabIndex = 4;
            this.txtNoOfNeuronMAPField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNoNeuronMF
            // 
            this.lblNoNeuronMF.AutoSize = true;
            this.lblNoNeuronMF.Location = new System.Drawing.Point(12, 124);
            this.lblNoNeuronMF.Name = "lblNoNeuronMF";
            this.lblNoNeuronMF.Size = new System.Drawing.Size(156, 13);
            this.lblNoNeuronMF.TabIndex = 3;
            this.lblNoNeuronMF.Text = "Number of Neurons (MAP Field)";
            // 
            // txtNoOfNeuronARTB
            // 
            this.txtNoOfNeuronARTB.Location = new System.Drawing.Point(188, 89);
            this.txtNoOfNeuronARTB.Name = "txtNoOfNeuronARTB";
            this.txtNoOfNeuronARTB.ReadOnly = true;
            this.txtNoOfNeuronARTB.Size = new System.Drawing.Size(95, 20);
            this.txtNoOfNeuronARTB.TabIndex = 2;
            this.txtNoOfNeuronARTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNoOfEpochs
            // 
            this.txtNoOfEpochs.Location = new System.Drawing.Point(188, 28);
            this.txtNoOfEpochs.Name = "txtNoOfEpochs";
            this.txtNoOfEpochs.ReadOnly = true;
            this.txtNoOfEpochs.Size = new System.Drawing.Size(95, 20);
            this.txtNoOfEpochs.TabIndex = 2;
            this.txtNoOfEpochs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNoOfNeuronARTA
            // 
            this.txtNoOfNeuronARTA.Location = new System.Drawing.Point(188, 59);
            this.txtNoOfNeuronARTA.Name = "txtNoOfNeuronARTA";
            this.txtNoOfNeuronARTA.ReadOnly = true;
            this.txtNoOfNeuronARTA.Size = new System.Drawing.Size(95, 20);
            this.txtNoOfNeuronARTA.TabIndex = 2;
            this.txtNoOfNeuronARTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNoNeuronARTBF2
            // 
            this.lblNoNeuronARTBF2.AutoSize = true;
            this.lblNoNeuronARTBF2.Location = new System.Drawing.Point(12, 92);
            this.lblNoNeuronARTBF2.Name = "lblNoNeuronARTBF2";
            this.lblNoNeuronARTBF2.Size = new System.Drawing.Size(155, 13);
            this.lblNoNeuronARTBF2.TabIndex = 1;
            this.lblNoNeuronARTBF2.Text = "Number of Neurons (ART-B F2)";
            // 
            // lblNoNeuronARTAF2
            // 
            this.lblNoNeuronARTAF2.AutoSize = true;
            this.lblNoNeuronARTAF2.Location = new System.Drawing.Point(12, 62);
            this.lblNoNeuronARTAF2.Name = "lblNoNeuronARTAF2";
            this.lblNoNeuronARTAF2.Size = new System.Drawing.Size(155, 13);
            this.lblNoNeuronARTAF2.TabIndex = 1;
            this.lblNoNeuronARTAF2.Text = "Number of Neurons (ART-A F2)";
            // 
            // gbDataOptions
            // 
            this.gbDataOptions.Controls.Add(this.cbNormalizeInputData);
            this.gbDataOptions.Controls.Add(this.label3);
            this.gbDataOptions.Controls.Add(this.label2);
            this.gbDataOptions.Controls.Add(this.label1);
            this.gbDataOptions.Controls.Add(this.nudNoOfClasses);
            this.gbDataOptions.Controls.Add(this.lblNoOfClasses);
            this.gbDataOptions.Controls.Add(this.nudTargetSize);
            this.gbDataOptions.Controls.Add(this.nudInputSize);
            this.gbDataOptions.Controls.Add(this.lblTargetSize);
            this.gbDataOptions.Controls.Add(this.lblInputSize);
            this.gbDataOptions.Controls.Add(this.btnOutputFile);
            this.gbDataOptions.Controls.Add(this.txtOutputFile);
            this.gbDataOptions.Controls.Add(this.lblOutputFile);
            this.gbDataOptions.Controls.Add(this.btnTestFile);
            this.gbDataOptions.Controls.Add(this.txtTestFile);
            this.gbDataOptions.Controls.Add(this.lblTestFile);
            this.gbDataOptions.Controls.Add(this.btnTrainingFile);
            this.gbDataOptions.Controls.Add(this.txtTrainingFile);
            this.gbDataOptions.Controls.Add(this.lblTrainingFile);
            this.gbDataOptions.Location = new System.Drawing.Point(245, 13);
            this.gbDataOptions.Name = "gbDataOptions";
            this.gbDataOptions.Size = new System.Drawing.Size(375, 224);
            this.gbDataOptions.TabIndex = 2;
            this.gbDataOptions.TabStop = false;
            this.gbDataOptions.Text = "DataSet Options";
            // 
            // cbNormalizeInputData
            // 
            this.cbNormalizeInputData.AutoSize = true;
            this.cbNormalizeInputData.Location = new System.Drawing.Point(32, 197);
            this.cbNormalizeInputData.Name = "cbNormalizeInputData";
            this.cbNormalizeInputData.Size = new System.Drawing.Size(104, 17);
            this.cbNormalizeInputData.TabIndex = 16;
            this.cbNormalizeInputData.Text = "Normalized Data";
            this.cbNormalizeInputData.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Class(es)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Column(s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Column(s)";
            // 
            // nudNoOfClasses
            // 
            this.nudNoOfClasses.Location = new System.Drawing.Point(141, 171);
            this.nudNoOfClasses.Name = "nudNoOfClasses";
            this.nudNoOfClasses.Size = new System.Drawing.Size(120, 20);
            this.nudNoOfClasses.TabIndex = 14;
            this.nudNoOfClasses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNoOfClasses
            // 
            this.lblNoOfClasses.AutoSize = true;
            this.lblNoOfClasses.Location = new System.Drawing.Point(29, 173);
            this.lblNoOfClasses.Name = "lblNoOfClasses";
            this.lblNoOfClasses.Size = new System.Drawing.Size(95, 13);
            this.lblNoOfClasses.TabIndex = 13;
            this.lblNoOfClasses.Text = "Number of Classes";
            // 
            // nudTargetSize
            // 
            this.nudTargetSize.Location = new System.Drawing.Point(141, 143);
            this.nudTargetSize.Name = "nudTargetSize";
            this.nudTargetSize.Size = new System.Drawing.Size(120, 20);
            this.nudTargetSize.TabIndex = 12;
            this.nudTargetSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudInputSize
            // 
            this.nudInputSize.Location = new System.Drawing.Point(141, 114);
            this.nudInputSize.Name = "nudInputSize";
            this.nudInputSize.Size = new System.Drawing.Size(120, 20);
            this.nudInputSize.TabIndex = 11;
            this.nudInputSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTargetSize
            // 
            this.lblTargetSize.AutoSize = true;
            this.lblTargetSize.Location = new System.Drawing.Point(63, 145);
            this.lblTargetSize.Name = "lblTargetSize";
            this.lblTargetSize.Size = new System.Drawing.Size(61, 13);
            this.lblTargetSize.TabIndex = 10;
            this.lblTargetSize.Text = "Target Size";
            // 
            // lblInputSize
            // 
            this.lblInputSize.AutoSize = true;
            this.lblInputSize.Location = new System.Drawing.Point(70, 116);
            this.lblInputSize.Name = "lblInputSize";
            this.lblInputSize.Size = new System.Drawing.Size(54, 13);
            this.lblInputSize.TabIndex = 9;
            this.lblInputSize.Text = "Input Size";
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(286, 83);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(75, 23);
            this.btnOutputFile.TabIndex = 8;
            this.btnOutputFile.Text = "Choose";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.btnOutputFile_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(78, 84);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(202, 20);
            this.txtOutputFile.TabIndex = 7;
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(8, 88);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(58, 13);
            this.lblOutputFile.TabIndex = 6;
            this.lblOutputFile.Text = "Output File";
            // 
            // btnTestFile
            // 
            this.btnTestFile.Location = new System.Drawing.Point(286, 54);
            this.btnTestFile.Name = "btnTestFile";
            this.btnTestFile.Size = new System.Drawing.Size(75, 23);
            this.btnTestFile.TabIndex = 5;
            this.btnTestFile.Text = "Choose";
            this.btnTestFile.UseVisualStyleBackColor = true;
            this.btnTestFile.Click += new System.EventHandler(this.btnTestFile_Click);
            // 
            // txtTestFile
            // 
            this.txtTestFile.Location = new System.Drawing.Point(78, 55);
            this.txtTestFile.Name = "txtTestFile";
            this.txtTestFile.Size = new System.Drawing.Size(202, 20);
            this.txtTestFile.TabIndex = 4;
            // 
            // lblTestFile
            // 
            this.lblTestFile.AutoSize = true;
            this.lblTestFile.Location = new System.Drawing.Point(8, 59);
            this.lblTestFile.Name = "lblTestFile";
            this.lblTestFile.Size = new System.Drawing.Size(47, 13);
            this.lblTestFile.TabIndex = 3;
            this.lblTestFile.Text = "Test File";
            // 
            // btnTrainingFile
            // 
            this.btnTrainingFile.Location = new System.Drawing.Point(287, 21);
            this.btnTrainingFile.Name = "btnTrainingFile";
            this.btnTrainingFile.Size = new System.Drawing.Size(75, 23);
            this.btnTrainingFile.TabIndex = 2;
            this.btnTrainingFile.Text = "Choose";
            this.btnTrainingFile.UseVisualStyleBackColor = true;
            this.btnTrainingFile.Click += new System.EventHandler(this.btnTrainingFile_Click);
            // 
            // txtTrainingFile
            // 
            this.txtTrainingFile.Location = new System.Drawing.Point(78, 22);
            this.txtTrainingFile.Name = "txtTrainingFile";
            this.txtTrainingFile.Size = new System.Drawing.Size(202, 20);
            this.txtTrainingFile.TabIndex = 1;
            // 
            // lblTrainingFile
            // 
            this.lblTrainingFile.AutoSize = true;
            this.lblTrainingFile.Location = new System.Drawing.Point(8, 26);
            this.lblTrainingFile.Name = "lblTrainingFile";
            this.lblTrainingFile.Size = new System.Drawing.Size(64, 13);
            this.lblTrainingFile.TabIndex = 0;
            this.lblTrainingFile.Text = "Training File";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbFuzzyARTMAPType
            // 
            this.cbFuzzyARTMAPType.FormattingEnabled = true;
            this.cbFuzzyARTMAPType.Items.AddRange(new object[] {
            "Simplified Fuzzy ARTMAP",
            "Ordered Fuzzy ARTMAP",
            "Modified External Fuzzy ARTMAP",
            "Modified Internal Fuzzy ARTMAP",
            "Modified Hybrid Fuzzy ARTMAP"});
            this.cbFuzzyARTMAPType.Location = new System.Drawing.Point(15, 31);
            this.cbFuzzyARTMAPType.Name = "cbFuzzyARTMAPType";
            this.cbFuzzyARTMAPType.Size = new System.Drawing.Size(224, 21);
            this.cbFuzzyARTMAPType.TabIndex = 4;
            this.cbFuzzyARTMAPType.SelectedIndexChanged += new System.EventHandler(this.cbFuzzyARTMAPType_SelectedIndexChanged);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(12, 353);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(227, 23);
            this.btnTrain.TabIndex = 5;
            this.btnTrain.Text = "Train Neuron Network";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(12, 411);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(227, 23);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Test Neural Network";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(15, 303);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(224, 45);
            this.txtStatus.TabIndex = 8;
            this.txtStatus.Text = "Choose type of Fuzzy ARTMAP and dataset files.";
            // 
            // btnCancelTrain
            // 
            this.btnCancelTrain.Enabled = false;
            this.btnCancelTrain.Location = new System.Drawing.Point(12, 382);
            this.btnCancelTrain.Name = "btnCancelTrain";
            this.btnCancelTrain.Size = new System.Drawing.Size(227, 23);
            this.btnCancelTrain.TabIndex = 10;
            this.btnCancelTrain.Text = "Cancel Train Neural Network";
            this.btnCancelTrain.UseVisualStyleBackColor = true;
            this.btnCancelTrain.Visible = false;
            this.btnCancelTrain.Click += new System.EventHandler(this.btnCancelTrain_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStatus.Location = new System.Drawing.Point(12, 287);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status";
            // 
            // lblTypeOfFuzzyARTMAP
            // 
            this.lblTypeOfFuzzyARTMAP.AutoSize = true;
            this.lblTypeOfFuzzyARTMAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTypeOfFuzzyARTMAP.Location = new System.Drawing.Point(12, 9);
            this.lblTypeOfFuzzyARTMAP.Name = "lblTypeOfFuzzyARTMAP";
            this.lblTypeOfFuzzyARTMAP.Size = new System.Drawing.Size(141, 13);
            this.lblTypeOfFuzzyARTMAP.TabIndex = 12;
            this.lblTypeOfFuzzyARTMAP.Text = "Type of Fuzzy ARTMAP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.lblTypeOfFuzzyARTMAP);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnCancelTrain);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.cbFuzzyARTMAPType);
            this.Controls.Add(this.gbDataOptions);
            this.Controls.Add(this.gbTrainingResult);
            this.Controls.Add(this.gbFuzzyARTMapOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuzzy ARTMAP GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbFuzzyARTMapOptions.ResumeLayout(false);
            this.gbFuzzyARTMapOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumTotalEntropy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaximumEntropy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdjustVigilanceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitedEpochs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLimitedMSE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudARTABeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudARTABaseVigilance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudARTAChoiceValue)).EndInit();
            this.gbTrainingResult.ResumeLayout(false);
            this.gbTrainingResult.PerformLayout();
            this.gbDataOptions.ResumeLayout(false);
            this.gbDataOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInputSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFuzzyARTMapOptions;
        private System.Windows.Forms.GroupBox gbTrainingResult;
        private System.Windows.Forms.GroupBox gbDataOptions;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.Button btnTestFile;
        private System.Windows.Forms.TextBox txtTestFile;
        private System.Windows.Forms.Label lblTestFile;
        private System.Windows.Forms.Button btnTrainingFile;
        private System.Windows.Forms.TextBox txtTrainingFile;
        private System.Windows.Forms.Label lblTrainingFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTargetSize;
        private System.Windows.Forms.Label lblInputSize;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.ComboBox cbFuzzyARTMAPType;
        private System.Windows.Forms.NumericUpDown nudNoOfClasses;
        private System.Windows.Forms.Label lblNoOfClasses;
        private System.Windows.Forms.NumericUpDown nudTargetSize;
        private System.Windows.Forms.NumericUpDown nudInputSize;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtNoOfNeuronARTA;
        private System.Windows.Forms.Label lblNoNeuronARTAF2;
        private System.Windows.Forms.TextBox txtNoOfNeuronMAPField;
        private System.Windows.Forms.Label lblNoNeuronMF;
        private System.Windows.Forms.TextBox txtNoOfNeuronARTB;
        private System.Windows.Forms.Label lblNoNeuronARTBF2;
        private System.Windows.Forms.Button btnCancelTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEpochTimes;
        private System.Windows.Forms.TextBox txtNoOfEpochs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudARTABaseVigilance;
        private System.Windows.Forms.NumericUpDown nudARTAChoiceValue;
        private System.Windows.Forms.NumericUpDown nudNoOfClusters;
        private System.Windows.Forms.Label lblNoOfClusters;
        private System.Windows.Forms.LinkLabel lnkMoreDetails;
        private System.Windows.Forms.NumericUpDown nudARTABeta;
        private System.Windows.Forms.Label lblARTABeta;
        private System.Windows.Forms.NumericUpDown nudLimitedMSE;
        private System.Windows.Forms.Label lblLimitedMSE;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnLoadWeights;
        private System.Windows.Forms.Button btnSaveWeights;
        private System.Windows.Forms.Label lblLimitedEpochs;
        private System.Windows.Forms.NumericUpDown nudLimitedEpochs;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTypeOfFuzzyARTMAP;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown nudAdjustVigilanceRate;
        private System.Windows.Forms.Label lblAdjustVigilanceRate;
        private System.Windows.Forms.NumericUpDown nudMaximumTotalEntropy;
        private System.Windows.Forms.Label lblMaximumTotalEntropy;
        private System.Windows.Forms.NumericUpDown nudMaximumEntropy;
        private System.Windows.Forms.Label lblMaximumEntropy;
        private System.Windows.Forms.CheckBox cbNormalizeInputData;
    }
}

