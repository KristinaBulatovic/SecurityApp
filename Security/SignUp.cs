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
    public partial class SignUp : Form
    {
        SQLite sql;

        public SignUp()
        {
            InitializeComponent();
            sql = new SQLite();
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sql.Add_SQLite(textBox1.Text, textBox2.Text), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sql.Close_SQLite();
            textBox1.Text = "";
            textBox2.Text = "";
            Close();
        }
    }
}
