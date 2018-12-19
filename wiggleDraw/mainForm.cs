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

            //this.pb_draw.Paint += new System.Windows.Forms.PaintEventHandler((s, e) => this.pb_draw_Paint(s, e, trackBarAmpl.Value, trackBarFreq.Value));
            thumbnail = new PictureBox();
            thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_original.Controls.Add(thumbnail);
            thumbnail.Visible = false;
        }

        private void process_button_Click(object sender, EventArgs e)
        {
            long[,] cmat, amat;

            Analyzer analyzer = new Analyzer(pb_original, 20, 10);
            analyzer.analyze(pb_original);
            Drawer drawer = new Drawer(pb_original);

            cmat = analyzer.getColorMatrix();
            amat = analyzer.getAlphaMatrix();

            drawer.generate(pb_draw, 0, 20, 10, 100, 100);


            /*
            debugBox.AppendText("Min Pixel: " + analyzer.getMinPixel());
            debugBox.AppendText(Environment.NewLine);
            debugBox.AppendText("Max Pixel: " + analyzer.getMaxPixel());
            debugBox.AppendText(Environment.NewLine);
            */
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

        private void pb_draw_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
