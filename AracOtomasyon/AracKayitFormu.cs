using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
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
    public partial class AracKayitFormu : Form
    {
        ObjectId carId;

        Arac arac;
        public AracKayitFormu(Arac arac)
        {
            InitializeComponent();

            if(arac  == null)
            {
                carId = ObjectId.GenerateNewId();
            } else
            {
                this.arac = arac;
                carId = this.arac._id;
                textBox10.Text = arac.marka;
                textBox9.Text = arac.model;
                textBox8.Text = arac.yil;
                textBox7.Text = arac.plaka;
                textBox11.Text = arac.renk;
                comboBox1.SelectedIndex = arac.ikinciEl ? 1 : 0;
                textBox6.Text = arac.bilgi;

                if (arac.fotograf != null)
                    pictureBox1.Image = (Image)new ImageConverter().ConvertFrom(arac.fotograf);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string path = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(path);


            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AracKayitFormu_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] fotograf = null;

            if (pictureBox1.Image != null)
            {
                fotograf = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            }


            AutomationManager.database.GetCollection<Arac>("araclar").ReplaceOneAsync(new BsonDocument("_id", carId), new Arac()
            {
                _id = carId,
                alisTutari = (arac != null) ? arac.alisTutari : 0,
                sellerId = (arac != null) ? arac.sellerId : new ObjectId(),
                bilgi = textBox6.Text,
                fotograf = fotograf,
                ikinciEl = comboBox1.SelectedIndex == 1,
                marka = textBox10.Text,
                model = textBox9.Text,
                yil = textBox8.Text,
                plaka = textBox7.Text,
                renk = textBox11.Text,
                satildi = false,
                satisTutari = 0,
            }, new ReplaceOptions() { IsUpsert = true });


            MessageBox.Show("Araç kaydı başarılı!");

            this.Close();
        }
    }
}
