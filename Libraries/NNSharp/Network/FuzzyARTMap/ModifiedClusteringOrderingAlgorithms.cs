using System;

namespace NNSharp
{
    public class ModifiedClusteringOrderingAlgorithms : MinMaxClusteringOrderingAlgorithms
    {
        private DataTransformChain transform;

        private int[] selectedClasses;

        public ModifiedClusteringOrderingAlgorithms(int numberOfClusters) : base(numberOfClusters)
        {
            transform = new DataTransformChain();
            transform.AppendDataTransform(new UnComplementDataTransform());
            transform.AppendDataTransform(new ReverseOneOfNDataTransform(numberOfClusters));
            selectedClasses = new int[numberOfClusters];
        }

        protected override void SwapPattern(int src, int dest, double[][] data, double[][] target)
        {
            // Save the selected classes
            if ( src < numberOfClusters )
            {
                int targetClass = (int)transform.TransformToValue(target[dest]);
                selectedClasses[src] = targetClass;
            }

            base.SwapPattern(src, dest, data, target);
        }

        protected override int StepTwoProcess(int r, double[][] data, double[][] target)
        {
            int index = 0, upperBound = data.GetUpperBound(0);
            double max = double.MinValue, distance = 0;
            for (int i = r; i <= upperBound; ++i)
            {
                int targetClass = (int) transform
                                            .TransformToValue(target[i]);

                bool skip = false;
                foreach(int selectedClass in selectedClasses)
                {
                    if (targetClass == selectedClass)
                    {
                        skip = true;
                    }
                }

                // Skip when it is in selected classes.
                if (skip) continue;

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
    }
}