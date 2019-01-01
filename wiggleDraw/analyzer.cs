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
        private int minValPixel = Int32.MaxValue;
        private int maxValPixel = Int32.MinValue;
        private int valPixel;

        private long[,] cmat;
        private long[,] amat;
        private int xseg;
        private int yseg;
        private PictureBox pb;


        public Analyzer(PictureBox pb, int yseg, int xseg)
        {
            cmat = new long[xseg - 1, yseg - 1];
            amat = new long[xseg - 1, yseg - 1];

            this.xseg = xseg;
            this.yseg = yseg;
            this.pb = pb;

            for (int i = 0; i < xseg - 1; i++)
                for (int j = 0; j < yseg - 1; j++)
                {
                    cmat[i, j] = Int32.MaxValue;
                    amat[i, j] = Int32.MaxValue;
                }
        }

        public void analyze()
        {
            Color pixel;
            Color minPixel;
            Color maxPixel;

            long avgSegC;    // average color per segment
            long avgSegA;    // average alpha per segment
            long argbpix;    
            long cntSeg;     // segment points

            float xs = pb.Image.Width / xseg;
            float ys = pb.Image.Height / yseg;


            if (pb.Image != null)
            {
                Bitmap img = (Bitmap)pb.Image.Clone();

                for (int xn = 0; xn < xseg - 1; xn++)
                    for (int yn = 0; yn < yseg - 1; yn++)
                    {
                        avgSegC = 0;
                        avgSegA = 0;
                        cntSeg = 0;

                        for (int x = 0; x < xs; x++)
                            for (int y = 0; y < ys; y++)
                            {
                                if (((x + xs * xn) < pb.Image.Width) && ((y + ys * yn) < pb.Image.Height))
                                {
                                    pixel = img.GetPixel((int)(x + xs * xn), (int)(y + ys * yn));
                                    argbpix = pixel.ToArgb();
                                    avgSegC += argbpix;
                                    avgSegA += pixel.A;
                                    cntSeg++;
                                }
                            }
                        avgSegC /= cntSeg;
                        avgSegA /= cntSeg;
                        cmat[xn, yn] = avgSegC;
                        amat[xn, yn] = avgSegA;
                    }
            }
        }

        public long[,] getColorMatrix()
        {
            return cmat;
        }
        public long[,] getAlphaMatrix()
        {
            return amat;
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


//junkyard
/*
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
                    */
