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
        bool needpaint = false;
        bool needsave = false;

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
            if (checkBoxRefresh.Checked)
            {
                needpaint = true;
                pb_draw.Refresh();
            }
        }

        private void trackBarAmpl_Scroll(object sender, EventArgs e)
        {
            if (checkBoxRefresh.Checked)
            {
                needpaint = true;
                pb_draw.Refresh();
            }
        }

        private void trackBarLines_Scroll(object sender, EventArgs e)
        {
            if (checkBoxRefresh.Checked)
            {
                trackBarDetails.Value = (int)((pb_original.Width * trackBarLinesCount.Value) / pb_original.Height);
                needpaint = true;
                pb_draw.Refresh();
            }
        }

        private void trackBarDetails_Scroll(object sender, EventArgs e)
        {
            if (checkBoxRefresh.Checked)
            {
                needpaint = true;
                pb_draw.Refresh();
            }
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

                // debug
                pb_draw.Height = pb_original.Image.Height;
                pb_draw.Width = pb_original.Image.Width;
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int prgrs = e.ProgressPercentage;
            progressBar.Value = prgrs;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (drawing != null)
            {
                pb_draw.Image = drawing;
                drawing = null;
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
                float progress = 0F;
                int counter = 0;
                
                int xseg = received_data.get_xseg();
                int yseg = received_data.get_yseg();
                int ampl = received_data.get_ampl();
                int freq = received_data.get_freq();
                bool saveflag = received_data.gets_saveflag();
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
                        counter++;
                        progress = (float)(counter * 100) / (float)((xseg - 1) * (yseg - 1));

                        worker.ReportProgress((int)progress);
                    }

                // this routine run only when user want it
                if (saveflag)
                {
                    string s = drawer.svg_graphics.WriteSVGString();
                    string tempFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "exported_pic" + DateTime.Now.ToString().Replace(" ", "").Replace(":","_").Replace(".", "-") + ".svg");
                    StreamWriter tw = new StreamWriter(tempFile, false);
                    tw.Write(s);
                    tw.Close();
                }
            }
        }

        private void pb_draw_Paint(object sender, PaintEventArgs e)
        {
            // prepare data to pass
            data2pass d2p = new data2pass(trackBarDetails.Value, trackBarLinesCount.Value, trackBarAmpl.Value, trackBarFreq.Value, e, needsave);

            if (bw.IsBusy != true && needpaint)
            {
                bw.RunWorkerAsync(d2p);
            }
            needpaint = false;
            needsave = false;
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            needsave = true;
            needpaint = true;
            pb_draw.Invalidate();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            needpaint = true;
            pb_draw.Refresh();
        }
    }
}
