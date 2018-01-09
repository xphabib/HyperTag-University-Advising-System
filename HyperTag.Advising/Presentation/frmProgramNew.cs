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
    public partial class frmProgramNew : Form
    {

        ErrorProvider ep = new ErrorProvider();
        public frmProgramNew()
        {
            InitializeComponent();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Name Required");
            }

            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Description Required");
            }

            if (txtDuration.Text == "")
            {
                er++;
                ep.SetError(txtDuration, "Duration Required");
            }

            if (txtMinimumCredit.Text == "")
            {
                er++;
                ep.SetError(txtMinimumCredit, "Minimum Credit Required");
            }

            if (cmbDepartment.Text == "")
            {
                er++;
                ep.SetError(cmbDepartment, "Department Required");
            }
            if (er == 0)
            {

                DAL.Program program = new DAL.Program();

                program.Name = txtName.Text;
                program.Description = txtDescription.Text;
                program.Duration = Convert.ToInt32(txtDuration.Text);
                program.MinimumCredit = Convert.ToInt32(txtMinimumCredit.Text);
                program.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);

                if (program.Insert())
                {

                    MessageBox.Show("Data Saved");
                    txtName.Text = "";
                    txtDescription.Text = "";
                    txtDuration.Text = "";
                    txtMinimumCredit.Text = "";
                    cmbDepartment.Text = ""; 


                }
                else
                {
                    MessageBox.Show(program.Error); 
                }
            }


        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void programNew_Load(object sender, EventArgs e)
        {
            DAL.Department dprtment = new DAL.Department();
            cmbDepartment.DataSource = dprtment.Select().Tables[0];
            cmbDepartment.DisplayMember = "name";
            cmbDepartment.ValueMember = "id";
            cmbDepartment.SelectedValue = -1;
            this.MinimumSize = this.Size;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
