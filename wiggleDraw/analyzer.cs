using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace wiggleDraw
{
    class Analyzer
    {
        public int minValPixel = Int32.MaxValue;
        public int maxValPixel = Int32.MinValue;
        public int valPixel;

        private int[,] matrix;


        Analyzer(PictureBox pb, int lines, int details)
        {
            matrix = new int[details, lines];
        }

        public void readPic(PictureBox pb)
        {
            Color pixel;
            Color minPixel;
            Color maxPixel;

            if (pb.Image != null)
            {
                Bitmap img = (Bitmap)pb.Image.Clone();

                for (int i = 0; i < pb.Width; i++)
                    for (int j = 0; j < pb.Height; j++)
                    {
                        pixel = img.GetPixel(i, j);
                        valPixel = pixel.ToArgb();

                        if (valPixel < minValPixel)
                            minValPixel = valPixel;
                        if (valPixel > maxValPixel)
                            maxValPixel = valPixel;
                    }
            }

        }

        public int getMinPixel()
        {            
            return minValPixel;
        }

        public int getMaxPixel()
        {
            return maxValPixel;
        }
    }
}
