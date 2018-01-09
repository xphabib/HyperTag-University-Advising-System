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
    public partial class frmTeacher : Form
    {
        public frmTeacher()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Presentation.TeacherNew tnew = new Presentation.TeacherNew();
            tnew.ShowDialog();
        }

        private void frmTeacher_Load(object sender, EventArgs e)
        {
            DAL.teacher t = new DAL.teacher();
           dgbTeacher.DataSource = t.Select().Tables[0];
           
        }
    }
}
