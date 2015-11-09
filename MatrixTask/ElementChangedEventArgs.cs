using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    public class ElementChangedEventArgs : EventArgs
    {
        private readonly int line, column;

        public ElementChangedEventArgs(int line, int column)
        {
            this.line = line;
            this.column = column;
        }

        public int Line { get { return line; } }
        public int Column { get { return column; } }
    }
}
