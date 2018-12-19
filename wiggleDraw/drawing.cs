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
using System.Threading;

namespace wiggleDraw
{
    class Drawer
    {
        private Graphics gr;
        private Graphics gr_pb_draw;
        private Bitmap drawing = null;
        private PictureBox pb;
        private Pen pen;

        public Drawer(PictureBox pb)
        {
            this.pb = pb;

            drawing = new Bitmap(pb.Width, pb.Height);
            pen = new System.Drawing.Pen(Color.Red, 1F);
            Random rnd = new Random();
            gr_pb_draw = pb.CreateGraphics();
            gr = Graphics.FromImage(drawing);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private int makeSine(int xorig, int yorig, int startY, int xseg, int yseg, long ampl, long freq)
        {
            float y = startY, y2 = startY, x2 = xorig;

            for (float x = xorig; x < pb.Image.Width/xseg; x += 1F)
            {
                y = (float)Math.Sin(x * freq / 1000) * ampl;

                gr.DrawLine(pen, x + xorig, y + yorig, x2 + xorig, y2 + yorig);
                x2 = x;
                y2 = y;

            }
            return (int)y2;
            //e.Graphics.DrawImageUnscaled(drawing, 0, 0);
        }

        public void generate(PictureBox draw,int startY, int xseg, int yseg, long ampl, long freq)
        {
            int yStartLocal = 0;
            int yStopLocal = 0;

            for (int x = 0; x < pb.Image.Width / xseg; x++)
                for (int y = 0; y < pb.Image.Height / yseg; y++)
                    for (int xx = 0; xx < xseg; xx++)
                        for (int yy = 0; yy < yseg; yy++)
                        {
                            if (((xx + xseg * x) < pb.Image.Width) && ((yy + yseg * y) < pb.Image.Height))
                            {
                                yStopLocal = makeSine(x, y, yStartLocal, xseg, yseg, ampl, freq);
                                yStartLocal = yStopLocal;
                            }
                        }
            draw.Image = drawing;
        }
    }
}