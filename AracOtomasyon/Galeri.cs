using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AracOtomasyon
{
    public partial class Galeri : Form
    {
        public Galeri()
        {
            InitializeComponent();
            refresh();
        }

        private void Galeri_Load(object sender, EventArgs e)
        {

        }

        void setArac(Arac arac)
        {
            renkLabel.Text = arac.renk;
            
            yilLabel.Text = arac.yil;
            markaLabel.Text = arac.marka;
            modelLabel.Text = arac.model;
            durumLabel.Text = arac.ikinciEl ? "Ikinci El" : "Sıfır";
            bilgiLabel.Text = arac.bilgi;

          

            if (arac.fotograf != null)
            {
                pictureBox1.Image = (Image)new ImageConverter().ConvertFrom(arac.fotograf);
            } else
            {
                pictureBox1.Image = null;
            }
        }
        async void refresh()
        {
            List<Arac> sellers = await AutomationManager.database.GetCollection<Arac>("araclar").Find(Builders<Arac>.Filter.And(Builders<Arac>.Filter.Gt("satisTutari", 0), Builders<Arac>.Filter.Eq("satildi", false))).ToListAsync();
            var transactionsDataSource = sellers.Select(x => new
            {
                Id = x._id,
                Plaka = x.plaka,
                Marka = x.marka,
                Model = x.model,
                Yıl = x.yil,
                Renk = x.renk,
                Durum = (x.ikinciEl)?"İkinci El":"Sıfır",
                Bilgi = x.bilgi,
                Tutar = x.satisTutari.ToString("N2") + "₺",
                sel = x
            }).ToList();
            dataGridView1.DataSource = transactionsDataSource;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var row = dataGridView1.Rows[e.RowIndex];

            setArac((Arac)row.Cells[row.Cells.Count - 1].Value);

            Console.WriteLine("asdjhaskjd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new AracSatisDetay((Arac)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Rows[e.RowIndex].Cells.Count - 1].Value).ShowDialog();
            refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AracDepo().ShowDialog();
            refresh();
        }
    }
}
