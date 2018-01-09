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
    public partial class CourseNew : Form
    {
        int er = 0;
        ErrorProvider ep = new ErrorProvider();
        public CourseNew()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "")
            {
                er++;

                ep.SetError(txtName, "Name Requered");

            }
            if (txtCode.Text == "")
            {
                er++;
                ep.SetError(txtCode, "Code Requered");

            }
            if (txtCredit.Text == "")
            {
                er++;
                ep.SetError(txtCredit, "Input Requered");

            }
            if (txtProgramId.Text == "")
            {
                er++;
                ep.SetError(txtProgramId, "program id Requered");

            }
            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Description is Requered");

            }
            if (er == 0)
            {
                Hypertag.Advising.DAL.course courses = new DAL.course();
                courses.Name = txtName.Text;
                //courses.Code = txtCode.Text;
                courses.Credit = Convert.ToInt32(txtCredit.Text);
                courses.ProgramId = Convert.ToInt32(txtProgramId.Text);
                courses.Description = txtDescription.Text;


                if (courses.Insert())
                {
                    MessageBox.Show("Data Saved");
                    txtName.Text = "";
                    txtCode.Text = "";
                    txtCredit.Text = "";
                    txtProgramId.Text = "";
                    txtDescription.Text = "";

                    txtName.Focus();
                }
                else
                {
                    MessageBox.Show(courses.Error);
                }
            }
        }
    }
}
