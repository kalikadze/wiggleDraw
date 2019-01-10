using System;

namespace wiggleDraw
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.pb_original = new System.Windows.Forms.PictureBox();
            this.label_pb = new System.Windows.Forms.Label();
            this.debugBox = new System.Windows.Forms.RichTextBox();
            this.pb_draw = new System.Windows.Forms.PictureBox();
            this.label_output = new System.Windows.Forms.Label();
            this.trackBarAmpl = new System.Windows.Forms.TrackBar();
            this.trackBarFreq = new System.Windows.Forms.TrackBar();
            this.labelFreq = new System.Windows.Forms.Label();
            this.labelAmplitude = new System.Windows.Forms.Label();
            this.trackBarLinesCount = new System.Windows.Forms.TrackBar();
            this.labelLinesCount = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.openPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.trackBarDetails = new System.Windows.Forms.TrackBar();
            this.labelDetail = new System.Windows.Forms.Label();
            this.savebutton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pb_original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_draw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLinesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_original
            // 
            this.pb_original.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_original.Location = new System.Drawing.Point(26, 34);
            this.pb_original.Name = "pb_original";
            this.pb_original.Size = new System.Drawing.Size(359, 340);
            this.pb_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_original.TabIndex = 0;
            this.pb_original.TabStop = false;
            // 
            // label_pb
            // 
            this.label_pb.AutoSize = true;
            this.label_pb.Location = new System.Drawing.Point(23, 18);
            this.label_pb.Name = "label_pb";
            this.label_pb.Size = new System.Drawing.Size(216, 13);
            this.label_pb.TabIndex = 1;
            this.label_pb.Text = "Drag && Drop here picture or use Open dialog";
            // 
            // debugBox
            // 
            this.debugBox.Location = new System.Drawing.Point(26, 585);
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(359, 81);
            this.debugBox.TabIndex = 2;
            this.debugBox.Text = "";
            // 
            // pb_draw
            // 
            this.pb_draw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_draw.Location = new System.Drawing.Point(400, 34);
            this.pb_draw.Name = "pb_draw";
            this.pb_draw.Size = new System.Drawing.Size(1244, 892);
            this.pb_draw.TabIndex = 3;
            this.pb_draw.TabStop = false;
            this.pb_draw.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_draw_Paint);
            // 
            // label_output
            // 
            this.label_output.AutoSize = true;
            this.label_output.Location = new System.Drawing.Point(397, 18);
            this.label_output.Name = "label_output";
            this.label_output.Size = new System.Drawing.Size(82, 13);
            this.label_output.TabIndex = 4;
            this.label_output.Text = "Output graphics";
            // 
            // trackBarAmpl
            // 
            this.trackBarAmpl.Location = new System.Drawing.Point(26, 410);
            this.trackBarAmpl.Maximum = 2000;
            this.trackBarAmpl.Name = "trackBarAmpl";
            this.trackBarAmpl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAmpl.Size = new System.Drawing.Size(45, 169);
            this.trackBarAmpl.TabIndex = 7;
            this.trackBarAmpl.Value = 1;
            this.trackBarAmpl.Scroll += new System.EventHandler(this.trackBarAmpl_Scroll);
            // 
            // trackBarFreq
            // 
            this.trackBarFreq.Location = new System.Drawing.Point(82, 410);
            this.trackBarFreq.Maximum = 500;
            this.trackBarFreq.Name = "trackBarFreq";
            this.trackBarFreq.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarFreq.Size = new System.Drawing.Size(45, 169);
            this.trackBarFreq.TabIndex = 7;
            this.trackBarFreq.Scroll += new System.EventHandler(this.trackBarFreq_Scroll);
            // 
            // labelFreq
            // 
            this.labelFreq.AutoSize = true;
            this.labelFreq.Location = new System.Drawing.Point(79, 391);
            this.labelFreq.Name = "labelFreq";
            this.labelFreq.Size = new System.Drawing.Size(57, 13);
            this.labelFreq.TabIndex = 8;
            this.labelFreq.Text = "Frequency";
            // 
            // labelAmplitude
            // 
            this.labelAmplitude.AutoSize = true;
            this.labelAmplitude.Location = new System.Drawing.Point(23, 391);
            this.labelAmplitude.Name = "labelAmplitude";
            this.labelAmplitude.Size = new System.Drawing.Size(53, 13);
            this.labelAmplitude.TabIndex = 9;
            this.labelAmplitude.Text = "Amplitude";
            // 
            // trackBarLinesCount
            // 
            this.trackBarLinesCount.Location = new System.Drawing.Point(138, 410);
            this.trackBarLinesCount.Maximum = 200;
            this.trackBarLinesCount.Minimum = 10;
            this.trackBarLinesCount.Name = "trackBarLinesCount";
            this.trackBarLinesCount.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarLinesCount.Size = new System.Drawing.Size(45, 169);
            this.trackBarLinesCount.TabIndex = 7;
            this.trackBarLinesCount.Value = 10;
            this.trackBarLinesCount.Scroll += new System.EventHandler(this.trackBarLines_Scroll);
            // 
            // labelLinesCount
            // 
            this.labelLinesCount.AutoSize = true;
            this.labelLinesCount.Location = new System.Drawing.Point(135, 391);
            this.labelLinesCount.Name = "labelLinesCount";
            this.labelLinesCount.Size = new System.Drawing.Size(32, 13);
            this.labelLinesCount.TabIndex = 8;
            this.labelLinesCount.Text = "Lines";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Image = global::wiggleDraw.Properties.Resources.Pelfusion_Flat_Folder_Open_Folder;
            this.buttonOpenFile.Location = new System.Drawing.Point(310, 380);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 36);
            this.buttonOpenFile.TabIndex = 10;
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // openPictureDialog
            // 
            this.openPictureDialog.DefaultExt = "\"jpg\"";
            this.openPictureDialog.Filter = "Pictures |*.jpg;*.bmp;*.png";
            this.openPictureDialog.InitialDirectory = "@\"c:\\\"";
            this.openPictureDialog.Title = "Browse pictures ...";
            // 
            // trackBarDetails
            // 
            this.trackBarDetails.Location = new System.Drawing.Point(194, 410);
            this.trackBarDetails.Maximum = 500;
            this.trackBarDetails.Minimum = 10;
            this.trackBarDetails.Name = "trackBarDetails";
            this.trackBarDetails.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarDetails.Size = new System.Drawing.Size(45, 169);
            this.trackBarDetails.TabIndex = 7;
            this.trackBarDetails.Value = 10;
            this.trackBarDetails.Scroll += new System.EventHandler(this.trackBarDetails_Scroll);
            // 
            // labelDetail
            // 
            this.labelDetail.AutoSize = true;
            this.labelDetail.Location = new System.Drawing.Point(191, 391);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(39, 13);
            this.labelDetail.TabIndex = 11;
            this.labelDetail.Text = "Details";
            // 
            // savebutton
            // 
            this.savebutton.Image = ((System.Drawing.Image)(resources.GetObject("savebutton.Image")));
            this.savebutton.Location = new System.Drawing.Point(310, 544);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 35);
            this.savebutton.TabIndex = 12;
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(26, 702);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(359, 23);
            this.progressBar.TabIndex = 13;
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 938);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.labelDetail);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.labelAmplitude);
            this.Controls.Add(this.labelLinesCount);
            this.Controls.Add(this.labelFreq);
            this.Controls.Add(this.trackBarDetails);
            this.Controls.Add(this.trackBarLinesCount);
            this.Controls.Add(this.trackBarFreq);
            this.Controls.Add(this.trackBarAmpl);
            this.Controls.Add(this.label_output);
            this.Controls.Add(this.pb_draw);
            this.Controls.Add(this.pb_original);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.label_pb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "WiggleDraw 0.1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.onDragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.DragLeave += new System.EventHandler(this.OnDragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pb_original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_draw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLinesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox pb_original;
        private System.Windows.Forms.Label label_pb;
        private System.Windows.Forms.RichTextBox debugBox;
        private System.Windows.Forms.PictureBox pb_draw;
        private System.Windows.Forms.Label label_output;
        private System.Windows.Forms.TrackBar trackBarAmpl;
        private System.Windows.Forms.TrackBar trackBarFreq;
        private System.Windows.Forms.Label labelFreq;
        private System.Windows.Forms.Label labelAmplitude;
        private System.Windows.Forms.TrackBar trackBarLinesCount;
        private System.Windows.Forms.Label labelLinesCount;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.OpenFileDialog openPictureDialog;
        private System.Windows.Forms.TrackBar trackBarDetails;
        private System.Windows.Forms.Label labelDetail;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

