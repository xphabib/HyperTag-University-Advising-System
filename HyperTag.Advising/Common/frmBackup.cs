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
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            textBox1.Text = fbd.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Sqlconnection Database will be Master database
            //query find in SSMS

            string sql = string.Format("BACKUP DATABASE [{0}] TO  DISK = N'{1}.bak' WITH NOFORMAT, NOINIT,  NAME = N'{2}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", Hypertag.Advising.Properties.Settings.Default.Database, textBox1.Text, Hypertag.Advising.Properties.Settings.Default.Database);
        }
    }
}
