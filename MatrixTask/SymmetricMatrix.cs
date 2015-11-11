using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixTask
{
    class SymmetricMatrix<T> : AbstractSquareMatrix<T>, IElementChangedEvent
    {
        private Container<T> container;

        public readonly int dimension;

        public SymmetricMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!IsSymmetricArray(array))
                throw new ArgumentException();
            dimension = (int)Math.Sqrt(array.Length);
            container = new Container<T>(array, dimension);
        }

        public override T[,] GetCoefs()
        {
            return container.coefs;
        }

        public event EventHandler<ElementChangedEventArgs> elementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs e)
        {
            EventHandler<ElementChangedEventArgs> temp = Interlocked.CompareExchange(ref elementChanged, null, null);
            if (temp != null)
                temp(this, e);
        }

        public void SetElement(int line, int column, T element)
        {
            if (line < dimension && column < dimension)
            {
                ElementChangedEventArgs e = new ElementChangedEventArgs(line, column);
                container.coefs[line, column] = element;
                container.coefs[column, line] = element;
                OnElementChanged(e);
            }
        }

        private bool IsSymmetricArray(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                return false;
            for(int i = 0; i < dimension; ++i)
                for(int j = 0; j < dimension; ++j)
                    if (!Equals(container.coefs[i, j], container.coefs[j, i]))
                        return false;
            return true;
        }
    }
}
