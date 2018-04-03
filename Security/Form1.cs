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
    public partial class Form1 : Form
    {
        Login login;
        SignUp signUp;
        Kriptorafija krip;
        Steganografija steganografija;
        Igre igre;
        Informacije info;
        public Form1()
        {
            InitializeComponent();
            login = new Login();
            signUp = new SignUp();
            krip = new Kriptorafija();
            steganografija = new Steganografija();
            igre = new Igre();
            info = new Informacije();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "Prijavite se")
            {
                login.ShowDialog();
                if (login.a != "")
                {
                    label7.Text = login.a;
                    label5.Text = "Odjavite se";
                    label6.Enabled = false;
                }
                else label7.Text = " ";
            }
            else
            {
                label7.Text = " ";
                label5.Text = "Prijavite se";
                label6.Enabled = true;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            signUp.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label7.Text != " ")
            {
                krip.ShowDialog();
            }
            else MessageBox.Show("Morate da se prijavite kako bi koristili Kriptografiju!", "Greška!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label7.Text != " ")
            {
                steganografija.ShowDialog();
            }
            else MessageBox.Show("Morate da se prijavite kako bi koristili Steganografiju!", "Greška!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            igre.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            info.ShowDialog();
        }
    }
}
