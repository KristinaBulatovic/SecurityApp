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
    public partial class DES : Form
    {
        Cryptography crypt;
        public DES()
        {
            InitializeComponent();
            crypt = new Cryptography();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = crypt.DES_Encrypt(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = crypt.DES_Decrypt(textBox2.Text);
        }
    }
}
