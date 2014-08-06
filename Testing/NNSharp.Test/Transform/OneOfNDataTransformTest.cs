using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class OneOfNDataTransformTest
    {
        [Test]
        public void TestTransformDimension()
        {
            double[] test1 = new double[] { 1 };
            double[] test2 = new double[] { 2 };
            double[] test3 = new double[] { 3 };

            OneOfNDataTransform trans = new OneOfNDataTransform(4);
            double[] value1 = trans.TransformDimension(test1);
            double[] value2 = trans.TransformDimension(test2);
            double[] value3 = trans.TransformDimension(test3);

            Assert.IsTrue(Validate(value1, test1));
            Assert.IsTrue(Validate(value2, test2));
            Assert.IsTrue(Validate(value3, test3));
        }

        private bool Validate(double[] value, double[] test)
        {
            bool valid = true;

            // Check that corresponding index is one.
            if (value[((int)test[0]) - 1] != 1.0)
                valid = false;

            // Check that other indexes is zero.
            for (int index = 0; index < value.Length; index++)
            {
                if (index != test[0] - 1 && value[index] != 0)
                    valid = false;
            }
            return valid;
        }
    }
}