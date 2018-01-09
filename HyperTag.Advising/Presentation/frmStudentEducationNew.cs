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
    public partial class frmStudentEducationNew : Form
    {
        
        ErrorProvider ep = new ErrorProvider();
        public frmStudentEducationNew()
        {
            InitializeComponent();
        }

        

        private void frmStudentEducationNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        private void frmStudentEducationNew_Load(object sender, EventArgs e2)
        {
            MinimumSize = this.Size;
            cmbDocumentType.SelectedIndex = 0;

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int er = 0;
            ep.Clear();

            //if(cmbStudent.Text == "")
            //{
            //    er++;
            //    ep.SetError(txtStudentId, "Requered");
            //}

            //if (txtEducationId.Text == "")
            //{
            //    er++;
            //    ep.SetError(txtEducationId, "Requered");
            //}

            //if (txtEducationBoardId.Text == "")
            //{
            //    er++;
            //    ep.SetError(txtEducationBoardId, "Requered");
            //}

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

            studentEducation.StudentId = Convert.ToInt32(cmbStudent.SelectedValue);
            studentEducation.EducationId = Convert.ToInt32(cmbEducation.SelectedValue);
            studentEducation.EducationBoardId = Convert.ToInt32(cmbEducationBoard.SelectedValue);
            studentEducation.Year = Convert.ToInt32(txtYear.Text);
            studentEducation.Registration = txtRegistration.Text;
            studentEducation.Roll = txtRoll.Text;
            studentEducation.Remarks = txtRemarks.Text;
            studentEducation.Result = txtResult.Text;
            studentEducation.DocumentType = cmbDocumentType.Text;
            studentEducation.Document = Hypertag.Advising.filImage.FileToByte(txtDocument.Text);
            studentEducation.fileName = System.IO.Path.GetFileName( txtDocument.Text);

            // document here 

            if (studentEducation.Insert())
            {
                MessageBox.Show("Recored successfully Inserted !");
               //reset er code hobe
            }
            else
            {
                MessageBox.Show(studentEducation.Error);
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName == null || ofd.FileName == "")
                return;

            txtDocument.Text = ofd.FileName;
        }
    }
}
