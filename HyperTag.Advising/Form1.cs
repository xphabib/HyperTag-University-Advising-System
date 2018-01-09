using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising
{
    public partial class Form1 : Form
    {
        Common.frmUI UI = new Common.frmUI();
        Common.frmDB db = new Common.frmDB();
        Common.frmProfile profile = new Common.frmProfile();
        departmentFrm department = new departmentFrm();
        Presentation.frmProgram program = new Presentation.frmProgram();
        Presentation.frmUser user = new Presentation.frmUser();
        Presentation.frmCourse course = new Presentation.frmCourse();
        Presentation.frmStudent student = new Presentation.frmStudent();
        Presentation.frmTeacher teacher = new Presentation.frmTeacher();
        Presentation.frmOfferedCourse offeredCourse = new Presentation.frmOfferedCourse();
        Presentation.frmStudentEducation studentEducation = new Presentation.frmStudentEducation();
        Presentation.frmTeacherCourse teacerCourse = new Presentation.frmTeacherCourse();
        Presentation.frmStudentCourse stCourse = new Presentation.frmStudentCourse();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Login();   

            Hypertag.Advising.ACL.Login = new DAL.Login() {  LoginId = 1, Contact = "", Email = "admin@system.com", Password = "", Name = "Mr System Admin", Type = "A"};


        }

        private void Login()
        {
            Hypertag.Advising.ACL.Login = null;
            mnuMain.Enabled = false;
            mnuUserList.Visible = false;
            mnuAdmin.Visible = false;
            btnLogInOut.Text = "Login";
            Hypertag.Advising.Common.frmLogin lgn = new Hypertag.Advising.Common.frmLogin();
            lgn.ShowDialog();

            Hypertag.Advising.DAL.MyBase ct = new Hypertag.Advising.DAL.City();



            

            if (Hypertag.Advising.ACL.Login != null)
            {
                mnuMain.Enabled = true;
                if (Hypertag.Advising.ACL.Login.Type == "A")
                {
                    mnuUserList.Visible = !false;
                    mnuAdmin.Visible = !false;
                }
                btnLogInOut.Text = "Logout";
            }
        }

        private void btnLogInOut_Click(object sender, EventArgs e)
        {
            //Login();
        }

        private void uISettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UI.IsDisposed)
                UI = new Common.frmUI();
            UI.MdiParent = this;
            UI.Show();
            UI.BringToFront();
        }

        private void dBSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (db.IsDisposed)
                db = new Common.frmDB();
            db.MdiParent = this;
            db.Show();
            db.BringToFront();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTest().ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Help.frmManual().Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profile.IsDisposed)
                profile = new Common.frmProfile();
            profile.MdiParent = this;
            profile.Show();
            profile.BringToFront();
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (department.IsDisposed)
                department = new Advising.departmentFrm();
            department.MdiParent = this;
            department.Show();
            department.BringToFront();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (program.IsDisposed)
                program = new Presentation.frmProgram();
            program.MdiParent = this;
            program.Show();
            program.BringToFront();
        }

        private void mnuUserList_Click(object sender, EventArgs e)
        {
            if (user.IsDisposed)
                user = new Presentation.frmUser();
            user.MdiParent = this;
            user.Show();
            user.BringToFront();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (student.IsDisposed)
                student = new Presentation.frmStudent();
            student.MdiParent = this;
            student.Show();
            student.BringToFront();
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (course.IsDisposed)
                course = new Presentation.frmCourse();
            course.MdiParent = this;
            course.Show();
            course.BringToFront();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void teacherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (teacher.IsDisposed)
                teacher = new Presentation.frmTeacher();
            teacher.MdiParent = this;
            teacher.Show();
            teacher.BringToFront();
        }

        private void educationHistroryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (studentEducation.IsDisposed)
                studentEducation = new Presentation.frmStudentEducation();
            studentEducation.MdiParent = this;
            studentEducation.Show();
            studentEducation.BringToFront();
        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {

        }

        private void courseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(teacerCourse.IsDisposed)
            {
                teacerCourse = new Presentation.frmTeacherCourse();
            }

            teacerCourse.MdiParent = this;
            teacerCourse.Show();
            teacerCourse.BringToFront();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (offeredCourse.IsDisposed)
                offeredCourse = new Presentation.frmOfferedCourse();
            offeredCourse.MdiParent = this;
            offeredCourse.Show();
            offeredCourse.BringToFront();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if(stCourse.IsDisposed)
            {
                stCourse = new Presentation.frmStudentCourse();
            }

            stCourse.MdiParent = this;
            stCourse.Show();
            stCourse.BringToFront();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }
    }
}