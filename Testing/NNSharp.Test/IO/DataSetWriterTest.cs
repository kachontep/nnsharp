using System;
using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class DataSetWriterTest
    {
        private const string FILENAME = "Test/DataSetWriterTest.txt";

        [Test]
        public void TestWrite()
        {
            double[] dataBuffer = new double[] { 1.5 , 2.399 , 3.1234, 4.0555, 5.01111 };
            double[] testBuffer = new double[] { 6.0 };

            DataSetWriter dwr = new DataSetWriter(FILENAME, false, 5, 1);
            for (int i = 0; i < 3; ++i)
            {
                dwr.Write(dataBuffer, testBuffer, testBuffer);
            }
            dwr.Close();

            DataSetReader dsr = new DataSetReader(FILENAME, 5, 1);
            for (;dsr.Read(dataBuffer, testBuffer);) ;

            Assert.AreEqual(3, dsr.Count);
        }
    }
}