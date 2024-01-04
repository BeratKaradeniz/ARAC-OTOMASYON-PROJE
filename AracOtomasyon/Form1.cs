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
    public partial class Form1 : Form
    {
        public Form1()
        {
            

            InitializeComponent();
            
    
        }


        public static Form1 form1;

        private async void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (AutomationManager.Instance == null)
                new AutomationManager();

            form1 = this;
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            button3.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;



            User user = await AutomationManager.database.GetCollection<User>("kullanicilar").Find(Builders<User>.Filter.Eq(r => r.email, textBox1.Text)).FirstOrDefaultAsync<User>();

            if (user == null)
            {
                MessageBox.Show("Girmiş olduğunuz email adresiyle bir kullanıcı bulunmamakta!");

                textBox1.Text = "";
                textBox2.Text = "";
                button3.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                return;
            }


            if (!SecurePasswordHasher.Verify(textBox2.Text, user.password))
            {
                MessageBox.Show("Girmiş olduğunuz email adresi ve şifreyle uyuşan bir kullanıcı bulunmamakta!");
                textBox2.Text = "";
                button3.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                return;
            }

            LOCAL_USER = user;

            new MainMenu().Show();

            this.Hide();

            textBox1.Text = "";
            textBox2.Text = "";

            button3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        public static User LOCAL_USER;

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
