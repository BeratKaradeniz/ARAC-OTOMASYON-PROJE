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
    public partial class AracBilgileri : Form
    {
        public AracBilgileri(Arac arac, Seller seller)
        {
            InitializeComponent();

            renkLabel.Text = arac.renk;
            alisTutariLabel.Text = arac.alisTutari.ToString("N2") + "₺";
            yilLabel.Text = arac.yil;
            markaLabel.Text = arac.marka;
            modelLabel.Text = arac.model;
            durumLabel.Text = arac.ikinciEl ? "Ikinci El" : "Sıfır";
            bilgiLabel.Text = arac.bilgi;

            vknLabel.Text = seller.vkn;
            adLabel.Text = seller.ad;
            soyadLabel.Text = seller.soyad;
            telefonLabel.Text = seller.telefon;
            adresLabel.Text = seller.adres;

            if(arac.fotograf != null)
            {
                pictureBox1.Image = (Image)new ImageConverter().ConvertFrom(arac.fotograf);
            }
        }

        private void AracBilgileri_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
