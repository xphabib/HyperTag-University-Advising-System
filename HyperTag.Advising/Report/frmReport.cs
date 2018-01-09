using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising.Report
{
    public partial class frmReport : Form
    {
        public frmReport(DataGridView dgv)
        {
            InitializeComponent();

            string s = loadHeader();
            s += loadData(dgv);
            s += loadFooter();
            webBrowser1.DocumentText = s;
        }

        private string loadData(DataGridView dgv)
        {
            string s = "<table width=\"1000\" border=\"1\">";
           for(int i = 0; i< dgv.Rows.Count; i++)
            {
                s += "<tr>";
                for(int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                {
                    s += "<td>" + dgv.Rows[i].Cells[j].Value.ToString() + "</td>";
                }
                s += "</tr>";
            }
            s += "</table>";
            return s;
        }

        private string loadFooter()
        {
            string s = @"</body>
                        </ html > ";
            return s;
        }

        private string loadHeader()
        {
            string s = string.Format(@"<html>
                        <head>
                        <title>
                        My Sweet Report
                        </title>
                        </head>
                        <body>
                        <div>
                            <h1>{0}</h1>
                            <h2>{1}</h2>
                            <h3>{2}</h3>
                        </div>", ACL.Name, ACL.Address1, ACL.Address2);
            return s;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }
    }
}
