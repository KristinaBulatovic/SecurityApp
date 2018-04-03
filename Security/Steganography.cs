using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Security
{
    class Steganography
    {
        public string OpenPicture()
        {
            string url = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG|*.jpg|PNG|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                url = ofd.FileName;
                return url;
            }
            return url;
        }
        public void SavePicture(Bitmap img)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG|*.jpg|PNG|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string url = sfd.FileName;
                img.Save(url);
            }

        }

    }
}
