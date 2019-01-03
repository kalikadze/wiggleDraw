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
using System.Threading;

namespace wiggleDraw
{
    public partial class mainForm : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        // drawing
        Bitmap drawing;

        public mainForm()
        {
            InitializeComponent();
            // thumbnail related
            thumbnail = new PictureBox();
            thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_original.Controls.Add(thumbnail);
            thumbnail.Visible = false;
            // background worker
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_doPaint);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
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

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //debugBox.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (drawing != null)
            {
                Graphics gr_pb_draw;
                gr_pb_draw = pb_draw.CreateGraphics();
                gr_pb_draw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                pb_draw.Image = drawing;

            }
        }

        private void bw_doPaint(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;                
            }

            if (pb_original.Image != null )
            {
                //init 
                long[,] cmat, amat;
                data2pass received_data = (data2pass)e.Argument;
                
                int xseg = received_data.get_xseg();
                int yseg = received_data.get_yseg();
                int ampl = received_data.get_ampl();
                int freq = received_data.get_freq();
                PaintEventArgs pearg = received_data.get_pe_arg();
                
                Analyzer analyzer = new Analyzer(pb_original, xseg, yseg);
                analyzer.analyze();
                Drawer drawer = new Drawer(pb_draw);

                cmat = analyzer.getColorMatrix();
                amat = analyzer.getAlphaMatrix();

                for (int yn = 0; yn < yseg - 1; yn++)
                    for (int xn = 0; xn < xseg - 1; xn++)
                    {
                        drawing = drawer.generate(pearg, pb_draw, xseg, yseg, ampl * Math.Abs(cmat[xn, yn] / 10000000), freq * Math.Abs(cmat[xn, yn] / 1000000), xn, yn);
                        worker.ReportProgress((xn * yn) / ((xseg - 1) * (yseg - 1)));
                    }
            }
        }

        private void pb_draw_Paint(object sender, PaintEventArgs e)
        {
            // prepare data to pass
            data2pass d2p = new data2pass(trackBarDetails.Value, trackBarLinesCount.Value, trackBarAmpl.Value, trackBarFreq.Value, e);

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync(d2p);
            }
        }
    }
}
