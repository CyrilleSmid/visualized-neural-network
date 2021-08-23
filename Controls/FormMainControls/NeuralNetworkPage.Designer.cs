
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
            this.neuralNetworkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelNetworkVisualizationWindow
            // 
            this.panelNetworkVisualizationWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.panelNetworkVisualizationWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNetworkVisualizationWindow.Location = new System.Drawing.Point(30, 0);
            this.panelNetworkVisualizationWindow.Name = "panelNetworkVisualizationWindow";
            this.panelNetworkVisualizationWindow.Size = new System.Drawing.Size(800, 540);
            this.panelNetworkVisualizationWindow.TabIndex = 0;
            this.panelNetworkVisualizationWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNetworkVisualizationWindow_Paint);
            // 
            // neuralNetworkButton
            // 
            this.neuralNetworkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.neuralNetworkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.neuralNetworkButton.FlatAppearance.BorderSize = 0;
            this.neuralNetworkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.neuralNetworkButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.neuralNetworkButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.neuralNetworkButton.Image = global::VisualizedNeuralNetwork.Properties.Resources.network;
            this.neuralNetworkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.neuralNetworkButton.Location = new System.Drawing.Point(590, 557);
            this.neuralNetworkButton.Name = "neuralNetworkButton";
            this.neuralNetworkButton.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.neuralNetworkButton.Size = new System.Drawing.Size(240, 60);
            this.neuralNetworkButton.TabIndex = 8;
            this.neuralNetworkButton.Text = "Train Network";
            this.neuralNetworkButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.neuralNetworkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.neuralNetworkButton.UseVisualStyleBackColor = false;
            this.neuralNetworkButton.Click += new System.EventHandler(this.neuralNetworkButton_Click);
            // 
            // NeuralNetworkPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.Controls.Add(this.neuralNetworkButton);
            this.Controls.Add(this.panelNetworkVisualizationWindow);
            this.Name = "NeuralNetworkPage";
            this.Padding = new System.Windows.Forms.Padding(30, 0, 30, 30);
            this.Size = new System.Drawing.Size(860, 650);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNetworkVisualizationWindow;
        private System.Windows.Forms.Button neuralNetworkButton;
    }
}
