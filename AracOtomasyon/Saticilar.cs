using MongoDB.Driver;
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
    public partial class Saticilar : Form
    {


        Action<Seller> selected;
        public Saticilar(Action<Seller> selected)
        {
            this.selected = selected;
            InitializeComponent();

            refreshWithFilters();
        }


        async void refreshWithFilters()
        {
            

            
            List<Seller> sellers = await AutomationManager.database.GetCollection<Seller>("sellers").Find(Builders<Seller>.Filter.And(Builders<Seller>.Filter.Regex("ad","/"+textBox2.Text+"/i"), Builders<Seller>.Filter.Regex("soyad", "/" + textBox3.Text + "/i"), Builders<Seller>.Filter.Regex("vkn", "/" + textBox1.Text + "/i"), Builders<Seller>.Filter.Regex("telefon", "/" + textBox4.Text + "/i"))).ToListAsync();


            var transactionsDataSource = sellers.Select(x => new
            {
                Id = x._id,
                VKN = x.vkn,
                Ad = x.ad,
                Soyad = x.soyad,
                Telefon = x.telefon,
                
                seller = x
            }).ToList();

            dataGridView1.DataSource = transactionsDataSource;

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (selected != null)
            {
                this.selected((Seller)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Rows[e.RowIndex].Cells.Count - 1].Value);
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Saticilar_Load(object sender, EventArgs e)
        {

        }
    }
}
