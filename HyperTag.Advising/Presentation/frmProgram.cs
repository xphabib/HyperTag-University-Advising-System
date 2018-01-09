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
    public partial class frmProgram : Form
    {   

       
        public frmProgram()
        {
            InitializeComponent();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            frmProgramNew prgrmNew = new frmProgramNew();
            prgrmNew.ShowDialog();
            prgrmNew.StartPosition = FormStartPosition.CenterParent;
            searchBtn_Click(null, null);
            
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            DAL.Program program = new DAL.Program();
            dgvData.DataSource = program.Select().Tables[0];
        }

        private void frmProgram_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //Presentation.frmEditProgram editProgram = new frmEditProgram();
            //editProgram.Id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["colId"].Value);
            //editProgram.ShowDialog();
            //searchBtn_Click(null, null);
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            new Report.frmReport(dgvData).ShowDialog();
        }
    }
}
 