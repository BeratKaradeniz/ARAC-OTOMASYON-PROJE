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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            button9.Visible = Form1.LOCAL_USER.role == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AracAlim().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (intent) return;

            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AracKayitFormu(null).ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Galeri().ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new AracDepo().ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new KrediHesaplayicisi().ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            new AracAlimListesi().ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            new Saticilar(null).ShowDialog();
        }

        bool intent = false;
        private void button5_Click_1(object sender, EventArgs e)
        {
            intent = true;
            this.Close();

            Form1.form1.Show();
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Yonetici().ShowDialog();
        }
    }
}
