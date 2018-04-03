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
    public partial class Memorija : Form
    {
        SQLite sqlite;
        Igrice igrice;
        string url;
        int brojac = 0;
        int[] slicice = new int[24];
        int[] url_slicice = new int[24];
        PictureBox[] slike = new PictureBox[24];
        public Memorija()
        {
            InitializeComponent();
            sqlite = new SQLite();
            igrice = new Igrice();
            for (int i = 0; i < 24; i++) slicice[i] = 0;
            url_slicice = igrice.random_mem();

            slike[0] = pictureBox1;
            slike[1] = pictureBox2;
            slike[2] = pictureBox3;
            slike[3] = pictureBox4;
            slike[4] = pictureBox5;
            slike[5] = pictureBox6;
            slike[6] = pictureBox7;
            slike[7] = pictureBox8;
            slike[8] = pictureBox9;
            slike[9] = pictureBox10;
            slike[10] = pictureBox11;
            slike[11] = pictureBox12;
            slike[12] = pictureBox13;
            slike[13] = pictureBox14;
            slike[14] = pictureBox15;
            slike[15] = pictureBox16;
            slike[16] = pictureBox17;
            slike[17] = pictureBox18;
            slike[18] = pictureBox19;
            slike[19] = pictureBox20;
            slike[20] = pictureBox21;
            slike[21] = pictureBox22;
            slike[22] = pictureBox23;
            slike[23] = pictureBox24;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void okreni_sl(int broj)
        {
            url = sqlite.url(url_slicice[broj].ToString());
            slike[broj].ImageLocation = url;
            if (slicice[broj] == 0)
            {
                slicice[broj] = 1;
                brojac++;
                if (brojac == 2)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (slicice[i] == 1)
                        {
                            string url1 = sqlite.url(url_slicice[i].ToString());
                            if (url == url1)
                            {
                                slicice[i] = 2;
                                slicice[broj] = 2;
                                int a = 0;
                                for (int j = 0; j < 24; j++)
                                {
                                    if(slicice[j] == 2)
                                    {
                                        a++;
                                    }
                                }
                                if(a == 24)
                                {
                                    MessageBox.Show("Pobedili ste!!");
                                    Close();
                                }
                                    brojac = 0;
                            }
                            else
                            {
                                await Task.Delay(1000);
                                slicice[i] = 0;
                                slicice[broj] = 0;
                                slike[broj].ImageLocation = "";
                                slike[i].ImageLocation = "";
                                brojac = 0;
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            okreni_sl(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            okreni_sl(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            okreni_sl(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            okreni_sl(3);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            okreni_sl(7);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            okreni_sl(6);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            okreni_sl(5);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            okreni_sl(4);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            okreni_sl(15);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            okreni_sl(14);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            okreni_sl(13);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            okreni_sl(12);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            okreni_sl(11);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            okreni_sl(10);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            okreni_sl(9);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            okreni_sl(8);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            okreni_sl(23);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            okreni_sl(22);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            okreni_sl(21);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            okreni_sl(20);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            okreni_sl(19);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            okreni_sl(18);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            okreni_sl(17);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            okreni_sl(16);
        }
    }
}
