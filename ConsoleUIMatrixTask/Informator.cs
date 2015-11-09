using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixTask;

namespace ConsoleUIMatrixTask
{
    public class Informator
    {
        public Informator(IElementChangedEvent<int> matrix)
        {
            matrix.elementChanged += merhod;
        }

        //implement method
    }
}
