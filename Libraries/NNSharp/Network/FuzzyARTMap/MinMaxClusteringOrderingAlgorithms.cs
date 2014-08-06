using System;

namespace NNSharp
{
    public class MinMaxClusteringOrderingAlgorithms : IOrderingAlgorithms
    {
        protected int numberOfClusters;

        public MinMaxClusteringOrderingAlgorithms(int numberOfClusters)
        {
            this.numberOfClusters = numberOfClusters;
        } // end constructor

        #region IOrderingAlgorithms Members

        public void OrderSequence(double[][] data, double[][] target)
        {
            int r = 0, index = 0;
            // Step 1 : Select the central of tendency value of first cluster.
            index = StepOneProcess( data, target);
            SwapPattern(r++, index, data, target);
            // Step 2 : Selec the central of tendency of other 
            // numberOfClusters - 1 values.
            while (r < numberOfClusters)
            {
                index = StepTwoProcess(r, data, target);
                SwapPattern(r++, index, data, target);
            }
            // Step 3 : Select the rest n - numberOfClusters values.
            while (r < data.GetUpperBound(0))
            {
                index = StepThreeProcess(r, data, target);
                SwapPattern(r++, index, data, target);
            }
        } // end method

        #endregion

        protected virtual void SwapPattern(int src, int dest, double[][] data, double[][] target)
        {
            // Swap data pattern
            double[] t = data[src];
            data[src] = data[dest];
            data[dest] = t;
            // Swap target pattern
            t = target[src];
            target[src] = target[dest];
            target[dest] = t;
        } // end method

        protected double EuclideanDistance(double[] a, double[] b)
        {
            if( a.Length != b.Length )
                throw new ArgumentException("Vector are dfferent dimension.");
            double distance = 0;
            for(int i = 0; i < a.Length; ++i)
            {
                distance += Math.Pow( a[i] - b[i], 2);
            }
            return Math.Sqrt(distance);
        } //end method

        protected virtual int StepOneProcess(double[][] data, double[][] target)
        {
            int dimension = data[0].GetUpperBound(0) + 1;

            if (dimension % 2 != 0)
            {
                throw new ArgumentException("Data is invalid dimension.");
            }

            int halfDiff = dimension / 2, index = 0;
            double min = double.MaxValue;
            for (int i = 0; i <= data.GetUpperBound(0); ++i)
            {
                double sum = 0;
                for (int j = 0; j < halfDiff; ++j)
                {
                    sum += Math.Abs(data[i][halfDiff+j] - data[i][j]);
                }
                if (sum < min)
                {
                    min = sum;
                    index = i;
                }
            }
            return index;
        } // end method

        protected virtual int StepTwoProcess(int r, double[][] data, double[][] target)
        {
            int index = 0, upperBound = data.GetUpperBound(0);
            double max = double.MinValue, distance = 0;
            for (int i = r; i <= upperBound; ++i)
            {
                double min = double.MaxValue;
                for (int j = 0; j < r; ++j)
                {
                    distance = EuclideanDistance(data[i], data[j]);
                    if (distance < min)
                        min = distance;
                }
                if (min > max)
                {
                    max = distance;
                    index = i;
                }
            }
            return index;
        } // end method

        protected virtual int StepThreeProcess(int r, double[][] data, double[][] target)
        {
            int index = 0, upperBound = data.GetUpperBound(0);
            double min = double.MaxValue, distance = 0;
            for (int i = r; i <= upperBound; ++i)
            {
                for (int j = 0; j < r; j++)
                {
                    distance = EuclideanDistance(data[i], data[j]);
                    if (distance < min)
                    {
                        min = distance;
                        index = i;
                    }
                }
            }
            return index;
        } // end method
    } // end class
}