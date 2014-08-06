using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class MinMaxDataTransformTest
    {
        [Test]
        public void TestTransform()
        {
            // Test normalization transformation.
            MinMaxDataTransform trans1 = new MinMaxDataTransform(5, 10);
            double value1 = trans1.TransformValue(6);
            Assert.AreEqual((6 - 5) / (10 - 5.0), value1);

            // Test artbitary min-max value transform
            MinMaxDataTransform trans2 = new MinMaxDataTransform(5, 10, 5, 10);
            double value2 = trans2.TransformValue(6);
            Assert.AreEqual(6, value2);
        }
    }
}
