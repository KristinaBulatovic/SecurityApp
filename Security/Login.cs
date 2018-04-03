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
    public partial class Login : Form
    {
        SQLite sql;
        ChangeYourPassword cyp;
        public string a { get; set; }

        public Login()
        {
            InitializeComponent();
            sql = new SQLite();
            cyp = new ChangeYourPassword();
            a = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox2.UseSystemPasswordChar = false;
            else textBox2.UseSystemPasswordChar = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            a = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool t = sql.Read_SQLite(textBox1.Text, textBox2.Text, "login");
            string username = sql.Username_SQLite(textBox1.Text);
            if (t == true)
            {
                a = "Uspešno ste se ulogovali!!! ~ " + username + " ~";
                textBox1.Text = "";
                textBox2.Text = "";
                sql.Close_SQLite();
                Close();
            }
            else MessageBox.Show("Uneli se pogrešnu lozinku!!!", "Greška!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            sql.Close_SQLite();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            cyp.ShowDialog();
        }
    }
}
