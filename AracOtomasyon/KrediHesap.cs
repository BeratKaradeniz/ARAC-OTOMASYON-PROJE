using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracOtomasyon
{
    public partial class KrediHesap : Form
    {
        public KrediHesap(string val)
        {
            InitializeComponent();


            Dictionary<string, dynamic> test = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(val);


            JArray products = test["products"];


            dataGridView1.Rows.Clear();

            foreach (var item in products)
            {





                dataGridView1.Rows.Add((string)item["bank"]["name"], (string)item["name"], "%" + ((double)item["interestRate"]), (double)item["monthlyInstallment"] + "₺", (double)item["totalAmount"] + "₺", "https://hangikredi.com" + (string)item["recourseLink"]);
            }

            
        }

        private void KrediHesap_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                System.Diagnostics.Process.Start((string)senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }
    }
}
