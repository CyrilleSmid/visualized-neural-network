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
        }

        private const int drawingStartingPosX = 120;
        private const int drawingNextColumnShift = 120;
        private const int drawingNextRowShift = 30;
        private const int drawingCircleDiameter = 20;

        private void panelNetworkVisualizationWindow_Paint(object sender, PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                var pen = new Pen(Color.FromArgb(36, 38, 39), 4);
                var brush = new SolidBrush(Color.FromArgb(67, 72, 75));

                List<Point> prevLayerNeuronCenterPositions = new List<Point>();
                List<Point> curLayerNeuronCenterPositions = new List<Point>();

                for (int layerIndex = 0; layerIndex < network.NetworkStracture.Length; layerIndex++)
                {
                    int neuronsCount = network.NetworkStracture.LayerLength(layerIndex);
                    int layerHeight = drawingNextRowShift * (neuronsCount - 1) + drawingCircleDiameter;
                    int drawingStartingPosY = (panelNetworkVisualizationWindow.Height - layerHeight) / 2;

                    for (int neuronIndex = 0; neuronIndex < neuronsCount; neuronIndex++)
                    {
                        int neuronPosX = drawingStartingPosX + layerIndex * drawingNextColumnShift;
                        int neuronPosY = drawingStartingPosY + neuronIndex * drawingNextRowShift;
                        
                        

                        curLayerNeuronCenterPositions.Add(new Point(
                            neuronPosX + drawingCircleDiameter / 2, 
                            neuronPosY + drawingCircleDiameter / 2));
                        
                        if(layerIndex != 0)
                        {
                            Point curNeuronCenterPos = new Point(
                                neuronPosX + drawingCircleDiameter / 2, 
                                neuronPosY + drawingCircleDiameter / 2);

                            for (int prevNeuronIndex = 0; prevNeuronIndex < network.NetworkStracture.LayerLength(layerIndex-1); prevNeuronIndex ++)
                            {
                                var connectionPen = new Pen(Color.FromArgb(15, 160, 193), 1);

                                graphics.DrawLine(
                                    connectionPen,
                                    prevLayerNeuronCenterPositions[prevNeuronIndex],
                                    curNeuronCenterPos);

                            }
                        }

                        graphics.FillEllipse(
                            brush, 
                            neuronPosX, 
                            neuronPosY,
                            drawingCircleDiameter,
                            drawingCircleDiameter);

                        //graphics.DrawEllipse(
                        //    pen,
                        //    neuronPosX,
                        //    neuronPosY,
                        //    drawingCircleDiameter,
                        //    drawingCircleDiameter);


                    }
                    prevLayerNeuronCenterPositions = new List<Point>(curLayerNeuronCenterPositions);
                    curLayerNeuronCenterPositions.Clear();
                }
            }
        }
    }
}
