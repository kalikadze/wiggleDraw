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
    public partial class mainForm : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2F);
        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            g = pb_draw.CreateGraphics();
            for (int i = 0; i < 1000; i++)
            {
                pen1.Color.A = 10;
                g.DrawLine(pen1, rnd.Next(1, 650), rnd.Next(1, 650), rnd.Next(1, 650), rnd.Next(1, 650));
            }
        }
    }
}