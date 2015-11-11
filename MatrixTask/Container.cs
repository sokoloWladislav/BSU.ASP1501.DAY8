using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    internal class Container<T>
    {
        public T[,] coefs;
        public Container(T[,] array, int dimension)
        {
            coefs = new T[dimension, dimension];
            for(int i = 0; i < dimension; ++i)
                for (int j = 0; j < dimension; ++j)
                    coefs[i, j] = array[i, j];
        }

        public Container(T[] array, int dimension)
        {
            if(array == null)
                throw new ArgumentNullException();
            coefs = new T[dimension, dimension];
            for (int i = 0; i < dimension; ++i)
                coefs[i, i] = array[i];
        }
    }
}
