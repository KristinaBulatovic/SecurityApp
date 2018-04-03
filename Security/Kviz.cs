using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;

namespace Security
{
    public partial class Kviz : Form
    {
        Igre igre;
        SQLite sqlite;
        Igrice igrice;
        int id_pitanja;
        int id_odgovora;
        int scoreTrue = 0;
        int scoreFalse = 0;
        public Kviz(Igre i)
        {
            InitializeComponent();
            sqlite = new SQLite();
            igrice = new Igrice();
            igre = i;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //igre.Close();
            Close();

        }

        private void Kviz_Load(object sender, EventArgs e)
        {
            id_pitanja = igrice.random_pitanje("generisi");
            label7.Text = sqlite.pitanje(id_pitanja);
            button1.Text = sqlite.odgovori(id_pitanja, 2);
            button2.Text = sqlite.odgovori(id_pitanja, 3);
            button3.Text = sqlite.odgovori(id_pitanja, 4);
            button4.Text = sqlite.odgovori(id_pitanja, 5);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == sqlite.tacan_odgovor(id_pitanja))
            {
                button1.BackColor = Color.Lime;
                await Task.Delay(1000);
                scoreTrue += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
            else
            {
                button1.BackColor = Color.Red;
                await Task.Delay(1000);
                scoreFalse += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();

            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == sqlite.tacan_odgovor(id_pitanja))
            {
                button2.BackColor = Color.Lime;
                await Task.Delay(1000);
                scoreTrue += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
            else
            {
                button2.BackColor = Color.Red;
                await Task.Delay(1000);
                scoreFalse += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == sqlite.tacan_odgovor(id_pitanja))
            {
                button3.BackColor = Color.Lime;
                await Task.Delay(1000);
                scoreTrue += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
            else
            {
                button3.BackColor = Color.Red;
                await Task.Delay(1000);
                scoreFalse += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == sqlite.tacan_odgovor(id_pitanja))
            {
                button4.BackColor = Color.Lime;
                await Task.Delay(1000);
                scoreTrue += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + " ; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
            else
            {
                button4.BackColor = Color.Red;
                await Task.Delay(1000);
                scoreFalse += 1;
                label2.Text = (scoreTrue + scoreFalse).ToString();
                if (scoreTrue + scoreFalse == 10)
                {
                    MessageBox.Show("Pogodili ste: " + scoreTrue + "; Promasili ste: " + scoreFalse, "Score");
                    Close();
                }
                zamena();
            }
        }

        public void zamena()
        {
            id_odgovora = igrice.random_odgovor("isprazni");
            id_pitanja = igrice.random_pitanje("nastavi");
            label7.Text = sqlite.pitanje(id_pitanja);
            button1.Text = sqlite.odgovori(id_pitanja, id_odgovora);
            button2.Text = sqlite.odgovori(id_pitanja, igrice.random_odgovor(""));
            button3.Text = sqlite.odgovori(id_pitanja, igrice.random_odgovor(""));
            button4.Text = sqlite.odgovori(id_pitanja, igrice.random_odgovor(""));
            button1.BackColor = Color.FromArgb(50, 50, 50);
            button2.BackColor = Color.FromArgb(50, 50, 50);
            button3.BackColor = Color.FromArgb(50, 50, 50);
            button4.BackColor = Color.FromArgb(50, 50, 50);
        }
    }
}
