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
    public partial class Form1 : Form
    {
        List<LOTdata> lotlist = new List<LOTdata>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> combolist = new List<string>();
            combolist.Add("4CC0001");
            combolist.Add("4BB0002");
            combolist.Add("ALL");
            cboLotID.DataSource = combolist;
            cboLotID.Text = "";

            DataBinding();
            //dataGridView1.DataSource = lotlist;
        }

        private void DataBinding()
        {
            LOTdata d1 = new LOTdata();
            d1.LOT_ID = "4CC0001";
            d1.FOUP_ID = "4NP0001";
            d1.PRODUCT = "4G-AA-BB";
            d1.FLOW = "4CC-4G-AA";
            d1.OPERATION = "PHOTO01";
            d1.MACHINE = "PT001";

            LOTdata d2 = new LOTdata();
            d2.LOT_ID = "4BB0002";
            d2.FOUP_ID = "4WP0002";
            d2.PRODUCT = "4G-BB-CC";
            d2.FLOW = "4BB-4G-BB";
            d2.OPERATION = "ETCH01";
            d2.MACHINE = "ET001";

            LOTdata d3 = new LOTdata();
            d3.LOT_ID = "8DD0011";
            d3.FOUP_ID = "4FC0011";
            d3.PRODUCT = "8G-AA-CC";
            d3.FLOW = "8DD-8G-AA";
            d3.OPERATION = "CMP01";
            d3.MACHINE = "CP001";

            lotlist.Add(d1);
            lotlist.Add(d2);
            lotlist.Add(d3);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(cboLotID.Text == "ALL")
            {
                dataGridView1.DataSource = lotlist;
            }
            else
            {
                var searchlist = (from list in lotlist
                                  where list.LOT_ID == cboLotID.Text
                                  select list).ToList();

                dataGridView1.DataSource = searchlist;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            cboLotID.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class LOTdata
    {
        public string LOT_ID { get; set; }
        public string FOUP_ID { get; set; }
        public string PRODUCT { get; set; }
        public string FLOW { get; set; }
        public string OPERATION { get; set; }
        public string MACHINE { get; set; }
    }
}
