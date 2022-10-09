namespace TSNEForms
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pltResult = new ScottPlot.FormsPlot();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnTSNE = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.numScale = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pltResult
            // 
            this.pltResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pltResult.Location = new System.Drawing.Point(13, 12);
            this.pltResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pltResult.Name = "pltResult";
            this.pltResult.Size = new System.Drawing.Size(560, 487);
            this.pltResult.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 44);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "读取数据";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnTSNE
            // 
            this.btnTSNE.Location = new System.Drawing.Point(119, 44);
            this.btnTSNE.Name = "btnTSNE";
            this.btnTSNE.Size = new System.Drawing.Size(75, 23);
            this.btnTSNE.TabIndex = 1;
            this.btnTSNE.Text = "tsne转换";
            this.btnTSNE.UseVisualStyleBackColor = true;
            this.btnTSNE.Click += new System.EventHandler(this.btnTSNE_Click);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 17;
            this.lstLog.Location = new System.Drawing.Point(3, 89);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(191, 395);
            this.lstLog.TabIndex = 2;
            // 
            // numScale
            // 
            this.numScale.Location = new System.Drawing.Point(5, 13);
            this.numScale.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numScale.Name = "numScale";
            this.numScale.Size = new System.Drawing.Size(73, 23);
            this.numScale.TabIndex = 3;
            this.numScale.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstLog);
            this.panel1.Controls.Add(this.numScale);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnTSNE);
            this.panel1.Location = new System.Drawing.Point(599, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 487);
            this.panel1.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pltResult);
            this.Name = "FrmMain";
            this.Text = "TSNE";
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot pltResult;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnTSNE;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.NumericUpDown numScale;
        private System.Windows.Forms.Panel panel1;
    }
}
