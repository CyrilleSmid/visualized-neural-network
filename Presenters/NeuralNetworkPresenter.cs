using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualizedNeuralNetwork.Models.NeuralNetworkAlgorithm;
using VisualizedNeuralNetwork.Presenters;

namespace VisualizedNeuralNetwork.Presenters
{
    class NeuralNetworkPresenter
    {
        private NeuralNetwork network;
        public NeuralNetwork Network { get { return network; }  }

        private INeuralNetworkView view;

        public NeuralNetworkPresenter(INeuralNetworkView view)
        {
            this.view = view;
            view.TrainNetworkButtonClicked += OnTrainNetworkButtonClicked;

            NeuralNetwork.InitializeAndSaveNetwork("Test.csv", 3, 13,
                new List<int>(new int[] { 6, 10, 13 }));
            network = new NeuralNetwork("Test.csv");

            network.NetworkNeedsRedrawing += view.OnNetworkNeedsRedrawing;
        }

        public void OnTrainNetworkButtonClicked(object sender, EventArgs e)
        {
            network.TrainNetwork("training_data_set.csv", "testing_data_set.csv", 5);
        }
    }
}
