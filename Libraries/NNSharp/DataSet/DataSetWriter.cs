using System;
using System.IO;
using System.Text;

namespace NNSharp
{
    public class DataSetWriter
    {
        private StreamWriter writer;

        private int dataSize;
        public int DataSize
        {
            get { return dataSize; }
        }

        private int testSize;
        public int TestSize
        {
            get { return testSize; }
        }

        private bool isClosed;
        public bool IsClosed
        {
            get { return isClosed; }
        }

        public DataSetWriter(string filename, bool append, int dataSize, int testSize)
        {
            writer = new StreamWriter(filename, append);
            this.dataSize = dataSize;
            this.testSize = testSize;
        }

        public void Write(double[] data, double[] test, double[] expected)
        {
            StringBuilder sb = new StringBuilder();
            if (data != null)
            {
                int size = dataSize == 0 ? data.Length : dataSize;
                for (int i = 0; i < size; ++i)
                    sb.Append(String.Format("{0:0.0000} ", data[i]));
            }
            sb.Append(" ");
            if (test != null)
            {
                int size = testSize == 0 ? test.Length : testSize;
                for (int i = 0; i < size; ++i)
                    sb.Append(test[i] + " ");
            }
            sb.Append(" ");
            if (expected != null)
            {
                int size = testSize == 0 ? expected.Length : testSize;
                for (int i = 0; i < size; ++i)
                    sb.Append(expected[i]);
            }
            writer.WriteLine(sb.ToString());
        }

        public void Write(double[][] data, double[][] test, double[][] expected)
        {
            int numberOfData = data.GetUpperBound(0);
            int numberOfTest = test.GetUpperBound(0);

            if (numberOfData != numberOfTest)
                throw new ArgumentException("The data and test input are different size.");

            // Write each data and test.
            for (int i = 0; i < data.GetUpperBound(0); ++i)
                Write(data[i], test[i], expected[i]);
        }

        public void Close()
        {
            writer.Close();
            isClosed = true;
        }
    }
}