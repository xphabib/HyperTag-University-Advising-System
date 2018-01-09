using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hypertag.Advising.DAL;

namespace Hypertag.Advising.Presentation
{
    public partial class frmStudentNew : Form
    {
        public frmStudentNew()
        {
            InitializeComponent();
        }

        private string ImageLocation { get; set; }
        ErrorProvider ep = new ErrorProvider();
        private void frmStudentNew_Load(object sender, EventArgs e)
        {
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG|*.jpg|PNG|*.png|GIF|*.gif";
            ofd.ShowDialog();
            if (ofd.FileName == null || ofd.FileName == "")
                return;
            imageBox.Image = Image.FromFile(ofd.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ep.Clear();
            int er = 0;

            if (txtName.Text == "")
            {
                er++;
                ep.SetError(txtName, "Required");
            }
            if (txtEmail.Text == "")
            {
                er++;
                ep.SetError(txtEmail, "Required");
            }
            if (txtStudentId.Text == "")
            {
                er++;
                ep.SetError(txtStudentId, "Required");
            }
            if (txtBloodgroup.Text == "")
            {
                er++;
                ep.SetError(txtBloodgroup, "Required");
            }
            if (txtFatherName.Text == "")
            {
                er++;
                ep.SetError(txtFatherName, "Required");
            }
            if (txtMotherName.Text == "")
            {
                er++;
                ep.SetError(txtMotherName, "Required");
            }
            if (txtLocalGaurdian.Text == "")
            {
                er++;
                ep.SetError(txtLocalGaurdian, "Required");
            }
            if (txtPresentAddress.Text == "")
            {
                er++;
                ep.SetError(txtPresentAddress, "Required");
            }
            if (txtPermanentAddress.Text == "")
            {
                er++;
                ep.SetError(txtPresentAddress, "Required");
            }
            if (cmbCountry.SelectedValue == null || cmbCountry.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCountry, "Select One");
            }
            if (cmbCity.SelectedValue == null || cmbCity.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbCity, "Select One");
            }
            if (cmbProgram.SelectedValue == null || cmbProgram.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbProgram, "Select One");
            }
            if (cmbDepartment.SelectedValue == null || cmbDepartment.SelectedValue.ToString() == "")
            {
                er++;
                ep.SetError(cmbDepartment, "Select One");
            }

            if (er > 0)
                return;

            DAL.Student student = new Student();
            student.Image = filImage.ImageToByte( imageBox.Image);
            student.Name = txtName.Text;
            student.Email = txtEmail.Text;
            student.IdNumber = txtStudentId.Text;
            student.BloodGroup = txtBloodgroup.Text;
            student.FatherName = txtFatherName.Text;
            student.MotherName = txtMotherName.Text;
            student.LocalGuardian = txtLocalGaurdian.Text;
            student.AddressPresent = txtPresentAddress.Text;
            student.AddressPermanent = txtPermanentAddress.Text;
            student.CityId =Convert.ToInt32(cmbCity.SelectedValue);
            student.ProgramId = Convert.ToInt32(cmbProgram.SelectedValue);

            if (student.Insert())
            {
                MessageBox.Show("Data Saved");
                txtName.Text = "";
                imageBox.ImageLocation = null;
                txtEmail.Text = "";
                txtBloodgroup.Text = "";
                txtStudentId.Text = "";
                txtFatherName.Text = "";
                txtMotherName.Text = "";
                txtLocalGaurdian.Text = "";
                txtPresentAddress.Text = "";
                txtPermanentAddress.Text = "";
                cmbCity.SelectedValue = -1;
                cmbProgram.SelectedValue = -1;
                cmbCountry.SelectedValue = -1;
                cmbDepartment.SelectedValue = -1;
                txtName.Focus();
            }
            else
            {
                MessageBox.Show(student.Error);
            }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
