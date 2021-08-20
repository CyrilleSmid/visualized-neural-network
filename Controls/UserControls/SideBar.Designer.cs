
namespace visualized_neural_network.Controls.UserControls
{
    partial class SideBar
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
            this.panelHighlight = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelHighlight
            // 
            this.panelHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(160)))), ((int)(((byte)(193)))));
            this.panelHighlight.Location = new System.Drawing.Point(0, 0);
            this.panelHighlight.Name = "panelHighlight";
            this.panelHighlight.Size = new System.Drawing.Size(4, 60);
            this.panelHighlight.TabIndex = 22;
            // 
            // SideBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.Controls.Add(this.panelHighlight);
            this.Name = "SideBar";
            this.Size = new System.Drawing.Size(240, 470);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHighlight;
    }
}
