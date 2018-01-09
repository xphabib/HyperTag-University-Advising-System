using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising.Common
{
    public partial class frmUI : Form
    {
        public frmUI()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = Hypertag.Advising.Properties.Settings.Default.Font;
            fd.ShowDialog();
            Hypertag.Advising.Properties.Settings.Default.Font = fd.Font;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            fd.Color = Hypertag.Advising.Properties.Settings.Default.FontColor;
            fd.ShowDialog();
            Hypertag.Advising.Properties.Settings.Default.FontColor = fd.Color;

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            fd.Color = Hypertag.Advising.Properties.Settings.Default.BackgroundColor;
            fd.ShowDialog();
            Hypertag.Advising.Properties.Settings.Default.BackgroundColor = fd.Color;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hypertag.Advising.Properties.Settings.Default.Save();
            MessageBox.Show("UI Settings Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Advising.Properties.Settings.Default.Font = new Font ()
        }
    }
}
