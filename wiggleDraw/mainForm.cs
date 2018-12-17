using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wiggleDraw
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            thumbnail = new PictureBox();
            thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_original.Controls.Add(thumbnail);
            thumbnail.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void process_button_Click(object sender, EventArgs e)
        {
            Analyzer analyzer = new Analyzer();
            analyzer.readPic(pb_original);
            debugBox.AppendText("Min Pixel: " + analyzer.getMinPixel());
            debugBox.AppendText(Environment.NewLine);
            debugBox.AppendText("Max Pixel: " + analyzer.getMaxPixel());
            debugBox.AppendText(Environment.NewLine);
        }


        /* debug */
        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics g;
            System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 1F);
            Random rnd = new Random();
            g = pb_draw.CreateGraphics();

            float y = 0, y2 = 0, x2 = 0;
            float sc = 20F;

            for (float x = 0; x < pb_draw.Width; x += 0.1F)
            {
                //draw a sine
                //pen1.Color = Color.FromArgb(rnd.Next(1, 255), rnd.Next(1, 255), rnd.Next(1, 255));
                y = (float)Math.Sin(x);

                g.DrawLine(pen1, x*sc/2, y*sc+100, x2*sc/2, y2*sc+100);
                x2 = x;
                y2 = y;

            }
            /* debug */
        }
    }
}
