using System;
using MatrixTask;
using NUnit.Framework;

namespace TestMatrixTask
{
    [TestFixture]
    public class Test_SquareMatrix
    {
        [Test]
        public void TestConstructor()
        {
            int[,] expected = new int[2, 2] {{1, 0}, {0, 0}};
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(expected);

            int[,] actual = squareMatrix.GetCoefs();

            Assert.AreEqual(2, squareMatrix.Dimension);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}