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
    public partial class Igre : Form
    {
        Kviz kviz;
        Memorija memorija;
        IksOks iks_oks;
        public Igre()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kviz = new Kviz(this);
            kviz.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memorija = new Memorija();
            memorija.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iks_oks = new IksOks();
            iks_oks.ShowDialog();
        }
    }
}
