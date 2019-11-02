using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{    
    class Line : ILine
    {
        public delegate void isChanged();

        public event isChanged changed;

        string body = "";
        string endLeft = "";
        string endRight = "";

        public Line(int len, EndOfLines left, EndOfLines right)
        {
            this.body = new string('-', len);
            this.endLeft = left.L();
            this.endRight = right.R();
        }

        public void changeLeft(EndOfLines newEnd)
        {
            this.endLeft = newEnd.L();
            changed();
        }

        public void changeRight(EndOfLines newEnd)
        {
            this.endRight = newEnd.R();
            changed();
        }

        public string Draw()
        {
            return endLeft + body + endRight;
        }
    }
}
