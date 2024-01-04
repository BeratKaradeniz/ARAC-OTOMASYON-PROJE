using MongoDB.Bson;
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

namespace AracOtomasyon
{
    public partial class AracSatisFormu : Form
    {
        Arac arac;
        public AracSatisFormu(Arac arac)
        {
            InitializeComponent();

            this.arac = arac;

            textBox10.Text = arac.marka;
            textBox9.Text = arac.model;
            textBox8.Text = arac.yil;
            textBox7.Text = arac.plaka;
            textBox11.Text = arac.renk;
            comboBox1.SelectedIndex = arac.ikinciEl ? 1 : 0;
            textBox6.Text = arac.bilgi;

            if(arac.fotograf != null)
                pictureBox1.Image = (Image)new ImageConverter().ConvertFrom(arac.fotograf);
        }

        private void AracSatisFormu_Load(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await AutomationManager.database.GetCollection<Satis>("satislar").InsertOneAsync(new Satis()
            {
                vkn = textBox1.Text,
                ad = textBox2.Text,
                soyad = textBox3.Text,
                telefon = textBox4.Text,
                adres = textBox5.Text,
                arac = arac
            });


            await AutomationManager.database.GetCollection<Arac>("araclar").DeleteOneAsync(new BsonDocument("_id", arac._id));



            MessageBox.Show("Satış başarılı!");

            this.Close();
        }
    }
}
