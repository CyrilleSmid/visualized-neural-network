
namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    partial class NeuralNetworkPage
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
            this.panelNetworkVisualizationWindow = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelNetworkVisualizationWindow
            // 
            this.panelNetworkVisualizationWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.panelNetworkVisualizationWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNetworkVisualizationWindow.Location = new System.Drawing.Point(30, 30);
            this.panelNetworkVisualizationWindow.Name = "panelNetworkVisualizationWindow";
            this.panelNetworkVisualizationWindow.Size = new System.Drawing.Size(740, 420);
            this.panelNetworkVisualizationWindow.TabIndex = 0;
            this.panelNetworkVisualizationWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNetworkVisualizationWindow_Paint);
            // 
            // NeuralNetworkPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.panelNetworkVisualizationWindow);
            this.Name = "NeuralNetworkPage";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Size = new System.Drawing.Size(800, 570);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNetworkVisualizationWindow;
    }
}
