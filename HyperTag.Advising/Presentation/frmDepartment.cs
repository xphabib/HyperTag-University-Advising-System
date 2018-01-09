using Hypertag.Advising.Presentation;
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
    public partial class departmentFrm : Form
    {


        
        public departmentFrm()
        {
            InitializeComponent();
        }
       

        private void searchBtn_Click(object sender, EventArgs e)
        {
            DAL.Department department = new DAL.Department();
            dgvData.DataSource = department.Select().Tables[0];

        }

        private void newBtn_Click(object sender, EventArgs e)
        {

            frmDepartmentNew departmentNew = new frmDepartmentNew();
            departmentNew.StartPosition = FormStartPosition.CenterParent;
            departmentNew.ShowDialog();
            searchBtn_Click(null, null); 

        }

        private void departmentFrm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //frmEditDepartment editDepartment = new frmEditDepartment();
            //editDepartment.Id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["colId"].Value);
            //editDepartment.ShowDialog();
            //searchBtn_Click(null, null);
        }
    }
}
