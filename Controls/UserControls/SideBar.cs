using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace VisualizedNeuralNetwork.Controls.UserControls
{
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        List<UserControl> pages = new List<UserControl>();

        public void AddPage(UserControl page, string pageName, 
            Image pageImage, Panel pageHolder, bool buttonAtTheBottom = false)
        {
            Button button = new Button();
            Controls.Add(button);
            button.Tag = pages.Count;
            SetButtonStyle(button, pageName, pageImage);
            if (buttonAtTheBottom)
            {
                button.Dock = DockStyle.Bottom;
            }
            else
            {
                button.Dock = DockStyle.Top;
            }

            button.Click += new EventHandler(ButtonClicked);

            pages.Add(page as UserControl);
            SetPage(page, pageHolder);
            if (pages.Count == 1)
            {
                HighlightButton(button);
                OpenPage((int)button.Tag);
            }

            Debug.WriteLine("Initialized \"" + pageName + "\" page");
        }

        private void SetButtonStyle(Button button, string pageName, Image pageImage)
        {
            button.Height = 60;
            button.Padding = new Padding(20, 0, 20, 0);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            button.Text = pageName;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.ForeColor = Color.FromArgb(242, 242, 240);
            button.Font = new Font("Calibri", 14, FontStyle.Bold);

            button.Image = pageImage;
            button.ImageAlign = ContentAlignment.MiddleRight;
            button.TextImageRelation = TextImageRelation.TextBeforeImage;
            button.BringToFront();

            panelHighlight.BringToFront();
        }

        private void SetPage(UserControl page, Panel pageHolder)
        {
            pageHolder.Controls.Add(page);
            pageHolder.Tag = page;
            page.Dock = DockStyle.Fill;
            page.BringToFront();
            page.Visible = false;
        }

        Color accentColor = Color.FromArgb(33, 50, 55);
        Color defaultColor = Color.FromArgb(36, 38, 39);
        Button activeButton;
        private void HighlightButton(Button buttonToHighlight)
        {
            if (activeButton != null)
                activeButton.BackColor = defaultColor;
            activeButton = buttonToHighlight;

            panelHighlight.Height = buttonToHighlight.Height;
            panelHighlight.Top = buttonToHighlight.Top;
            panelHighlight.Left = buttonToHighlight.Left;

            buttonToHighlight.BackColor = accentColor;

        }

        int activePageIndex = -1;
        private void ButtonClicked(object sender, EventArgs e)
        {
            if (activePageIndex != (int)((Button)sender).Tag)
            {
                HighlightButton((Button)sender);
                OpenPage((int)((Button)sender).Tag);

                Debug.WriteLine("Opened \"" + ((Button)sender).Text + "\" page");
            }
        }
        
        private void OpenPage(int pageIndex)
        {
            if (activePageIndex != -1)
                pages[activePageIndex].Visible = false;
            pages[pageIndex].Visible = true;

            activePageIndex = pageIndex;
        }
    }
}
