using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixTask
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        private T[,] container;

        public event EventHandler<ElementChangedEventArgs> elementChanged;

        public override T this[int i, int j]
        {
            get
            {
                if(i >= dimension || j >= dimension || i < 0 || j < 0)
                    throw new ArgumentException();
                return container[i, j];
            }
            set
            {
                if (i >= dimension || j >= dimension || i < 0 || j < 0)
                    throw new ArgumentException();
                ElementChangedEventArgs e = new ElementChangedEventArgs(i, j);
                container[i, j] = value;
                OnElementChanged(e);
            }
        }

        public SquareMatrix(T[,] array)
        {
            CheckIsSquareArray(array);
            dimension = array.GetLength(0);
            InitContainer(array);
        }

        protected override void OnElementChanged(ElementChangedEventArgs e)
        {
            EventHandler<ElementChangedEventArgs> temp = Interlocked.CompareExchange(ref elementChanged, null, null);
            if (temp != null)
                temp(this, e);
        }

        private void CheckIsSquareArray(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException();
        }

        private void InitContainer(T[,] array)
        {
            container = new T[dimension, dimension];
            for (int i = 0; i < dimension; ++i)
                for (int j = 0; j < dimension; ++j)
                    container[i, j] = array[i, j];
        }
    }
}
