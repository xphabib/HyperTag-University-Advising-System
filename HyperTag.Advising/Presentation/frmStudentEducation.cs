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
    public partial class frmStudentEducation : Form
    {
        frmStudentEducationNew studentEducationNew = new frmStudentEducationNew();
        frmStudentEducationEdit studentEducationEdit = new frmStudentEducationEdit();
        private int selectedRowId { get; set; }

        public frmStudentEducation()
        {
            InitializeComponent();
        }

        private void frmStudentEducation_Load(object sender, EventArgs e2)
        {
            MinimumSize = this.Size;

            DAL.Student s = new DAL.Student();
            cmbStudent.DataSource = s.Select().Tables[0];
            cmbStudent.DisplayMember = "name";
            cmbStudent.ValueMember = "id";
            cmbStudent.SelectedValue = -1;


            DAL.Education e = new DAL.Education();
            cmbEducation.DataSource = e.Select().Tables[0];
            cmbEducation.DisplayMember = "name";
            cmbEducation.ValueMember = "id";
            cmbEducation.SelectedValue = -1;

            DAL.EducationBoard eb = new DAL.EducationBoard();
            cmbEducationBoard.DataSource = eb.Select().Tables[0];
            cmbEducationBoard.DisplayMember = "name";
            cmbEducationBoard.ValueMember = "id";
            cmbEducationBoard.SelectedValue = -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (studentEducationNew.IsDisposed)
                studentEducationNew = new frmStudentEducationNew();
            studentEducationNew.MdiParent = this.MdiParent;
            studentEducationNew.Show();
            studentEducationNew.BringToFront();
                
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (studentEducationEdit.IsDisposed)
                studentEducationEdit = new frmStudentEducationEdit(selectedRowId);
            studentEducationEdit.MdiParent = this.MdiParent;
            studentEducationEdit.Show();
            studentEducationEdit.BringToFront();
        }

        private void dgbStudentEducation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgbStudentEducation.Rows[e.RowIndex].Selected = true;
            selectedRowId = Convert.ToInt32(dgbStudentEducation.Rows[e.RowIndex].Cells[0].Value);
        }

        public void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Are you sure you want to delete ?","",)
            // want to pop up  message before delete 

            DAL.StudentEducation stEdu = new DAL.StudentEducation();
            //stEdu.Id = selectedRowId;
            if (stEdu.Delete())
            {
                MessageBox.Show("Recored successfully deleted !");
            }
            else
            {
                MessageBox.Show(stEdu.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            DAL.StudentEducation stEdu = new DAL.StudentEducation();

            stEdu.Search = txtSearch.Text;
            if (cmbEducation.SelectedValue != null && cmbEducation.SelectedValue.ToString() != "")
            {
                stEdu.EducationId = Convert.ToInt32(cmbEducation.SelectedValue);
            }
            if (cmbStudent.SelectedValue != null && cmbStudent.SelectedValue.ToString() != "")
            {
                stEdu.StudentId = Convert.ToInt32(cmbStudent.SelectedValue);
            }
            if (cmbEducationBoard.SelectedValue != null && cmbEducationBoard.SelectedValue.ToString() != "")
            {
                stEdu.EducationBoardId = Convert.ToInt32(cmbEducationBoard.SelectedValue);
            }

            dgbStudentEducation.DataSource = stEdu.Select().Tables[0];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgbStudentEducation_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.RowIndex.ToString() + ", " + e.ColumnIndex.ToString());

            if(e.ColumnIndex == 10)
            {
                DAL.StudentEducation se = new DAL.StudentEducation();
                se.StudentId = Convert.ToInt32(dgbStudentEducation.Rows[e.RowIndex].Cells["colStudentId"].Value);
                se.EducationId = Convert.ToInt32(dgbStudentEducation.Rows[e.RowIndex].Cells["colEducationId"].Value); ;
                if(se.SelectById())
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowDialog();

                    Hypertag.Advising.filImage.FileFromByte(se.Document, fbd.SelectedPath + "/" + se.fileName);
                    MessageBox.Show("Downloaded");

                }
                else
                {
                    MessageBox.Show("Vul Shobi Vul");
                }
            }


        }
    }
}
