using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class FuzzySetIntersectionOperationTest
    {
        [Test]
        public void TestOperation()
        {
            FuzzySetIntersectOperation operation = 
                FuzzySetIntersectOperation.Instance;

            int dataSize = 5;
            double[] test1 = { 1, 2, 3, 4, 5 };
            double[] test2 = { 5, 4, 3, 2, 1 };
            double[] expected = { 1, 2, 3, 2, 1 };

            for (int i = 0; i < dataSize; i++)
            {
                Assert.AreEqual(expected[i], operation.Operate(test1[i], test2[i]));
            }
        }
    }
}