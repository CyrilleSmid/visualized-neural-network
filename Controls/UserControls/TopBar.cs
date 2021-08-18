using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualized_neural_network.Controls.UserControls
{
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();
        }

        // Movable top bar
        private static bool dragging = false;
        private static Point dragCursorPoint;
        private static Point dragFormPoint;

        private void TopBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Parent.Location;
        }

        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Parent.Location = Point.Add(dragFormPoint, new Size(difference));
            }
        }

        private void TopBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            (this.Parent as Form).WindowState = FormWindowState.Minimized;
        }
    }
}
