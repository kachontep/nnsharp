using System;

namespace NNSharp
{
    public class OrderedFuzzyARTMap : ISupervisedLearning
    {
        private double[][] dataSequence, targetSequence;

        private IOrderingAlgorithms orderingAlgorithms;

        private SimplifiedFuzzyARTMap fuzzyARTMap;

        public OrderedFuzzyARTMap(SimplifiedFuzzyARTMap fuzzyARTMap, int noOfClusters) :
            this(fuzzyARTMap, new MinMaxClusteringOrderingAlgorithms(noOfClusters))
        {
        }

        public OrderedFuzzyARTMap(SimplifiedFuzzyARTMap fuzzyARTMap,
            IOrderingAlgorithms orderingAlgorithms)
        {
            this.fuzzyARTMap = fuzzyARTMap;
            this.orderingAlgorithms = orderingAlgorithms;
        }

        #region ISupervisedLearning Members

        public void Run(double[][] data, double[][] target)
        {
            // Order input sequence with min-max clustering algorithms.
            if (dataSequence != data || targetSequence != target)
            {
                orderingAlgorithms.OrderSequence(data, target);
                dataSequence = data;
                targetSequence = target;
            }
            // Run simplified FuzzyARTMap neural network.
            fuzzyARTMap.Run(dataSequence, targetSequence);
        }

        public void Run(double[] data, double[] target)
        {
            throw new NotSupportedException(
                "OrderedFuzzyARTMap doesn't support running with single-step pattern.");
        }

        public void Run(double[] data)
        {
            fuzzyARTMap.Run(data);
        }

        #endregion

        public SimplifiedFuzzyARTMap FuzzyARTMap
        {
            get { return fuzzyARTMap; }
        }
    }
}