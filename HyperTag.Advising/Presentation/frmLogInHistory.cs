using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising.Presentation
{
    public partial class frmLogInHistory : Form
    {
        public frmLogInHistory()
        {
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.LogInHistory logInHistory = new DAL.LogInHistory();
            logInHistory.Ip = txtSearch.Text;


            dvgLogInHistory.DataSource = logInHistory.Select().Tables[0];
        }

        private void frmLogInHistory_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
    }
}
