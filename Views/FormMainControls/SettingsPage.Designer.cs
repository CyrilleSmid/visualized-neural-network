
namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    partial class SettingsPage
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
            this.labelDebugSettingsPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDebugSettingsPage
            // 
            this.labelDebugSettingsPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDebugSettingsPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDebugSettingsPage.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDebugSettingsPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.labelDebugSettingsPage.Location = new System.Drawing.Point(0, 0);
            this.labelDebugSettingsPage.Name = "labelDebugSettingsPage";
            this.labelDebugSettingsPage.Size = new System.Drawing.Size(298, 60);
            this.labelDebugSettingsPage.TabIndex = 4;
            this.labelDebugSettingsPage.Text = "Settings Page";
            this.labelDebugSettingsPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDebugSettingsPage);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(298, 249);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDebugSettingsPage;
    }
}
