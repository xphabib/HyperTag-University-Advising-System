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
    public partial class frmTeacherCourse : Form
    {
        Presentation.frmNewTeacherCourse newTCourse = new frmNewTeacherCourse();
        public frmTeacherCourse()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if(newTCourse.IsDisposed)
            {
                newTCourse = new frmNewTeacherCourse();
            }

            newTCourse.ShowDialog();
            newTCourse.BringToFront();
        }
    }
}
