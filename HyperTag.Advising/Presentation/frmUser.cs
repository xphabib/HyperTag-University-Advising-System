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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
          Presentation.frmNewUser newUser = new frmNewUser();
            newUser.ShowDialog();
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.Users usr = new DAL.Users();
            grvData.DataSource = usr.Select().Tables[0];
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           

        }

        private void frmUser_Load(object sender, EventArgs e)
        {

        }
    }
}
