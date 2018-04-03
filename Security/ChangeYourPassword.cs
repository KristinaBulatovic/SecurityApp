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
    public partial class ChangeYourPassword : Form
    {
        SQLite sql;
        public ChangeYourPassword()
        {
            InitializeComponent();
            sql = new SQLite();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool t = sql.Read_SQLite(textBox1.Text, textBox2.Text, "login");
            if (t == true)
            {
                if (textBox3.Text == textBox4.Text)
                {
                    string username = sql.Username_SQLite(textBox1.Text);
                    string delete = sql.Delete_SQLite(username, "login");
                    sql.Close_SQLite();
                    string add = sql.Add_SQLite(username, textBox3.Text);
                    sql.Close_SQLite();
                    if (add == "Uspešno ste napravili nalog...")
                    {
                        MessageBox.Show("Uspešno ste promenili lozinku!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Greška pri menjanju lozinke!", "Greška!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    Close();

                }
                else MessageBox.Show("Greška pri potvrdi lozinke!", "Greška!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Uneli se pogrešnu lozinku!!!", "Greška!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sql.Close_SQLite();
        }
    }
}
