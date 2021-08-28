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
using VisualizedNeuralNetwork.Models.NetworkVisualizer;
using VisualizedNeuralNetwork.Presenters;

namespace VisualizedNeuralNetwork.Controls.FormMainControls
{
    public partial class NeuralNetworkView : UserControl, INeuralNetworkView
    {
        private NeuralNetworkPresenter presenter;
        private NetworkVisualizer networkVisualizer;

        public event EventHandler TrainNetworkButtonClicked;

        public NeuralNetworkView()
        {
            InitializeComponent();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            presenter = new NeuralNetworkPresenter(this);
            networkVisualizer = new NetworkVisualizer(panelNetworkHolder, presenter.Network);
        }


        public int RedColorComponent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GreenColorComponent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int BlueColorComponent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private void neuralNetworkButton_Click(object sender, EventArgs e)
        {
            if(TrainNetworkButtonClicked != null)
            {
                TrainNetworkButtonClicked(this, e);
            }
        }

        private void panelNetworkVisualizationWindow_Paint(object sender, PaintEventArgs e)
        {
            using (var graphics = e.Graphics)
            {
                networkVisualizer.RedrawNetwork(graphics);
            }
        }

        public void OnNetworkNeedsRedrawing(object sender, EventArgs e)
        {
            panelNetworkHolder.Invalidate();
        }

    }
}
