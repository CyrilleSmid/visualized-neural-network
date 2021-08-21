using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualizedNeuralNetwork.Models.NeuralNetworkAlgorithm;

namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    public partial class NeuralNetworkPage : UserControl
    {
        public NeuralNetworkPage()
        {
            InitializeComponent();

            NeuralNetwork network = new NeuralNetwork("Test.csv");
        }
    }
}
