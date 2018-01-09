using Hypertag.Advising.DAL;
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
    public partial class frmNewUser : Form
    {
        ErrorProvider ep = new ErrorProvider();
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();
            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Name is requird");
            }
            if (txtEmail.Text == "")
            {
                er++;
                ep.SetError(txtEmail, "Email  Required");
            }
            if (txtPassword.Text == "")
            {
                er++;
                ep.SetError(txtPassword, "Required");
            }


            if (er == 0)
            {
                DAL.Users usr = new DAL.Users();
                usr.Name = txtName.Text;
                usr.Email = txtEmail.Text;
                //usr.Password = Cryptography.Encryption.Encrypt(txtPassword.Text, "1234");
                usr.Password = txtPassword.Text;
                usr.Type = comboBox1.Text;
                usr.CreateIP = "127.0.0.1";
               // usr.CreateDate = DateTime.Now;

                if (usr.Insert())
                {
                    MessageBox.Show("Data Saved");
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    comboBox1.SelectedIndex = 0;
                    txtName.Focus();
                }
                else
                {
                    MessageBox.Show(usr.Error);
                }
            }
        }
    }
    }

