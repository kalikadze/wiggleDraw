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

namespace wiggleDraw
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            thumbnail = new PictureBox();
            thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_original.Controls.Add(thumbnail);
            thumbnail.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

                       
        }
    }
}
