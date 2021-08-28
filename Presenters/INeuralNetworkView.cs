using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizedNeuralNetwork.Presenters
{
    interface INeuralNetworkView
    {
        int RedColorComponent { get; set; }
        int GreenColorComponent { get; set; }
        int BlueColorComponent { get; set; }

        event EventHandler TrainNetworkButtonClicked;

        void OnNetworkNeedsRedrawing(object sender, EventArgs e);

    };
}
