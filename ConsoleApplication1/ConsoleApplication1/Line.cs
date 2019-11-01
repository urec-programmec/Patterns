using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{    
    class Line : ILine
    {
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
        }

        public void changeRight(EndOfLines newEnd)
        {
            this.endLeft = newEnd.R();
        }

        public string Draw()
        {
            return endLeft + body + endRight;
        }
    }
}
