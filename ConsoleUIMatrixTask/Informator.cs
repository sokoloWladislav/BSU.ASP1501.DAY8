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
        public Informator(IElementChangedEvent matrix)
        {
            matrix.elementChanged += Inform;
        }

        public void Unregister(IElementChangedEvent matrix)
        {
            matrix.elementChanged -= Inform;
        }

        private void Inform(object sender, ElementChangedEventArgs e)
        {
            Console.WriteLine("the element in {0} line {1} column is changed", e.Line, e.Column);
            Console.ReadKey();
        }
    }
}
