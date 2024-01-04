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
    public partial class AracSatisDetay : Form
    {
        public AracSatisDetay(Arac arac)
        {
            InitializeComponent();

            this.arac = arac;
        }

        Arac arac;
        private void button1_Click(object sender, EventArgs e)
        {
            new AracKayitFormu(arac).ShowDialog();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Aracı depoya göndermek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await AutomationManager.database.GetCollection<Arac>("araclar").UpdateOneAsync(new BsonDocument("_id", arac._id), Builders<Arac>.Update.Set(r => r.satisTutari, 0));

                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AracSatisFormu(arac).ShowDialog();
            this.Close();
        }
    }
}
