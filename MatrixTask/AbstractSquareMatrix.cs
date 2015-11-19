using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    public abstract class AbstractSquareMatrix<T>
    {
        public int dimension;

        protected abstract void OnElementChanged(ElementChangedEventArgs e);
        abstract public T this[int i, int j] { get; set; }
    }
}
