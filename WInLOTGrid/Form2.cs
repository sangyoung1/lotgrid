using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInLOTGrid
{
    public partial class Form2 : Form
    {
        DataTable dt = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] cboitem = { "4CC0001", "4BB0002", "ALL" };
            cboLotID.DataSource = cboitem;
            cboLotID.Text = "";

            DataBinding();
            dataGridView1.DataSource = dt;
        }

        private void DataBinding()
        {
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("LOT_ID",typeof(string)));
            dt.Columns.Add(new DataColumn("FOUP_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("PRODUCT", typeof(string)));
            dt.Columns.Add(new DataColumn("FLOW", typeof(string)));
            dt.Columns.Add(new DataColumn("OPERATION", typeof(string)));
            dt.Columns.Add(new DataColumn("MACHINE", typeof(string)));

            dr = dt.NewRow();
            dr.ItemArray = new object[] { "4CC0001", "4NP0001", "4G-AA-BB", "4CC-4G-AA", "PHOTO01", "PT001" };
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { "4BB0002", "4WP0002", "4G-BB-CC", "4BB-4G-BB", "ETCH01", "ET001" };
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { "8DD0011", "4FC0011", "8G-AA-CC", "8DD-8G-AA", "CMP01", "CP001" };
            dt.Rows.Add(dr);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cboLotID.Text == "ALL")
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                var searchdt = dt.Select($"LOT_ID ='{cboLotID.Text}'").CopyToDataTable();
                dataGridView1.DataSource = searchdt;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
            cboLotID.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
