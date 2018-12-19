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


        public Analyzer(PictureBox pb, int yseg, int xseg)
        {
            cmat = new long[pb.Image.Width / xseg, pb.Image.Height / yseg];
            amat = new long[pb.Image.Width / xseg, pb.Image.Height / yseg];

            this.xseg = xseg;
            this.yseg = yseg;

            for (int i = 0; i < pb.Image.Width / xseg; i++)
                for (int j = 0; j < pb.Image.Height / yseg; j++)
                {
                    cmat[i, j] = Int32.MaxValue;
                    amat[i, j] = Int32.MaxValue;
                }
        }

        public void analyze(PictureBox pb)
        {
            Color pixel;
            Color minPixel;
            Color maxPixel;

            long avgSegC;    // average color per segment
            long avgSegA;    // average alpha per segment
            long argbpix;    
            long cntSeg;     // segment points


            if (pb.Image != null)
            {
                Bitmap img = (Bitmap)pb.Image.Clone();

                for (int x = 0; x < img.Width / xseg; x++)
                    for (int y = 0; y < img.Height / yseg; y++)
                    {
                        avgSegC = 0;
                        avgSegA = 0;
                        cntSeg = 0;

                        for (int xx = 0; xx < xseg; xx++)
                            for (int yy = 0; yy < yseg; yy++)
                            {
                                if (((xx + xseg * x) < img.Width) && ((yy + yseg * y) < img.Height))
                                {
                                    pixel = img.GetPixel(xx + xseg * x, yy + yseg * y);
                                    argbpix = pixel.ToArgb();
                                    avgSegC += argbpix;
                                    avgSegA += pixel.A;
                                    cntSeg++;
                                }
                            }
                        avgSegC /= cntSeg;
                        avgSegA /= cntSeg;
                        cmat[x, y] = avgSegC;
                        amat[x, y] = avgSegA;
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
