using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising.Help
{
    public partial class frmManual : Form
    {
        public frmManual()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //MessageBox.Show(Application.StartupPath);
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "/Help/" +treeView1.SelectedNode.Tag);
                string s = sr.ReadToEnd();
                sr.Close();
                webBrowser1.DocumentText = s;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
