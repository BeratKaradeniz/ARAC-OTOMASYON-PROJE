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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AracOtomasyon
{
    public partial class AracDepo : Form
    {
        public AracDepo()
        {
            InitializeComponent();

            refreshWithFilters();
        }

        private void AracDepo_Load(object sender, EventArgs e)
        {
        }
        async void refreshWithFilters()
        {



            List<Arac> araclar = await AutomationManager.database.GetCollection<Arac>("araclar").Find(Builders<Arac>.Filter.And(Builders<Arac>.Filter.Eq("satildi", false), Builders<Arac>.Filter.Regex("plaka", "/" + textBox7.Text + "/i"), Builders<Arac>.Filter.Regex("model", "/" + textBox6.Text + "/i"), Builders<Arac>.Filter.Regex("marka", "/" + textBox1.Text + "/i"), Builders<Arac>.Filter.Regex("renk", "/" + textBox2.Text + "/i"), Builders<Arac>.Filter.Regex("yil", "/" + textBox3.Text + "/i"))).ToListAsync();


            var transactionsDataSource = araclar.Select(x => new
            {
                Id = x._id,
                Plaka = x.plaka,
                Marka = x.marka,
                Model = x.model,
                Yıl = x.yil,
                Renk = x.renk,
                Durum = x.ikinciEl?"İkinci El":"Sıfır",
                Bilgi = x.bilgi,
                AlisTutarı = x.alisTutari,

                seller = x
            }).ToList();

            dataGridView1.DataSource = transactionsDataSource;

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Arac arac = (Arac)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Rows[e.RowIndex].Cells.Count - 1].Value;
            new AracDetay(async (right) =>
            {
                if(!right)
                {
                    await Task.Delay(TimeSpan.FromSeconds(.2f));
                    new AracKayitFormu(arac).ShowDialog();
                    refreshWithFilters();
                } else
                {
                    new SatisFiyati(arac).ShowDialog();
                }
            }).ShowDialog();

            refreshWithFilters();
        }
    }
}
