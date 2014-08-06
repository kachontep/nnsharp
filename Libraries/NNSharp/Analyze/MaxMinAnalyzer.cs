using System;
using System.Collections;
using System.Collections.Generic;

namespace NNSharp
{
    public class MaxMinAnalyzer
    {
        private List<double> maxs;
        private List<double> mins;

        public MaxMinAnalyzer(int numberOfColumns)
        {
            maxs = new List<double>();
            mins = new List<double>();

            for (int column = 0; column < numberOfColumns; column++)
            {
                maxs.Add(double.MinValue);
                mins.Add(double.MaxValue);
            }
        }

        public void AnalyzeValue(int column, double value)
        {
            if (maxs[column] < value)
                maxs[column] = value;
            if (mins[column] > value)
                mins[column] = value;
        }

        public List<double> MaxValues
        {
            get
            {
                return maxs;
            }
        }

        public List<double> MinValues
        {
            get
            {
                return mins;
            }
        }
    }
}