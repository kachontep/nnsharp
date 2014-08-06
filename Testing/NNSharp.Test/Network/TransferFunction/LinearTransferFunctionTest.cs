using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class LinearTransferFunctionTest
    {
        [Test]
        public void TestTransfer()
        {
            LinearFunction trans 
                = LinearFunction.Instance;

            Assert.AreEqual(0, trans.Activate(0));
            Assert.AreEqual(-1, trans.Activate(-1));
            Assert.AreEqual(1, trans.Activate(1));
        }
    }
}