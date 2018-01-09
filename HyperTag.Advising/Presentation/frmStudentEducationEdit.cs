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
    public partial class frmStudentEducationEdit : Form
    {
        ErrorProvider ep = new ErrorProvider();
        public frmStudentEducationEdit()
        {
            InitializeComponent();
        }

        public frmStudentEducationEdit(int id)
        {
            InitializeComponent();

            DAL.StudentEducation studentEducation = new DAL.StudentEducation();
            if(studentEducation.SelectById())
            {
                txtStudentId.Text = studentEducation.StudentId.ToString();
                txtEducationId.Text = studentEducation.EducationId.ToString();
                txtEducationBoardId.Text = studentEducation.EducationBoardId.ToString();
                txtRegistration.Text = studentEducation.Registration;
                txtResult.Text = studentEducation.Result;
                txtRoll.Text = studentEducation.Roll;
                txtRoll.Text = studentEducation.Remarks;
            }


        }

        private void frmStudentEducationEdit_Load(object sender, EventArgs e)
        {
            MinimumSize = this.Size;
        }

        private void frmStudentEducationEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            if (txtStudentId.Text == "")
            {
                er++;
                ep.SetError(txtStudentId, "Requered");
            }

            if (txtEducationId.Text == "")
            {
                er++;
                ep.SetError(txtEducationId, "Requered");
            }

            if (txtEducationBoardId.Text == "")
            {
                er++;
                ep.SetError(txtEducationBoardId, "Requered");
            }

            if (txtYear.Text == "")
            {
                er++;
                ep.SetError(txtYear, "Requered");
            }

            if (txtRegistration.Text == "")
            {
                er++;
                ep.SetError(txtRegistration, "Requered");
            }

            if (txtRoll.Text == "")
            {
                er++;
                ep.SetError(txtRoll, "Requered");
            }

            if (er > 0)
                return;

            DAL.StudentEducation studentEducation = new DAL.StudentEducation();

            studentEducation.StudentId = Convert.ToInt32(txtStudentId.Text);
            studentEducation.EducationId = Convert.ToInt32(txtEducationId.Text);
            studentEducation.EducationBoardId = Convert.ToInt32(txtEducationBoardId.Text);
            studentEducation.Registration = txtRegistration.Text;
            studentEducation.Roll = txtRoll.Text;
            studentEducation.Remarks = txtRemarks.Text;
            studentEducation.Year = Convert.ToInt32(txtYear.Text);

            //studentEducation.Document = btnDocument.Text;
            studentEducation.DocumentType = txtDocument.Text;

            if(studentEducation.Update())
            {
                MessageBox.Show("Recored successfully updated !");

                frmStudentEducation stEdu = new frmStudentEducation();
                stEdu.btnLoad_Click(null, null);

            }
            else
            {
                MessageBox.Show(studentEducation.Error);
            }
        }
    }
}
