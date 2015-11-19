using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixTask
{
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        private T[][] container;

        public event EventHandler<ElementChangedEventArgs> elementChanged;

        public override T this[int i, int j]
        {
            get
            {
                if (i >= dimension || j >= dimension || i < 0 || j < 0)
                    throw new ArgumentException();
                if (i < j)
                    return container[j][i];
                return container[i][j];
            }
            set
            {
                if (i >= dimension || j >= dimension || i < 0 || j < 0)
                    throw new ArgumentException();
                ElementChangedEventArgs e = new ElementChangedEventArgs(i, j);
                if (i < j)
                    container[j][i] = value;
                container[i][j] = value;
                OnElementChanged(e);
            }
        }

        public SymmetricMatrix(T[][] array)
        {
            CheckIsJuggedArray(array);
            dimension = array.Length;
            InitContainer(array);
        }

        protected override void OnElementChanged(ElementChangedEventArgs e)
        {
            EventHandler<ElementChangedEventArgs> temp = Interlocked.CompareExchange(ref elementChanged, null, null);
            if (temp != null)
                temp(this, e);
        }

        private void CheckIsJuggedArray(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            foreach (var line in array)
                if (line == null)
                    throw new ArgumentNullException();
            
            for(int i = 0; i < array.Length; ++i)
                if(array[i].Length != i + 1)
                    throw new ArgumentException();
        }

        private void InitContainer(T[][] array)
        {
            container = new T[dimension][];
            for (int i = 0; i < dimension; ++i)
                container[i] = new T[i + 1];
            for (int i = 0; i < dimension; ++i)
                for (int j = 0; j < dimension; ++j)
                    container[i][j] = array[i][j];
        }
    }
}
