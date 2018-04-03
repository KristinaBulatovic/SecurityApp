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
    public partial class Steganografija : Form
    {
        string url = "";
        Steganography steg;
        Cryptography crypt;
        public Steganografija()
        {
            InitializeComponent();
            steg = new Steganography();
            crypt = new Cryptography();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox2.ImageLocation = "";
            url = "";
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            url = steg.OpenPicture();
            if (url != "")
            {
                pictureBox2.ImageLocation = url;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (url != "")
            {
                //string key = crypt.Key(textBox1.Text);
                Bitmap img = new Bitmap(pictureBox2.Image);


                string text = crypt.Encrypt_TriplDES(textBox1.Text, textBox2.Text);
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);
                        //RGB
                        if (i < 1 && j < text.Length)
                        {
                            //Console.WriteLine("R[" + i + "][" + j + "] : " + pixel.R);
                            //Console.WriteLine("G[" + i + "][" + j + "] : " + pixel.G);
                            //Console.WriteLine("B[" + i + "][" + j + "] : " + pixel.B);
                            char letter = Convert.ToChar(text.Substring(j, 1));
                            int value = Convert.ToInt32(letter);
                            //Console.WriteLine("Letter: " + letter + "\n Value: " + value);
                            img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, value));
                        }
                        if (i == img.Width - 1 && j == img.Height - 1)
                        {
                            img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, text.Length));
                        }
                    }
                }
                steg.SavePicture(img);
            }
            else MessageBox.Show("Niste uneli sliku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (url != "")
            {
                Bitmap img = new Bitmap(pictureBox2.Image);
                Color lpixel = img.GetPixel(img.Width - 1, img.Height - 1);
                int messlen = lpixel.B;
                string message = "";

                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);
                        //RGB
                        if (i < 1 && j < messlen)
                        {
                            //Console.WriteLine("R[" + i + "][" + j + "] : " + pixel.R);
                            //Console.WriteLine("G[" + i + "][" + j + "] : " + pixel.G);
                            //Console.WriteLine("B[" + i + "][" + j + "] : " + pixel.B);
                            int value = pixel.B;
                            //Console.WriteLine("Value: " + value);
                            char c = Convert.ToChar(value);

                            //string letter = System.Text.Encoding.ASCII.GetString(new byte[] { Convert.ToByte(c) });
                            string letter = c.ToString();

                            message += letter;
                        }
                    }
                }
                //string key = spc.Key(textBox1.Text);
                string text = crypt.Decrypt_TriplDES(textBox1.Text, message);
                if (text != "")
                {
                    MessageBox.Show(text , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Unesite ispravan ključ!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Niste uneli sliku.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
