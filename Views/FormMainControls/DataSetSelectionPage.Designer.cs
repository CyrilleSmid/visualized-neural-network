
namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    partial class DataSetSelectionPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.labelDebugDataSetPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // labelDebugDataSetPage
            // 
            this.labelDebugDataSetPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDebugDataSetPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDebugDataSetPage.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDebugDataSetPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.labelDebugDataSetPage.Location = new System.Drawing.Point(0, 0);
            this.labelDebugDataSetPage.Name = "labelDebugDataSetPage";
            this.labelDebugDataSetPage.Size = new System.Drawing.Size(328, 60);
            this.labelDebugDataSetPage.TabIndex = 3;
            this.labelDebugDataSetPage.Text = "Data Set Selection Page";
            this.labelDebugDataSetPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataSetSelectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDebugDataSetPage);
            this.Controls.Add(this.label1);
            this.Name = "DataSetSelectionPage";
            this.Size = new System.Drawing.Size(328, 240);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDebugDataSetPage;
    }
}
