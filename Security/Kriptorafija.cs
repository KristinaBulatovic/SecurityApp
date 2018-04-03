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
    public partial class Kriptorafija : Form
    {
        TriplDES triplDes;
        AES aes;
        RSA rsa;
        DES des;
        public Kriptorafija()
        {
            InitializeComponent();
            triplDes = new TriplDES();
            aes = new AES();
            rsa = new RSA();
            des = new DES();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            triplDes.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aes.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rsa.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            des.ShowDialog();
        }
    }
}
