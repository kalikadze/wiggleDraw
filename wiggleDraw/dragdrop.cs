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
        protected int lastX = 0;
        protected int lastY = 0;
        protected string lastFilename = String.Empty;
        protected PictureBox thumbnail;
        protected DragDropEffects effect;
        protected bool validData;
        protected Image image;
        protected Image nextImage;
        protected Thread getImageThread;

        protected bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            debugBox.AppendText("OnDrag drop");
            debugBox.AppendText(Environment.NewLine);

            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                thumbnail.Visible = false;
                image = nextImage;
                AdjustView();
                if ((pb_original.Image != null) && (pb_original.Image != nextImage))
                {
                    pb_original.Image.Dispose();
                }
                pb_original.Image = image;
            }
        }

        private void OnDragLeave(object sender, System.EventArgs e)
        {
            debugBox.AppendText("OnDrag leave");
            debugBox.AppendText(Environment.NewLine);
            thumbnail.Visible = false;
        }

        private void OnDragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            debugBox.AppendText("OnDrag over");
            debugBox.AppendText(Environment.NewLine);

            if (validData)
            {
                if ((e.X != lastX) || (e.Y != lastY))
                {
                    SetThumbnailLocation(this.PointToClient(new Point(e.X, e.Y)));
                }
            }
        }

        private void onDragEnter(object sender, DragEventArgs e)
        {
            string filename;

            debugBox.AppendText("OnDrag fired");
            debugBox.AppendText(Environment.NewLine);

            validData = GetFilename(out filename, e);
            if (validData)
            {
                if (lastFilename != filename)
                {
                    thumbnail.Image = null;
                    thumbnail.Visible = false;
                    lastFilename = filename;
                    getImageThread = new Thread(new ThreadStart(LoadImage));
                    getImageThread.Start();
                }
                else
                {
                    thumbnail.Visible = true;
                }
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public delegate void AssignImageDlgt();

        protected void LoadImage()
        {
            nextImage = new Bitmap(lastFilename);
            this.Invoke(new AssignImageDlgt(AssignImage));
        }

        protected void AssignImage()
        {
            thumbnail.Width = 100;
            // 100    iWidth
            // ---- = ------
            // tHeight  iHeight
            thumbnail.Height = nextImage.Height * 100 / nextImage.Width;
            SetThumbnailLocation(this.PointToClient(new Point(lastX, lastY)));
            thumbnail.Image = nextImage;
        }

        protected void SetThumbnailLocation(Point p)
        {
            if (thumbnail.Image == null)
            {
                thumbnail.Visible = false;
            }
            else
            {
                p.X -= thumbnail.Width / 2;
                p.Y -= thumbnail.Height / 2;
                thumbnail.Location = p;
                thumbnail.Visible = true;
            }
        }

        protected void AdjustView()
        {
            float fw = this.ClientSize.Width;
            float fh = this.ClientSize.Height;
            float iw = image.Width;
            float ih = image.Height;

            // iw/fw > ih/fh, then iw/fw controls ih

            float rw = fw / iw;         // ratio of width
            float rh = fh / ih;         // ratio of height

            if (rw < rh)
            {                
                pb_original.Width = (int)fw;
                pb_original.Height = (int)(ih * rw);
                pb_original.Left = 0;
                pb_original.Top = (int)((fh - pb_original.Height) / 2);
            }
            else
            {
                pb_original.Width = (int)(iw * rh);
                pb_original.Height = (int)fh;
                pb_original.Left = (int)((fw - pb_original.Width) / 2);
                pb_original.Top = 0;
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (image != null)
            {
                AdjustView();
            }
        }
    }
}