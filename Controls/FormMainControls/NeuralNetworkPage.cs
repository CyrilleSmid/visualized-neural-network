﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using visualized_neural_network.Models.NeuralNetworkAlgorithm;

namespace visualized_neural_network.Controls.FormMainControls
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
