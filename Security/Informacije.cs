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
    public partial class Informacije : Form
    {
        SQLite sqlite;
        public Informacije()
        {
            InitializeComponent();
            sqlite = new SQLite();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            textBox1.Text = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Phishing")
            {
                textBox1.Text = sqlite.napad_odbrana("1", 1);
            }
            else if (comboBox2.Text == "DOS (denial of service)")
            {
                textBox1.Text = sqlite.napad_odbrana("2", 1);
            }
            else if (comboBox2.Text == "Bruteforce")
            {
                textBox1.Text = sqlite.napad_odbrana("3", 1);
            }
            else if (comboBox2.Text == "XSS (cros site scripting)")
            {
                textBox1.Text = sqlite.napad_odbrana("4", 1);
            }
            else if (comboBox2.Text == "SQL-injection")
            {
                textBox1.Text = sqlite.napad_odbrana("5", 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Phishing")
            {
                textBox1.Text = sqlite.napad_odbrana("1", 2);
            }
            else if (comboBox2.Text == "DOS (denial of service)")
            {
                textBox1.Text = sqlite.napad_odbrana("2", 2);
            }
            else if (comboBox2.Text == "Bruteforce")
            {
                textBox1.Text = sqlite.napad_odbrana("3", 2);
            }
            else if (comboBox2.Text == "XSS (cros site scripting)")
            {
                textBox1.Text = sqlite.napad_odbrana("4", 2);
            }
            else if (comboBox2.Text == "SQL-injection")
            {
                textBox1.Text = sqlite.napad_odbrana("5", 2);
            }
        }
    }
}
