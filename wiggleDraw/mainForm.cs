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
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;

namespace wiggleDraw
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            this.pb_draw.Paint += new System.Windows.Forms.PaintEventHandler((s, e) => this.pb_draw_Paint(s, e, trackBarAmpl.Value, trackBarFreq.Value));
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
            /*
            Analyzer analyzer = new Analyzer();
            analyzer.readPic(pb_original);
            debugBox.AppendText("Min Pixel: " + analyzer.getMinPixel());
            debugBox.AppendText(Environment.NewLine);
            debugBox.AppendText("Max Pixel: " + analyzer.getMaxPixel());
            debugBox.AppendText(Environment.NewLine);
            */
        }


        private void button1_Click(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }

        /* debug */
        private void pb_draw_Paint(object sender, PaintEventArgs e, float ampl, float freq)
        {
            Stopwatch sw = new Stopwatch();

            Graphics gr;
            Graphics gr_pb_draw;
            Bitmap drawing = null;

            drawing = new Bitmap(pb_draw.Width, pb_draw.Height);

            Pen pen1 = new System.Drawing.Pen(Color.Blue, 1F);
            Random rnd = new Random();
            gr_pb_draw = pb_draw.CreateGraphics();
            gr = Graphics.FromImage(drawing);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            float y = 0, y2 = 0, x2 = 0;
            float offset = 300;

            sw.Start();
            for (float x = 0; x < pb_draw.Width; x +=1F)
            {
                //draw a sine
                //pen1.Color = Color.FromArgb(rnd.Next(1, 255), rnd.Next(1, 255), rnd.Next(1, 255));
                y = (float)Math.Sin(x * freq/1000)*ampl;

                gr.DrawLine(pen1, x, y + offset, x2, y2 + offset);
                x2 = x;
                y2 = y;

            }
            e.Graphics.DrawImageUnscaled(drawing, 0, 0);

            sw.Stop();
            debugBox.AppendText("Elapsed time (ms): " + sw.ElapsedMilliseconds);
            debugBox.AppendText(Environment.NewLine);
            /* debug */
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openPictureDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pb_original.Image = Image.FromFile(openPictureDialog.FileName);
            }
        }
    }
}
