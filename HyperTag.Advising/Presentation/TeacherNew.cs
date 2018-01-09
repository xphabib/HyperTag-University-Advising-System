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
    public partial class TeacherNew : Form
    {
        int er = 0;
        ErrorProvider ep = new ErrorProvider();
        public TeacherNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtEmail.Text == "")
            {
                er++;

                ep.SetError(txtEmail, "Name Requered");

            }
            if (txtTeacherId.Text == "")
            {
                er++;
                ep.SetError(txtTeacherId, "Teacher Id Required");

            }
            if (txtContact.Text == "")
            {
                er++;
                ep.SetError(txtContact, "Contact Number Required");

            }
            if (txtEamil.Text == "")
            {
                er++;
                ep.SetError(txtEamil, "Email Required");

            }
            if (er == 0)
            {
                Hypertag.Advising.DAL.teacher teachers = new DAL.teacher();
                teachers.Name = txtEmail.Text;
                teachers.contact = txtContact.Text;
                teachers.email = txtEamil.Text;


                if (teachers.Insert())
                {
                    MessageBox.Show("Data Saved");
                    txtEmail.Text = "";
                    txtTeacherId.Text = "";
                    txtContact.Text = "";
                    txtEamil.Text = "";

                    txtEmail.Focus();

                }
                else
                {
                    MessageBox.Show(teachers.Error);
                }
            }
        }
    }
}
