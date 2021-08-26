using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualizedNeuralNetwork.Controls.FormMainControls;
using VisualizedNeuralNetwork.Models.NeuralNetworkAlgorithm;

namespace VisualizedNeuralNetwork
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.DoubleBuffered = true;

            sideBar.AddPage(new NeuralNetworkPage(), "Neural Network",
                Properties.Resources.network, panelPageHolder);
            sideBar.AddPage(new DataSetSelectionPage(), "Data Set",
                Properties.Resources.data_set, panelPageHolder);
            sideBar.AddPage(new SettingsPage(), "Settings", 
                Properties.Resources.settings, panelPageHolder, true);
        }
    }
}
