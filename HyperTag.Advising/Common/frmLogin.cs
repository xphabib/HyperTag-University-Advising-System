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
    public partial class frmLogin : Form
    {
        ErrorProvider ep = new ErrorProvider();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();
            if (txtEmail.Text == "")
            {
                er++;
                ep.SetError(txtEmail, "Email / Contact Required");
            }
            if(txtPassword.Text == "")
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }

            if (er > 0)
                return;

            DAL.Login lgn = new DAL.Login();
           
            lgn.Email = txtEmail.Text;
            lgn.Password = txtPassword.Text;
            if(lgn.LoginCheck())
            {
                ACL.Login = lgn;

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Login, Try Again");
                txtEmail.Focus();
            }
        }
    }
}
