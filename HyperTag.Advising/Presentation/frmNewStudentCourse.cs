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
    public partial class frmNewStudentCourse : Form
    {
        ErrorProvider ep = new ErrorProvider();

        public frmNewStudentCourse()
        {
            InitializeComponent();
        }

        private void frmNewStudentCourse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbsetSemester.Semester' table. You can move, or remove it, as needed.
            this.semesterTableAdapter.Fill(this.dbsetSemester.Semester);
            // TODO: This line of code loads data into the 'dbsetCourse.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.dbsetCourse.Course);
            // TODO: This line of code loads data into the 'dbsetStudent.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.dbsetStudent.Student);

            cmbCourse.SelectedValue = -1;
            cmbStudent.SelectedValue = -1;
            cmbSemester.SelectedValue = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int err = 0;

            if(cmbCourse.SelectedValue == null || cmbCourse.SelectedValue.ToString() == "")
            {
                err++;
                ep.SetError(cmbCourse,"Required");
            }
            if(cmbSemester.SelectedValue == null || cmbSemester.SelectedValue.ToString() == "")
            {
                err++;
                ep.SetError(cmbSemester, "Required");
            }
            if(cmbStudent.SelectedValue == null || cmbStudent.SelectedValue.ToString() == "")
            {
                err++;
                ep.SetError(cmbStudent, "Required");
            }
            if(txtDate.Text == "")
            {
                err++;
                ep.SetError(txtDate, "Required");
            }

            if(err < 1)
            {
                DAL.StudentCourses studentCourse = new DAL.StudentCourses();

                studentCourse.CourseId = Convert.ToInt32(cmbCourse.SelectedValue);
                studentCourse.SemesterId = Convert.ToInt32(cmbSemester.SelectedValue);
                studentCourse.StudentId = Convert.ToInt32(cmbStudent.SelectedValue);
                studentCourse.Date = Convert.ToDateTime(txtDate.Text);
                studentCourse.Remarks = txtRemarks.Text;

                if(studentCourse.Insert())
                {
                    MessageBox.Show("Data saved");
                }
                else
                {
                    MessageBox.Show(studentCourse.Error);
                }
            }
            else
            {
                return;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
