﻿using System;
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
        private float lastx = 0;
        private float lasty = 0;

        public Drawer(PictureBox pb)
        {
            this.pb = pb;

            Random rnd = new Random();
            drawing = new Bitmap(pb.Width, pb.Height);
            Color pencolor = new Color();
            pencolor = Color.DarkBlue;
            pen = new System.Drawing.Pen(pencolor, 1F);
            gr_pb_draw = pb.CreateGraphics();
            gr = Graphics.FromImage(drawing);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private void makeSine(int xorig, int yorig, float startX, float startY, int xseg, int yseg, long ampl, long freq, bool nl = false)
        {
            float y = startY, y2 = startY, x2 = lastx+1F;

            for (float x = xorig; x < pb.Width/xseg + xorig; x += 20F)
            {
                if (nl)
                {
                    y = yorig;
                    y2 = y;
                    x2 = xorig;
                    nl = false;
                }
                else
                    y = (float)Math.Sin(x * freq / 1000) * ampl + yorig;

                gr.DrawLine(pen, x, y, x2, y2);

                x2 = x;
                y2 = y;
                lastx = x2;
                lasty = y2;
            }
        }

        public Bitmap generate(PaintEventArgs e, PictureBox draw,int xseg, int yseg, long ampl, long freq, int x, int y)
        {
            bool nl = false;

            if (((x * pb.Width / xseg) < pb.Width) && ((y * pb.Height / yseg) < pb.Height))
            {
                if (x == 0)
                    nl = true;
                else
                    nl = false;
                makeSine(x * pb.Width / xseg, y * pb.Height / yseg, lastx, lasty, xseg, yseg, ampl, freq, nl);
            }
            return drawing;
        }
    }
}