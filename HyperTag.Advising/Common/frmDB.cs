using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising.Common
{
    public partial class frmDB : Form
    {
        public frmDB()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string s = "";
            if(chkWindows.Checked)
            {
                s = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", txtServer.Text, txtDatabase.Text);
            }
            else
            {
                s = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtServer.Text, txtDatabase.Text, txtUserID.Text, txtPassword.Text); 
            }
            Advising.Properties.Settings.Default.MyCon = s;
            Advising.Properties.Settings.Default.Save();
            MessageBox.Show("Database Settings Saved");

        }

        private void chkWindows_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !chkWindows.Checked;
        }

        private void frmDB_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = !chkWindows.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            if (chkWindows.Checked)
            {
                s = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", txtServer.Text, "master");
            }
            else
            {
                s = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtServer.Text, "master", txtUserID.Text, txtPassword.Text);
            }
            Advising.Properties.Settings.Default.MyCon = s;
            Advising.Properties.Settings.Default.Save();

            DAL.Country c = new DAL.Country();
            if (c.Database(txtDatabase.Text))
            {
                if (chkWindows.Checked)
                {
                    s = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", txtServer.Text, txtDatabase.Text);
                }
                else
                {
                    s = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", txtServer.Text, txtDatabase.Text, txtUserID.Text, txtPassword.Text);
                }
                Advising.Properties.Settings.Default.MyCon = s;
                Advising.Properties.Settings.Default.Save();

                List<DAL.IDatabase> tables = new List<DAL.IDatabase>();
                tables.Add(new DAL.Country());
                tables.Add(new DAL.City());
                tables.Add(new DAL.Department());
                tables.Add(new DAL.Program());
                tables.Add(new DAL.course());

                foreach(DAL.IDatabase table in tables)
                {
                    if(table.Table())
                    {
                        listBox1.Items.Add(table.ToString() + " created");
                    }
                    else
                    {
                        listBox1.Items.Add("Error : " + table.ToString() + " -> " + table.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(c.Error);
            }


        }
    }
}
