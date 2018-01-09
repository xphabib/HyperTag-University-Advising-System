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
    public partial class frmDepartmentNew : Form
    {

        ErrorProvider ep = new ErrorProvider();
        public frmDepartmentNew()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtName.Text== "")
            {
                er++;
                ep.SetError(txtName, "Name Required");
            }

            if (txtDescription.Text == "")
            {
                er++;
                ep.SetError(txtDescription, "Description Required");
            }


            if (er == 0) {

                DAL.Department department = new DAL.Department();

                department.Name = txtName.Text;
                department.Description = txtDescription.Text;

                if (department.Insert())  
                {
                         
                    MessageBox.Show("Data Saved");
                    txtName.Text = "";
                    txtDescription.Text = "";

                }
                else
                {
                    MessageBox.Show(department.Error); 
                }
            }
        }

        private void frmDepartmentNew_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
        }
    }
}
