using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixTask
{
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        private T[] container;

        public event EventHandler<ElementChangedEventArgs> elementChanged;

        public override T this[int i, int j]
        {
            get
            {
                if(i >= dimension || j >= dimension || i < 0 || j < 0)
                    throw new ArgumentException();
                if(i == j)
                    return container[i];
                // return default value for type
                return container[i];                 //mistake
            }
            set
            {
                if (i >= dimension || i < 0 ||  i != j)
                    throw new ArgumentException();
                ElementChangedEventArgs e = new ElementChangedEventArgs(i, j);
                container[i] = value;
                OnElementChanged(e);
            }
        }

        public DiagonalMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            dimension = array.Length;
            InitContainer(array);
        }

        protected override void OnElementChanged(ElementChangedEventArgs e)
        {
            EventHandler<ElementChangedEventArgs> temp = Interlocked.CompareExchange(ref elementChanged, null, null);
            if (temp != null)
                temp(this, e);
        }

        private void InitContainer(T[] array)
        {
            container = new T[dimension];
            for (int i = 0; i < dimension; ++i)
                    container[i] = array[i];
        }
    }
}
