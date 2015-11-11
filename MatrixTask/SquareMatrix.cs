using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixTask
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>, IElementChangedEvent
    {
        private Container<T> container;

        public readonly int dimension;

        public SquareMatrix(T[,] array)
        {
            if(array == null)
                throw new ArgumentNullException();
            if(!IsSquareArray(array))
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
                OnElementChanged(e);
            }
        }

        private bool IsSquareArray(T[,] array)
        {
            return array.GetLength(0) == array.GetLength(1);
        }
    }
}
