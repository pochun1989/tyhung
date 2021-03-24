using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TEST
{
    public partial class Barcode : Form
    {
        public string pallet = "";

        public Barcode()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Barcode";
            save.Filter = "(.jpg)|*.jpg";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
                pictureBox1.DrawToBitmap(bit, pictureBox1.ClientRectangle);
                bit.Save(save.FileName);
            }

        }

        private void Barcode_Load(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(850, 150);
            Graphics g = Graphics.FromImage(b);
            Font font = new Font("c39hrp24dltt", 72);
            g.DrawString(pallet, font, Brushes.Black, new PointF(0, 50));
            pictureBox1.BackgroundImage = b;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
