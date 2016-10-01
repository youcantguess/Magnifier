using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magnifier
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        int zoom = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width / zoom, pictureBox1.Height / zoom, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(MousePosition.X - pictureBox1.Width / (zoom * 2), 
                MousePosition.Y - pictureBox1.Height / (zoom * 2),
                0, 0, pictureBox1.Size, CopyPixelOperation.SourceCopy);
            pictureBox1.Image = bitmap;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            tbZoom.Text = (++zoom).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if(zoom > 1)
            {
                tbZoom.Text = (--zoom).ToString();
            } 
        }
    }
}
