
namespace VisualizedNeuralNetwork
{
    partial class FormMain
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelSideTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxProjectLogo = new System.Windows.Forms.PictureBox();
            this.panelControlHolder = new System.Windows.Forms.Panel();
            this.panelPageHolder = new System.Windows.Forms.Panel();
            this.sideBar = new VisualizedNeuralNetwork.Controls.UserControls.SideBar();
            this.topBar = new VisualizedNeuralNetwork.Controls.UserControls.TopBar();
            this.panelSide.SuspendLayout();
            this.panelSideTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectLogo)).BeginInit();
            this.panelControlHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.panelSide.Controls.Add(this.sideBar);
            this.panelSide.Controls.Add(this.panelSideTitle);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 30);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(240, 650);
            this.panelSide.TabIndex = 3;
            // 
            // panelSideTitle
            // 
            this.panelSideTitle.Controls.Add(this.labelTitle);
            this.panelSideTitle.Controls.Add(this.pictureBoxProjectLogo);
            this.panelSideTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSideTitle.Location = new System.Drawing.Point(0, 0);
            this.panelSideTitle.Name = "panelSideTitle";
            this.panelSideTitle.Size = new System.Drawing.Size(240, 140);
            this.panelSideTitle.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.labelTitle.Location = new System.Drawing.Point(12, 95);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTitle.Size = new System.Drawing.Size(217, 26);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Neural Network Project";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxProjectLogo
            // 
            this.pictureBoxProjectLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxProjectLogo.Image = global::VisualizedNeuralNetwork.Properties.Resources.project_icon_network;
            this.pictureBoxProjectLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxProjectLogo.Name = "pictureBoxProjectLogo";
            this.pictureBoxProjectLogo.Size = new System.Drawing.Size(240, 100);
            this.pictureBoxProjectLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxProjectLogo.TabIndex = 0;
            this.pictureBoxProjectLogo.TabStop = false;
            // 
            // panelControlHolder
            // 
            this.panelControlHolder.Controls.Add(this.panelPageHolder);
            this.panelControlHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlHolder.Location = new System.Drawing.Point(240, 30);
            this.panelControlHolder.Name = "panelControlHolder";
            this.panelControlHolder.Size = new System.Drawing.Size(860, 650);
            this.panelControlHolder.TabIndex = 4;
            // 
            // panelPageHolder
            // 
            this.panelPageHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPageHolder.Location = new System.Drawing.Point(0, 0);
            this.panelPageHolder.Name = "panelPageHolder";
            this.panelPageHolder.Size = new System.Drawing.Size(860, 650);
            this.panelPageHolder.TabIndex = 0;
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar.Location = new System.Drawing.Point(0, 140);
            this.sideBar.Margin = new System.Windows.Forms.Padding(0);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(240, 510);
            this.sideBar.TabIndex = 1;
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(72)))), ((int)(((byte)(75)))));
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1100, 30);
            this.topBar.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.panelControlHolder);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelSide.ResumeLayout(false);
            this.panelSideTitle.ResumeLayout(false);
            this.panelSideTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProjectLogo)).EndInit();
            this.panelControlHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UserControls.TopBar topBar;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelSideTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxProjectLogo;
        private System.Windows.Forms.Panel panelControlHolder;
        private System.Windows.Forms.Panel panelPageHolder;
        private Controls.UserControls.SideBar sideBar;
    }
}

