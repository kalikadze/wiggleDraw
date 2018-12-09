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
            ((System.ComponentModel.ISupportInitialize)(this.pb_original)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_original
            // 
            this.pb_original.Location = new System.Drawing.Point(23, 37);
            this.pb_original.Name = "pb_original";
            this.pb_original.Size = new System.Drawing.Size(359, 340);
            this.pb_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            this.debugBox.Location = new System.Drawing.Point(26, 451);
            this.debugBox.Name = "debugBox";
            this.debugBox.Size = new System.Drawing.Size(356, 246);
            this.debugBox.TabIndex = 2;
            this.debugBox.Text = "";
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 718);
            this.Controls.Add(this.debugBox);
            this.Controls.Add(this.label_pb);
            this.Controls.Add(this.pb_original);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "WiggleDraw 0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.onDragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.OnDragOver);
            this.DragLeave += new System.EventHandler(this.OnDragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pb_original)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_original;
        private System.Windows.Forms.Label label_pb;
        private System.Windows.Forms.RichTextBox debugBox;
    }
}

