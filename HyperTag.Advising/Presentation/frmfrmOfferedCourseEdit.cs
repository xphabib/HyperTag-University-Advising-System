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
    public partial class frmfrmOfferedCourseEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        public frmfrmOfferedCourseEdit()
        {
            InitializeComponent();
        }

        public frmfrmOfferedCourseEdit(int id)
        {
            InitializeComponent();

            DAL.OfferedCourse ofc = new DAL.OfferedCourse();
            ofc.SemesterId = 1;
            ofc.CourseId = 2;
            if(ofc.SelectById())
            {
                txtCourseId.Text = ofc.CourseId.ToString();
                txtSemesterId.Text = ofc.SemesterId.ToString();
                txtTeacherId.Text = ofc.TeacherId.ToString();
                txtDate.Text = ofc.Date.ToString();
                txtExpireDate.Text = ofc.ExpireDate.ToString();
                txtExpireDate.Focus();
            }
        }

        private void frmfrmOfferedCourseEdit_Load(object sender, EventArgs e)
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

            if (txtSemesterId.Text == "")
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
            ofc.CourseId = Convert.ToInt32(txtCourseId.Text);
            ofc.SemesterId = Convert.ToInt32(txtSemesterId.Text);
            ofc.TeacherId = Convert.ToInt32(txtTeacherId.Text);
            ofc.Date = Convert.ToDateTime(txtDate.Text);
            ofc.ExpireDate = Convert.ToDateTime(txtExpireDate.Text);

            if(ofc.Update())
            {
                MessageBox.Show("Recorder Successfully Updated !");

                frmOfferedCourse ofCourse = new frmOfferedCourse();
                ofCourse.btnLoad_Click(null, null);
            }
            else
            {
                MessageBox.Show(ofc.Error);
            }
        }

        private void frmfrmOfferedCourseEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }
    }
}
