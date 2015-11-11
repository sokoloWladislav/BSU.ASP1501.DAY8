using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    public abstract class AbstractSquareMatrix<T>
    {
        abstract public T[,] GetCoefs();
    }
}
