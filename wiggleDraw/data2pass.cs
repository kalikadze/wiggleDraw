using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace wiggleDraw
{
    class data2pass
    {
        private int xseg;
        private int yseg;
        private int ampl;
        private int freq;
        private PaintEventArgs pe;

        public data2pass(int xseg, int yseg, int ampl, int freq, PaintEventArgs pe)
        {
            this.xseg = xseg;
            this.yseg = yseg;
            this.ampl = ampl;
            this.freq = freq;
            this.pe = pe;
        }

        public int get_ampl()
        {
            return ampl;
        }

        public int get_freq()
        {
            return freq;
        }

        public int get_xseg()
        {
            return xseg;
        }

        public int get_yseg()
        {
            return yseg;
        }

        public PaintEventArgs get_pe_arg()
        {
            return pe;
        }
    }
}
