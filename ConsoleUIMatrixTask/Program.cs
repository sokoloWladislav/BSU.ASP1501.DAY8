using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixTask;

namespace ConsoleUIMatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>();
            Informator informator = new Informator(squareMatrix);

            squareMatrix.ChangeElement(2, 3);
            
        }
    }
}
