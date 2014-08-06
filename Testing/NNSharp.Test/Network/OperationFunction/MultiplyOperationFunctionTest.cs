using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class MultiplyOperationFunctionTest
    {
        [Test]
        public void TestOperation()
        {
            MultiplyOperationFunction func 
                = MultiplyOperationFunction.Instance;

            Assert.AreEqual(0, func.Operate(0, 1));
            Assert.AreEqual(0, func.Operate(1, 0));

            Assert.AreEqual(143, func.Operate(11, 13));
            Assert.AreEqual(143, func.Operate(13, 11));

            Assert.AreEqual(-1, func.Operate(-1, 1));
            Assert.AreEqual(-1, func.Operate(1, -1));
        }
    }
}