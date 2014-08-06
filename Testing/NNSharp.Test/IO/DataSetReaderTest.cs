using System.Collections.Generic;
using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class DataSetReaderTest 
    {
        private const string FILENAME = "Test/DataSetReaderTest.txt";

        private const int DATA_SIZE = 4;

        private const int TEST_SIZE = 1;

        [Test]
        public void TestRead()
        {
            DataSetReader dsr = new DataSetReader(FILENAME, DATA_SIZE, TEST_SIZE);

            int counter = 0;
            List<double[]> result = new List<double[]>();
            while (true)
            {
                // In testing, create new buffer for each iteration.
                double[] dataBuffer = new double[DATA_SIZE];
                double[] testBuffer = new double[TEST_SIZE];

                if (!dsr.Read(dataBuffer, testBuffer))
                    break;
                ++counter;
            }
           Assert.AreEqual(3, counter);
        }

        [Test]
        public void TestReadValidData()
        {
            DataSetReader dsr = new DataSetReader(FILENAME, DATA_SIZE, TEST_SIZE);

            double[] dataBuffer = new double[DATA_SIZE];
            double[] testBuffer = new double[TEST_SIZE];
            bool success = dsr.Read(dataBuffer, testBuffer);

            Assert.IsTrue(success);

            double[] targetData = new double[] { 5.1000, 3.5000, 1.4000, 0.2000 };
            double[] targetTest = new double[] { 1 };

            Assert.AreEqual(targetData.Length, dataBuffer.Length);
            Assert.AreEqual(targetTest.Length, testBuffer.Length);
            for (int i = 0; i < targetData.Length; ++i)
                Assert.AreEqual(targetData[i], dataBuffer[i], "Mismatch read data at " + (i + 1));
            for (int i = 0; i < targetTest.Length; ++i)
                Assert.AreEqual(targetTest[i], testBuffer[i], "Mismatch read test at " + (i + 1));
        }
    }
}
