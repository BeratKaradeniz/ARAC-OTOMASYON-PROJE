using MongoDB.Bson;
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
    public partial class Yonetici : Form
    {
        public Yonetici()
        {
            InitializeComponent();

            refreshUsersList();
        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
        }
        async void refreshUsersList()
        {
            List<User> kullanicilar = await(await AutomationManager.database.GetCollection<User>("kullanicilar").FindAsync(FilterDefinition<User>.Empty)).ToListAsync();
            //Match(Builders<BsonDocument>.Filter.And(Builders<BsonDocument>.Filter.Regex("ad", "/" + textBox2.Text + "/i"), Builders<BsonDocument>.Filter.Regex("soyad", "/" + textBox3.Text + "/i"), Builders<BsonDocument>.Filter.Regex("vkn", "/" + textBox4.Text + "/i"), Builders<BsonDocument>.Filter.Regex("marka", "/" + textBox7.Text + "/i"), Builders<BsonDocument>.Filter.Regex("model", "/" + textBox6.Text + "/i"), Builders<BsonDocument>.Filter.Regex("_id", "/" + textBox1.Text + "/i"))).
            //
            
            var transactionsDataSource = kullanicilar.Select(x => new
            {
                ID = x._id,
                Isim = x.name,
                Email = x.email,
                Rol = x.role == 0?"Admin":"Kullanıcı",
                seller = x
            }).ToList();
            dataGridView1.DataSource = transactionsDataSource;

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;

            selectedUser = null;
            button1.Enabled = false;
            button3.Enabled = false;

            dataGridView1.ClearSelection();
        }

        User selectedUser;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedUser = (User)dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Rows[e.RowIndex].Cells.Count - 1].Value;


            button1.Enabled = true;
            button3.Enabled = true;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if(selectedUser == null || selectedUser._id == Form1.LOCAL_USER._id)
            {
                MessageBox.Show("Kendi kullanıcı hesabınızı silemezsiniz!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await AutomationManager.database.GetCollection<User>("kullanicilar").DeleteOneAsync(Builders<User>.Filter.Eq("_id", selectedUser._id));

                refreshUsersList();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new KullaniciOlustur(null).ShowDialog();

            refreshUsersList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new KullaniciOlustur(selectedUser).ShowDialog();

            refreshUsersList();
        }
    }
}
