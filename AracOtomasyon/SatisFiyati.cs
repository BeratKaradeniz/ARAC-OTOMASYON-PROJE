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

namespace AracOtomasyon
{
    public partial class SatisFiyati : Form
    {
        Arac arac;
        public SatisFiyati(Arac arac)
        {
            InitializeComponent();

            this.arac = arac;
        }

        private void SatisFiyati_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await AutomationManager.database.GetCollection<Arac>("araclar").UpdateOneAsync(new BsonDocument("_id", arac._id), Builders<Arac>.Update.Set(r => r.satisTutari, float.Parse(textBox16.Text)));

            MessageBox.Show("Satış tutarı başarıyla güncellendi!");

            this.Close();
        }
    }
}
