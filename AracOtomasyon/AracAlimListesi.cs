using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
    public partial class AracAlimListesi : Form
    {
        public AracAlimListesi()
        {
            InitializeComponent();

            refreshWithFilters();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AracAlimListesi_Load(object sender, EventArgs e)
        {

        }


       


        async void refreshWithFilters()
        {
            if (skipChange) return;
            Console.WriteLine("ran");
            //
            List<BsonDocument> araclar = AutomationManager.database.GetCollection<BsonDocument>("araclar").Aggregate().Lookup("sellers", "sellerId", "_id", "satici").Unwind("satici").AppendStage<BsonDocument>(@"{$addFields:{ad: '$satici.ad',soyad:'$satici.soyad',telefon:'$satici.telefon'}}").Match(Builders<BsonDocument>.Filter.And(Builders<BsonDocument>.Filter.Regex("ad", "/" + textBox2.Text + "/i"), Builders<BsonDocument>.Filter.Regex("soyad", "/" + textBox3.Text + "/i"), Builders<BsonDocument>.Filter.Regex("telefon", "/" + textBox4.Text.Replace("+", "\\+") + "/i"), Builders<BsonDocument>.Filter.Regex("marka", "/" + textBox7.Text + "/i"), Builders<BsonDocument>.Filter.Regex("model", "/" + textBox6.Text + "/i"))).ToList();
            //Match(Builders<BsonDocument>.Filter.And(Builders<BsonDocument>.Filter.Regex("ad", "/" + textBox2.Text + "/i"), Builders<BsonDocument>.Filter.Regex("soyad", "/" + textBox3.Text + "/i"), Builders<BsonDocument>.Filter.Regex("vkn", "/" + textBox4.Text + "/i"), Builders<BsonDocument>.Filter.Regex("marka", "/" + textBox7.Text + "/i"), Builders<BsonDocument>.Filter.Regex("model", "/" + textBox6.Text + "/i"), Builders<BsonDocument>.Filter.Regex("_id", "/" + textBox1.Text + "/i"))).
            //
            Console.WriteLine(araclar.Count);

           

            var transactionsDataSource = araclar.Select(x => new
            {
                Id = x["_id"],
                VKN = x["satici"]["vkn"],
                Ad = x["ad"],
                Soyad = x["satici"]["soyad"],
                Telefon = x["satici"]["telefon"],
                Araç = x["marka"] + " " + x["model"],
                Durum = x["ikinciEl"] == true?"İkinci El": "Sıfır",
                Tutar = x["alisTutari"],

                seller = x
            }).ToList();

            dataGridView1.DataSource = transactionsDataSource;

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;

            
        }

        

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            refreshWithFilters();
        }

        bool skipChange = false;

        private void button1_Click(object sender, EventArgs e)
        {
            new Saticilar((seller) =>
            {
                skipChange = true;
                textBox4.Text = seller.telefon;
                textBox2.Text = seller.ad;
                textBox3.Text = seller.soyad;


                skipChange = false;
                refreshWithFilters();


            }).ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BsonDocument document = (BsonDocument)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Rows[e.RowIndex].Cells.Count - 1].Value;

            var satici = document["satici"].AsBsonDocument;
            document.Remove("satici");
            document.Remove("ad");
            document.Remove("soyad");
            document.Remove("telefon");

            new AracBilgileri(BsonSerializer.Deserialize<Arac>(document), BsonSerializer.Deserialize<Seller>(satici)).ShowDialog();
        }
    }
}
