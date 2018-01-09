using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hypertag.Advising;
namespace Hypertag.Advising.Presentation
{
    public partial class frmfrmOfferedCourseNew : Form
    {
        ErrorProvider ep = new ErrorProvider();
        public frmfrmOfferedCourseNew()
        {
            InitializeComponent();
        }

        private void frmfrmOfferedCourseNew_Load(object sender, EventArgs e)
        {
            MinimumSize = this.Size;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if(txtSemesterId.Text == "")
            {
                er++;
                ep.SetError(txtSemesterId, "Requered");
            }

            if (txtCourseId.Text == "")
            {
                er++;
                ep.SetError(txtCourseId, "Requered");
            }

            if (txtTeacherId.Text == "")
            {
                er++;
                ep.SetError(txtTeacherId, "Requered");
            }

            if (txtDate.Text == "")
            {
                er++;
                ep.SetError(txtDate, "Requered");
            }

            if (txtExpireDate.Text == "")
            {
                er++;
                ep.SetError(txtExpireDate, "Requered");
            }

            if (er > 0)
                return;
            DAL.OfferedCourse ofc = new DAL.OfferedCourse();
            ofc.SemesterId = Convert.ToInt32(txtSemesterId.Text);
            ofc.CourseId = Convert.ToInt32(txtCourseId.Text);
            ofc.TeacherId = Convert.ToInt32(txtCourseId.Text);
            ofc.Date = Convert.ToDateTime(txtDate.Text);
            ofc.ExpireDate = Convert.ToDateTime(txtExpireDate.Text);


            if(ofc.Insert())
            {
                MessageBox.Show("Recored successfully Inserted !");
                btnReset_Click(null, null);
            }
            else
            {
                MessageBox.Show(ofc.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSemesterId.Text = "";
            txtCourseId.Text = "";
            txtTeacherId.Text = "";
            txtDate.Text = "";
            txtExpireDate.Text = "";
            txtCourseId.Focus();
        }

        private void frmfrmOfferedCourseNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

    
    }
}
