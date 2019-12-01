using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    interface ILine
    {
        string Draw();
        void changeLeft(EndOfLines newEnd);
        void changeRight(EndOfLines newEnd);
    }
}
