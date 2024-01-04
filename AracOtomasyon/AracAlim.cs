using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace AracOtomasyon
{
    public partial class AracAlim : Form
    {
        public AracAlim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                string path = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(path);

              
            }
        }

        bool selfSet = false;
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(selfSet)
            {
                selfSet = false;
                return;
            }
            if (radioButton2.Checked)
            {
                selfSet = true;
                radioButton2.Checked = false;
                new Saticilar((seller) =>
                {
                    selfSet = true;
                    radioButton2.Checked = true;
                    selectedId = seller._id;

                    textBox1.Text = seller.vkn;
                    textBox2.Text = seller.ad;
                    textBox3.Text = seller.soyad;
                    textBox4.Text = seller.telefon;
                    textBox5.Text = seller.adres;


                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;

                   
                }).ShowDialog();

                if(!radioButton2.Checked)
                {
                    radioButton1.Checked = true;
                }
                
            } else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
        }



        ObjectId selectedId;

        private async void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AracAlim_Load(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            ObjectId sellerId;

            if (radioButton1.Checked)
            {
                sellerId = ObjectId.GenerateNewId();
                await AutomationManager.database.GetCollection<Seller>("sellers").InsertOneAsync(new Seller()
                {
                    _id = sellerId,
                    vkn = textBox1.Text,
                    ad = textBox2.Text,
                    soyad = textBox3.Text,
                    telefon = textBox4.Text,
                    adres = textBox5.Text,

                });
            }
            else
            {
                sellerId = selectedId;
            }


            byte[] fotograf = null;

            if (pictureBox1.Image != null)
            {
                fotograf = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            }

            await AutomationManager.database.GetCollection<Arac>("araclar").InsertOneAsync(new Arac()
            {
                _id = ObjectId.GenerateNewId(),
                alisTutari = float.Parse(textBox16.Text),
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
                sellerId = sellerId,
            });


            MessageBox.Show("Araç girişi başarılı");

            this.Close();
        }
    }
}
