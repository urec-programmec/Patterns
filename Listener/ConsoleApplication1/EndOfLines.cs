using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    abstract class EndOfLines
    {
        protected string endLeft;
        protected string endRight;

        public string L()
        {
            return endLeft;
        }
        public string R()
        {
            return endRight;
        }
    }
}
