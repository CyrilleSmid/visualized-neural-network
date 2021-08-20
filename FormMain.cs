using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using visualized_neural_network.Controls.FormMainControls;

namespace visualized_neural_network
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            sideBar.AddPage(new NeuralNetworkPage(), "Neural Network", 
                Properties.Resources.network, panelPageHolder);
            sideBar.AddPage(new DataSetSelectionPage(), "Data Set", // TODO: change page
                Properties.Resources.data_set, panelPageHolder);
            sideBar.AddPage(new SettingsPage(), "Settings", // TODO: change page
                Properties.Resources.settings, panelPageHolder, true);


        }
    }
}
