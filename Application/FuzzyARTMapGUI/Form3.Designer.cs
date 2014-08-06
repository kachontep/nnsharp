namespace FuzzyARTMapGUI
{
    partial class Form3
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
            this.lblWeights = new System.Windows.Forms.Label();
            this.dgvWeights = new System.Windows.Forms.DataGridView();
            this.cbWeights = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeights)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWeights
            // 
            this.lblWeights.AutoSize = true;
            this.lblWeights.Location = new System.Drawing.Point(401, 15);
            this.lblWeights.Name = "lblWeights";
            this.lblWeights.Size = new System.Drawing.Size(58, 13);
            this.lblWeights.TabIndex = 0;
            this.lblWeights.Text = "Weights of";
            // 
            // dgvWeights
            // 
            this.dgvWeights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWeights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeights.Location = new System.Drawing.Point(12, 39);
            this.dgvWeights.Name = "dgvWeights";
            this.dgvWeights.ReadOnly = true;
            this.dgvWeights.Size = new System.Drawing.Size(608, 395);
            this.dgvWeights.TabIndex = 1;
            // 
            // cbWeights
            // 
            this.cbWeights.FormattingEnabled = true;
            this.cbWeights.Items.AddRange(new object[] {
            "ART-A F2 Weights",
            "ART-B F2 Weights",
            "MAP Field Weights"});
            this.cbWeights.Location = new System.Drawing.Point(465, 12);
            this.cbWeights.Name = "cbWeights";
            this.cbWeights.Size = new System.Drawing.Size(139, 21);
            this.cbWeights.TabIndex = 7;
            this.cbWeights.SelectedIndexChanged += new System.EventHandler(this.cbWeights_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.cbWeights);
            this.Controls.Add(this.dgvWeights);
            this.Controls.Add(this.lblWeights);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Weights Details";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWeights;
        private System.Windows.Forms.DataGridView dgvWeights;
        private System.Windows.Forms.ComboBox cbWeights;
    }
}