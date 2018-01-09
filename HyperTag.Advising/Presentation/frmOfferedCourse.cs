using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hypertag.Advising.Presentation;
using Hypertag.Advising.DAL;

namespace Hypertag.Advising.Presentation
{
    public partial class frmOfferedCourse : Form
    {
        frmfrmOfferedCourseNew offeredCoureseNew = new frmfrmOfferedCourseNew();
        frmfrmOfferedCourseEdit offeredCourseEdit = new frmfrmOfferedCourseEdit();
        private int selectedRowId { get; set; }

        public frmOfferedCourse()
        {
            InitializeComponent();
        }

        private void frmOfferedCourse_Load(object sender, EventArgs e)
        {
            MinimumSize = this.Size;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (offeredCoureseNew.IsDisposed)
                offeredCoureseNew = new frmfrmOfferedCourseNew();
            offeredCoureseNew.MdiParent = this.MdiParent;
            offeredCoureseNew.Show();
            offeredCoureseNew.BringToFront();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (offeredCourseEdit.IsDisposed)
                offeredCourseEdit = new frmfrmOfferedCourseEdit(selectedRowId);
            offeredCourseEdit.MdiParent = this.MdiParent;
            offeredCourseEdit.Show();
            offeredCourseEdit.BringToFront();
        }

        public void btnLoad_Click(object sender, EventArgs e)
        {
            

            OfferedCourse offeredcourse = new OfferedCourse ();

            dgbOfferedCourse.DataSource = offeredcourse.Select().Tables[0];
            
        }

        private void frmOfferedCourse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{Tab}");
        }

        

        private void dgbOfferedCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgbOfferedCourse.Rows[e.RowIndex].Selected = true;
            selectedRowId = Convert.ToInt32(dgbOfferedCourse.Rows[e.RowIndex].Cells[0].Value);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Are you sure you want to delete ?","",)
            // want to pop up  message before delete 

            DAL.OfferedCourse ofc = new OfferedCourse();
            //ofc.Id = selectedRowId;
            if(ofc.Delete())
            {
                MessageBox.Show("Recored successfully deleted !");
            }
            else
            {
                MessageBox.Show(ofc.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL.OfferedCourse ofc = new OfferedCourse();
            
            

            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("Search by Id");
                return;
            }
            //ofc.Id = Convert.ToInt32(txtSearch.Text);
            dgbOfferedCourse.DataSource = ofc.SelectById();
                
            
        }
    }
}
