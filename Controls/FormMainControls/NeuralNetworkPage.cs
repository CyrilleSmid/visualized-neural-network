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
            NeuralNetwork.InitializeAndSaveNetwork("Test.csv", 3, 13, new List<int>(new int[] { 3, 13, 13}));
            NeuralNetwork network = new NeuralNetwork("Test.csv");
            network.TrainNetwork("training_data_set.csv", "testing_data_set.csv", 30);
        }

        
        private void NeuralNetworkPage_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var pen = new Pen(Color.FromArgb(36, 38, 39), 4);
            var brush = new SolidBrush(Color.FromArgb(67, 72, 75));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    graphics.FillEllipse(brush, 50 + i * 60, 50 + j * 30, 20, 20);
                    graphics.DrawEllipse(pen, 50 + i * 60, 50 + j * 30, 20, 20);
                }
            }
            graphics.Dispose();
        }
    }
}
