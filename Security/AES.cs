using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security
{
    public partial class AES : Form
    {
        Cryptography crypt;
        public AES()
        {
            InitializeComponent();
            crypt = new Cryptography();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = crypt.Key(textBox4.Text);
            textBox2.Text = crypt.Encrypt_AES(key, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string key = crypt.Key(textBox4.Text);
            textBox3.Text = crypt.Decrypt_AES(key, textBox2.Text);
        }
    }
}
