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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        frmStudentNew newStudent = new frmStudentNew();

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (newStudent.IsDisposed)
                newStudent = new frmStudentNew();
            newStudent.MdiParent = this.MdiParent;
            newStudent.Show();
            newStudent.BringToFront();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int countryId = 0,departmentId = 0;
            DAL.Student student = new DAL.Student();
            student.Name = txtSearch.Text;
            if (cmbCity.SelectedValue != null && cmbCity.SelectedValue.ToString() != "")
                student.CityId = Convert.ToInt32(cmbCity.SelectedValue);

            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != "")
                countryId = Convert.ToInt32(cmbCountry.SelectedValue);

            if (cmbProgram.SelectedValue != null && cmbProgram.SelectedValue.ToString() != "")
                student.ProgramId = Convert.ToInt32(cmbProgram.SelectedValue);

            if (cmbDepartment.SelectedValue != null && cmbDepartment.SelectedValue.ToString() != "")
                departmentId = Convert.ToInt32(cmbCountry.SelectedValue);

            StudentdataGridView.DataSource = student.Select(countryId,departmentId).Tables[0];
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);

            DAL.Country country = new DAL.Country();
            cmbCountry.DataSource = country.Select("Where id in (Select countryId from city)").Tables[0];

            cmbCountry.DisplayMember = "name";
            cmbCountry.ValueMember = "Id";
            cmbCountry.SelectedValue = -1;

            DAL.Department department = new DAL.Department();
            cmbDepartment.DataSource = department.Select("Where id in (Select departmentId from program)").Tables[0];

            cmbDepartment.DisplayMember = "name";
            cmbDepartment.ValueMember = "Id";
            cmbDepartment.SelectedValue = -1;
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedValue == null || cmbCountry.SelectedValue.ToString() == "")
                return;

            try
            {
                DAL.City city = new DAL.City();
                city.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                cmbCity.DataSource = city.Select().Tables[0];

                cmbCity.DisplayMember = "name";
                cmbCity.ValueMember = "Id";
                cmbCity.SelectedValue = -1;
            }
            catch (Exception)
            {

            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedValue == null || cmbDepartment.SelectedValue.ToString() == "")
                return;

            try
            {
                DAL.Program program = new DAL.Program();
                program.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                cmbProgram.DataSource = program.Select().Tables[0];

                cmbProgram.DisplayMember = "name";
                cmbProgram.ValueMember = "Id";
                cmbProgram.SelectedValue = -1;
            }
            catch (Exception)
            {

            }
        }
    }
}
