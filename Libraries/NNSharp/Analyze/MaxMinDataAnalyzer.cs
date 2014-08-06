using System;

namespace NNSharp
{
    public class MaxMinDataAnalyze : IDataAnalyze
    {
        private int numberOfColumns;

        private bool async;

        private bool init;

        private double[] maxValues;

        private double[] minValues;

        public MaxMinDataAnalyze(int numeberOfColumns)
            : this(numeberOfColumns, false)
        {
        }

        public MaxMinDataAnalyze(int numberOfColumns, bool async)
        {
            this.init = false;
            this.numberOfColumns = numberOfColumns;
            this.async = async;
            this.maxValues = new double[numberOfColumns];
            this.minValues = new double[numberOfColumns];
        }

        private void InitializeMaxMinValues()
        {
            for (int i = 0; i < numberOfColumns; i++)
            {
                maxValues[i] = double.MinValue;
                minValues[i] = double.MaxValue;
            }
        }

        #region IDataAnalyzer Members

        public void Analyze(double[][] data)
        {
            if (!async)
            {
                InitializeMaxMinValues();
                for (int row = 0; row < data.GetUpperBound(0); ++row)
                {
                    for (int col = 0; col < numberOfColumns; ++col)
                    {
                        if (data[row][col] > maxValues[col])
                            maxValues[col] = data[row][col];
                        if (data[row][col] < minValues[col])
                            minValues[col] = data[row][col];
                    }
                }
            }
        }

        public void AnalyzeAsync(double[] data)
        {
            if (async)
            {
                if (!init)
                {
                    InitializeMaxMinValues();
                    init = true;
                }
                for(int col = 0; col < numberOfColumns; ++col)
                {
                    if(data[col] < minValues[col])
                        minValues[col] = data[col];
                    if (data[col] > maxValues[col])
                        maxValues[col] = data[col];
                }
            }
        }

        #endregion

        public double[] MaxValues
        {
            get { return maxValues; }
        }

        public double[] MinValues
        {
            get { return minValues; }
        }
    }
}