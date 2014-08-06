using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class ComplementDataTransformTest
    {
        private const int PRECISION_DIGITS = 3;

        [Test]
        public void TestTransformDimension()
        {
            double[] test = new double[] { 0.2, 0.8, 1.0 };
            double[] expected = new double[] { 0.2, 0.8, 1.0, 0.8, 0.2, 0.0 };

            ComplementDataTransform trans = new ComplementDataTransform(1.0);
            double[] value = trans.TransformDimension(test);

            Validate(expected, value);
        }

        private void Validate(double[] expected, double[] value)
        {
            // Check that they are the same length.
            if (expected.Length != value.Length)
                Assert.Fail("The length aren't the same.");

            // Check that each element is equal (order and value).
            for (int i = 0; i < value.Length; i++)
            {
                if (Math.Round(expected[i],PRECISION_DIGITS) != Math.Round(value[i],PRECISION_DIGITS))
                {
                    Assert.Fail("Element values are mismatch at " + i + " position. ( expected : " +
                        expected[i] + " , value : " + value[i] + " ) ");
                }
            }
        }
    }
}


