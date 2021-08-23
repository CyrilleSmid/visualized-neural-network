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

            NeuralNetwork.InitializeAndSaveNetwork("Test.csv", 3, 13, new List<int>(new int[] { 6, 10, 13}));
            network = new NeuralNetwork("Test.csv");
            network.NetworkNeedsRedrawing += OnNetworkNeedsRedrawing;
            
        }

        private void neuralNetworkButton_Click(object sender, EventArgs e)
        {
            network.TrainNetwork("training_data_set.csv", "testing_data_set.csv", 5);
        }

        private const int drawingStartingPosX = 80;
        private const int drawingNextColumnShift = 150;
        private const int drawingNextRowShift = 40;
        private const int drawingCircleDiameter = 20;

        private Color baseNeuronColor = Color.FromArgb(36, 38, 39); // Dark Grey
        private Color neuronBorderColor = Color.FromArgb(242, 242, 240); // White
        private Color basePositiveConnectionColor = Color.FromArgb(15, 160, 193); // Blue
        private Color baseNegativeConnectionColor = Color.FromArgb(166, 68, 68); // Redish
        private void panelNetworkVisualizationWindow_Paint(object sender, PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                List<List<Point>> neuronPositions = new List<List<Point>>();

                // Draw connections and save neuron positions
                for (int layerIndex = 0; layerIndex < network.NetworkStracture.Length; layerIndex++)
                {
                    neuronPositions.Add(new List<Point>());
                    int neuronsCount = network.NetworkStracture.LayerLength(layerIndex);
                    int layerHeight = drawingNextRowShift * (neuronsCount - 1) + drawingCircleDiameter;
                    int drawingStartingPosY = (panelNetworkVisualizationWindow.Height - layerHeight) / 2;

                    for (int neuronIndex = 0; neuronIndex < neuronsCount; neuronIndex++)
                    {
                        int neuronPosX = drawingStartingPosX + layerIndex * drawingNextColumnShift;
                        int neuronPosY = drawingStartingPosY + neuronIndex * drawingNextRowShift;

                        neuronPositions[layerIndex].Add(new Point(neuronPosX, neuronPosY));
                        
                        if(layerIndex != 0)
                        {
                            Point curNeuronCenterPos = new Point(
                                neuronPosX + drawingCircleDiameter / 2, 
                                neuronPosY + drawingCircleDiameter / 2);


                            for (int prevNeuronIndex = 0; prevNeuronIndex < network.NetworkStracture.LayerLength(layerIndex-1); prevNeuronIndex ++)
                            {
                                Point prevNeuronCenterPos = new Point(
                                    neuronPositions[layerIndex - 1][prevNeuronIndex].X + drawingCircleDiameter / 2,
                                    neuronPositions[layerIndex - 1][prevNeuronIndex].Y + drawingCircleDiameter / 2);

                                float connectionWeight = network.NetworkStracture[layerIndex, neuronIndex].weights[prevNeuronIndex];
                                connectionWeight = Math.Min(1, connectionWeight);
                                connectionWeight = Math.Max(-1, connectionWeight);

                                if (Math.Abs(connectionWeight) > 0.25)
                                {
                                    Color actualConnectionColor;
                                    if (connectionWeight < 0)
                                    {
                                        connectionWeight *= -1;
                                        actualConnectionColor = NormalizedColor(
                                            baseNegativeConnectionColor, 
                                            connectionWeight, 
                                            panelNetworkVisualizationWindow.BackColor);
                                    }
                                    else
                                    {
                                        actualConnectionColor = NormalizedColor(
                                            basePositiveConnectionColor,
                                            connectionWeight,
                                            panelNetworkVisualizationWindow.BackColor);
                                    }
                                    int lineThickness = Math.Abs(connectionWeight) > 0.6 ? 2 : 1;
                                    using (var connectionPen = new Pen(actualConnectionColor, 1))
                                    {
                                        graphics.DrawLine(
                                            connectionPen,
                                            prevNeuronCenterPos,
                                            curNeuronCenterPos);
                                    }
                                }
                                
                            }
                        }
                    }
                }

                // Draw neurons
                using(var pen = new Pen(neuronBorderColor, 1))
                {
                    using(var brush = new SolidBrush(baseNeuronColor))
                    {
                        for (int layerIndex = 0; layerIndex < neuronPositions.Count; layerIndex++)
                        {
                            for (int neuronIndex = 0; neuronIndex < neuronPositions[layerIndex].Count; neuronIndex++)
                            {
                                graphics.FillEllipse(
                                    brush,
                                    neuronPositions[layerIndex][neuronIndex].X,
                                    neuronPositions[layerIndex][neuronIndex].Y,
                                    drawingCircleDiameter,
                                    drawingCircleDiameter);

                                graphics.DrawEllipse(
                                    pen,
                                    neuronPositions[layerIndex][neuronIndex].X,
                                    neuronPositions[layerIndex][neuronIndex].Y,
                                    drawingCircleDiameter,
                                    drawingCircleDiameter);
                            }
                        }
                    }
                }

                        


            }
        }
        Color NormalizedColor(Color baseColor, float connectionWeight, Color baseBackgroundColor)
        {
            return Color.FromArgb(
                (int)(Math.Max(baseColor.R * connectionWeight, baseBackgroundColor.R)),
                (int)(Math.Max(baseColor.G * connectionWeight, baseBackgroundColor.G)),
                (int)(Math.Max(baseColor.B * connectionWeight, baseBackgroundColor.B)));
        }

        //public delegate void NetworkRedrawnEventHandler(object sender, EventArgs e);
        //public event NetworkRedrawnEventHandler NetworkRedrawn;
        //protected virtual void OnNetworkRedrawn()
        //{
        //    if (NetworkRedrawn != null)
        //    {
        //        NetworkRedrawn(this, EventArgs.Empty);
        //    }
        //}

        public void OnNetworkNeedsRedrawing(object sender, EventArgs e)
        {
            panelNetworkVisualizationWindow.Invalidate();
        }

    }
}
