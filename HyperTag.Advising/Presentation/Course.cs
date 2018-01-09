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
    public partial class frmCourse : Form
    {
        public frmCourse()
        {
            InitializeComponent();
        }

        private void Course_Load(object sender, EventArgs e)
        {
            DAL.course c = new DAL.course();
            dgbCourse.DataSource = c.Select().Tables[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Presentation.CourseNew CN = new Presentation.CourseNew();
            CN.ShowDialog();
            CN.MdiParent = this;
        }

  
    }
}
