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
    public partial class frmStudentCourse : Form
    {
        Presentation.frmNewStudentCourse newsCourse = new frmNewStudentCourse();
        public frmStudentCourse()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(newsCourse.IsDisposed)
            {
                newsCourse = new frmNewStudentCourse();
            }

            newsCourse.ShowDialog();
            newsCourse.BringToFront();
        }

        private void frmStudentCourse_Load(object sender, EventArgs e)
        {
            DAL.StudentCourses stCourses = new DAL.StudentCourses();

            gridStudentCourses.DataSource = stCourses.Select().Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.StudentCourses stCourse = new DAL.StudentCourses();

            stCourse.Search = txtSearch.Text;

            
        }
    }
}
