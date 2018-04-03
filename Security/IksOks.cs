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
    public partial class IksOks : Form
    {
        SQLite sqlite;
        int figura = 0;

        PictureBox[] polje = new PictureBox[9];
        int[,] iksoks =
        {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0},
        };
        public IksOks()
        {
            InitializeComponent();
            sqlite = new SQLite();

            polje[0] = pictureBox2;
            polje[1] = pictureBox3;
            polje[2] = pictureBox4;
            polje[3] = pictureBox5;
            polje[4] = pictureBox6;
            polje[5] = pictureBox7;
            polje[6] = pictureBox8;
            polje[7] = pictureBox9;
            polje[8] = pictureBox10;
        }

        private void pobeda()
        {
            int brojac_vertikalniX = 0;
            int brojac_vertikalniO = 0;
            int brojac_horizontalniX = 0;
            int brojac_horizontalniO = 0;
            int brojac_dijagonalniX = 0;
            int brojac_dijagonalniO = 0;
            int brojac_dijagonalni2X = 0;
            int brojac_dijagonalni2O = 0;
            string pobedio;

            if (figura == 1)
            {
                pobedio = "X";
            }
            else pobedio = "O";

            for (int red = 0; red < 3; red++)
            {
                for (int kol = 0; kol < 3; kol++)
                {
                    if(iksoks[red,kol] == 1)
                    {
                        brojac_horizontalniX++;
                    }
                    else if (iksoks[red, kol] == 2)
                    {
                        brojac_horizontalniO++;
                    }

                    if (iksoks[kol, red] == 1)
                    {
                        brojac_vertikalniX++;
                    }
                    else if (iksoks[kol, red] == 2)
                    {
                        brojac_vertikalniO++;
                    }
                }
                if (iksoks[red, red] == 1)
                {
                    brojac_dijagonalniX++;
                }
                else if (iksoks[red, red] == 2)
                {
                    brojac_dijagonalniO++;
                }
                if (iksoks[2 - red, red] == 1)
                {
                    brojac_dijagonalni2X++;
                }
                else if (iksoks[2 - red, red] == 2)
                {
                    brojac_dijagonalni2O++;
                }
                if (brojac_horizontalniX == 3)
                {
                    MessageBox.Show("Pobedio je " + pobedio);
                    Close();
                }
                else if(brojac_horizontalniO == 3)
                {
                    MessageBox.Show("Pobedio je " + pobedio);
                    Close();
                }
                if (brojac_vertikalniX == 3)
                {
                    MessageBox.Show("Pobedio je " + pobedio);
                    Close();
                }
                else if (brojac_vertikalniO == 3)
                {
                    MessageBox.Show("Pobedio je " + pobedio);
                    Close();
                }
                brojac_horizontalniX = 0;
                brojac_horizontalniO = 0;
                brojac_vertikalniX = 0;
                brojac_vertikalniO = 0;
            }
            if (brojac_dijagonalniX == 3)
            {
                MessageBox.Show("Pobedio je " + pobedio);
                Close();
            }
            else if (brojac_dijagonalniO == 3)
            {
                MessageBox.Show("Pobedio je " + pobedio);
                Close();
            }

            if (brojac_dijagonalni2X == 3)
            {
                MessageBox.Show("Pobedio je " + pobedio);
                Close();
            }
            else if (brojac_dijagonalni2O == 3)
            {
                MessageBox.Show("Pobedio je " + pobedio);
                Close();
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void igraj(int i, int pozicija_x, int pozicija_y)
        {
            if (iksoks[pozicija_x, pozicija_y] == 0)
            {
                figura++;
                if (figura == 1)
                {
                    polje[i].ImageLocation = sqlite.iks_oks(figura);
                    iksoks[pozicija_x, pozicija_y] = 1;
                }
                else
                {
                    polje[i].ImageLocation = sqlite.iks_oks(figura);
                    figura = 0;
                    iksoks[pozicija_x, pozicija_y] = 2;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            igraj(0,0,0);
            pobeda();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            igraj(1,0,1);
            pobeda();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            igraj(2,0,2);
            pobeda();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            igraj(3,1,0);
            pobeda();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            igraj(4,1,1);
            pobeda();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            igraj(5,1,2);
            pobeda();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            igraj(6,2,0);
            pobeda();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            igraj(7,2,1);
            pobeda();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            igraj(8,2,2);
            pobeda();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = "";
            pictureBox3.ImageLocation = "";
            pictureBox4.ImageLocation = "";
            pictureBox5.ImageLocation = "";
            pictureBox6.ImageLocation = "";
            pictureBox7.ImageLocation = "";
            pictureBox8.ImageLocation = "";
            pictureBox9.ImageLocation = "";
            pictureBox10.ImageLocation = "";
            figura = 0;
            iksoks[0, 0] = 0;
            iksoks[0, 1] = 0;
            iksoks[0, 2] = 0;
            iksoks[1, 0] = 0;
            iksoks[1, 1] = 0;
            iksoks[1, 2] = 0;
            iksoks[2, 0] = 0;
            iksoks[2, 1] = 0;
            iksoks[2, 2] = 0;
        }
    }
}
