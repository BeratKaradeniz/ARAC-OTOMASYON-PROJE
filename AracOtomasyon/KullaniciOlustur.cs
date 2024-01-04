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
    public partial class KullaniciOlustur : Form
    {
        public KullaniciOlustur(User user)
        {
            InitializeComponent();

            if(user != null)
            {
                editingUser = user;

                textBox10.Text = user.name;
                textBox9.Text = user.email;
                comboBox1.SelectedIndex = user.role;
                textBox1.Enabled = false;
                textBox1.Text = "********";

            } else
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = true;
            }
        }


        User editingUser;

        private void KullaniciOlustur_Load(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            User user = new User();

            if(editingUser != null)
            {
                user.password = editingUser.password;
                user._id = editingUser._id;
            } else
            {
                user._id = ObjectId.GenerateNewId();
            }

            user.email = textBox9.Text;
            user.name = textBox10.Text;
            user.role = comboBox1.SelectedIndex;


            if(checkBox1.Checked)
            {
                user.password = SecurePasswordHasher.Hash(textBox1.Text);
            }

            button7.Enabled = false;
            await AutomationManager.database.GetCollection<User>("kullanicilar").ReplaceOneAsync(Builders<User>.Filter.Eq("_id", user._id), user, new ReplaceOptions() { IsUpsert = true });

            MessageBox.Show("Kaydetme başarılı!");

            this.Close();

                
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.Text = "";
                textBox1.Enabled = true;
            } else
            {
                textBox1.Text = "********";
                textBox1.Enabled = false;
            }
        }
    }
}
