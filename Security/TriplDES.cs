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
    public partial class TriplDES : Form
    {
        Cryptography crypt;
        public TriplDES()
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
            textBox2.Text = crypt.Encrypt_TriplDES(textBox4.Text, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = crypt.Decrypt_TriplDES(textBox4.Text, textBox2.Text);
        }
    }
}
