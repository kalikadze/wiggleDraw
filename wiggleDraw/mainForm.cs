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

        private void trackBarFreq_Scroll(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }
        private void trackBarAmpl_Scroll(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }
        private void trackBarLines_Scroll(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }

        private void trackBarDetails_Scroll(object sender, EventArgs e)
        {
            pb_draw.Refresh();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openPictureDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pb_original.Image = Image.FromFile(openPictureDialog.FileName);

                //set max values for trackbars
                trackBarDetails.Maximum = pb_original.Image.Width - 5;
                trackBarLinesCount.Maximum = pb_original.Image.Height - 5;
            }
        }

        private void pb_draw_Paint(object sender, PaintEventArgs e)
        {
            if (pb_original.Image != null)
            {
                long[,] cmat, amat;

                Analyzer analyzer = new Analyzer(pb_original, trackBarLinesCount.Value, trackBarDetails.Value);
                analyzer.analyze();
                Drawer drawer = new Drawer(pb_draw);

                cmat = analyzer.getColorMatrix();
                amat = analyzer.getAlphaMatrix();

                drawer.generate(e, pb_draw, trackBarDetails.Value, trackBarLinesCount.Value, trackBarAmpl.Value, trackBarFreq.Value);
            }
        }
    }
}
