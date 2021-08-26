using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using VisualizedNeuralNetwork.Models.NeuralNetworkAlgorithm;
using VisualizedNeuralNetwork.Models.NetworkVisualizer;

namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    public partial class NeuralNetworkPage : UserControl
    {
        NeuralNetwork network;
        NetworkVisualizer netVisualizer;
        public NeuralNetworkPage()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            NeuralNetwork.InitializeAndSaveNetwork("Test.csv", 3, 13, 
                new List<int>(new int[] { 6, 10, 13 }));
            network = new NeuralNetwork("Test.csv");
            network.NetworkNeedsRedrawing += OnNetworkNeedsRedrawing;

            netVisualizer = new NetworkVisualizer(panelNetworkVisualizationWindow, network);
        }

        private void neuralNetworkButton_Click(object sender, EventArgs e)
        {
            network.TrainNetwork("training_data_set.csv", "testing_data_set.csv", 5);
        }

        private void panelNetworkVisualizationWindow_Paint(object sender, PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                netVisualizer.RedrawNetwork(graphics);
            }
        }



        public void OnNetworkNeedsRedrawing(object sender, EventArgs e)
        {
            panelNetworkVisualizationWindow.Invalidate();
        }

    }
}
