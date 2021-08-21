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
using System.Diagnostics;

namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    public partial class NeuralNetworkPage : UserControl
    {
        NeuralNetwork network;
        public NeuralNetworkPage()
        {
            InitializeComponent();

            NeuralNetwork.InitializeAndSaveNetwork("Test.csv", 3, 13, new List<int>(new int[] { 6, 10, 13 }));
            network = new NeuralNetwork("Test.csv");
        }

        private const int drawingStartingPosX = 60;
        private const int drawingStartingPosY = 20;
        private const int drawingNextColumnShift = 60;
        private const int drawingNextRowShift = 30;
        private const int drawingCircleDiameter = 20;

        private void panelNetworkVisualizationWindow_Paint(object sender, PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                var pen = new Pen(Color.FromArgb(36, 38, 39), 4);
                var brush = new SolidBrush(Color.FromArgb(67, 72, 75));
                for (int layerIndex = 0; layerIndex < network.NetworkStracture.Length; layerIndex++)
                {
                    for (int neuronIndex = 0; neuronIndex < network.NetworkStracture.LayerLength(layerIndex); neuronIndex++)
                    {
                        int neuronPosX = drawingStartingPosX + layerIndex * drawingNextColumnShift;
                        int neuronPosY = drawingStartingPosY + neuronIndex * drawingNextRowShift;

                        graphics.FillEllipse(
                            brush, 
                            neuronPosX, 
                            neuronPosY,
                            drawingCircleDiameter,
                            drawingCircleDiameter);

                        graphics.DrawEllipse(
                            pen,
                            neuronPosX,
                            neuronPosY,
                            drawingCircleDiameter,
                            drawingCircleDiameter);
                    }
                }
            }
        }
    }
}
