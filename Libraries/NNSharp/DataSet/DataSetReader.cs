using System;
using System.IO;
using System.Collections.Generic;

namespace NNSharp
{
    public class DataSetReader
    {
        private string filename;

        private StreamReader reader;

        private int dataSize;

        private int targetSize;

        private bool isClosed;

        private int count;


        public DataSetReader(string filename, int dataSize, int targetSize)
        {
            this.filename = filename;
            this.dataSize = dataSize;
            this.targetSize = targetSize;

            Initialize();
           
        }

        protected virtual void Initialize()
        {
            if (reader != null)
                reader.Close();
            reader = new StreamReader(filename);
            isClosed = false;
            count = 0;
        }

        public bool Read(double[] data, double[] test)
        {
            if (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] elements = line.Split(new char[] {  ' ', ',', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != dataSize + targetSize)
                    return false;
                // Read data size block before.
                if (data != null && data.Length != 0)
                {
                    for (int i = 0; i < dataSize; ++i)
                        data[i] = double.Parse(elements[i]);
                }
                if (test != null && test.Length != 0)
                {
                    for (int j = 0; j < targetSize; ++j)
                        test[j] = double.Parse(elements[j + dataSize]);
                }
                ++count;
                return true;
            }
            else
            {
                reader.Close();
                isClosed = true;
                return false;
            }
        }

        public void ReadAll(out double[][] data, out double[][] test)
        {
            Initialize();
            // Initialize data and test list.
            List<double[]> dataList = new List<double[]>();
            List<double[]> testList = new List<double[]>();

            bool found = true;
            while (found)
            {
                // Create new double[] instance for each pattern.
                double[] tempData = new double[dataSize];
                double[] tempTest = new double[targetSize];
                if (Read(tempData, tempTest))
                {
                    dataList.Add(tempData);
                    testList.Add(tempTest);
                }
                else
                {
                    found = false;
                }
            }
            reader.Close();
            isClosed = true;
            // Convert list into array.
            data = dataList.ToArray();
            test = testList.ToArray();
        }

        public int DataSize
        {
            get { return dataSize; }
            set { dataSize = value; }
        }

        public int TargetSize
        {
            get { return targetSize; }
            set { targetSize = value; }
        }

        public bool IsClosed
        {
            get { return isClosed; }
        }

        public int Count
        {
            get { return count; }
        }
    }
}