using System;
using System.Collections.Generic;
using System.Linq;
using t = System.Text;

namespace ConsoleApplication1
{
    class Line : ILine
    {
        public delegate void isChanged(object zzzzzz, Test aaaaa);

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
            changed?.Invoke(this, new Test(3));
        }

        public void changeRight(EndOfLines newEnd)
        {
            this.endRight = newEnd.R();
            if (changed != null) changed(this, new Test(2));
        }

        public string Draw()
        {
            return endLeft + body + endRight;
        }
    }
    public class Test : EventArgs
    {
        public int X { get; set; }
        public Test(int x)
        {
            X = x;
        }
    }
}
