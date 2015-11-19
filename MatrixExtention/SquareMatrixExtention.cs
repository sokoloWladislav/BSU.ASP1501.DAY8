using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixTask;

namespace MatrixExtention
{
    public static class SquareMatrixExtention
    {
        public static AbstractSquareMatrix<T> Add<T>(this AbstractSquareMatrix<T> first, AbstractSquareMatrix<T> second)
        {
            if(first == null || second == null)
                throw new ArgumentNullException();
            if(first.dimension != second.dimension)
                throw new ArgumentException("Matrices with different dimentions");
            if (first is DiagonalMatrix<T> && second is DiagonalMatrix<T>)
                return TwoDiagonalMatrices<T>(first, second);
        }

        private static DiagonalMatrix<T> TwoDiagonalMatrices<T>(DiagonalMatrix<T> first, DiagonalMatrix<T> second)
        {
            T[] coefs = new T[first.dimension];
            for (int i = 0; i < coefs.Length; ++i)
                coefs[i] = first[i, i] + second[i, i];
            return new DiagonalMatrix<T>(coefs);
        }
    }
}
