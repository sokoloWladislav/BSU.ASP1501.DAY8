using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    public interface IElementChangedEvent<in T>
    {
        event EventHandler<ElementChangedEventArgs> elementChanged;
        void ChangeElement(int line, int column, T value);
    }
}
