using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixTask
{
    public class SquareMatrix<T> : AbstractMatrix<T>, IElementChangedEvent<T>
    {
        //implement containers, ctors

        public event EventHandler<ElementChangedEventArgs> elementChanged;

        protected virtual void OnElementChanged(ElementChangedEventArgs e)
        {
            EventHandler<ElementChangedEventArgs> temp = Interlocked.CompareExchange(ref elementChanged, null, null);
            if (temp != null)
                temp(this, e);
        }

        public void ChangeElement(int line, int column, T value)
        {
            ElementChangedEventArgs e = new ElementChangedEventArgs(line, column);

            //implement changing of element

            OnElementChanged(e);
        }
    }
}
