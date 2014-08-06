namespace NNSharp
{
    public class ProcessModifiedHybridFuzzyARTMapParameter : ProcessSimplifiedFuzzyARTMapParameter
    {
        private double vigilanceAdjustRate;

        public double VigilanceAdjustRate
        {
            get { return vigilanceAdjustRate; }
            set { vigilanceAdjustRate = value; }
        }

        private double maximumEntropy;

        public double MaximumEntropy
        {
            get { return maximumEntropy; }
            set { maximumEntropy = value; }
        }

        private double maximumTotalEntropy;

        public double MaximumTotalEntropy
        {
            get { return maximumTotalEntropy; }
            set { maximumTotalEntropy = value; }
        }

        private ProcessModifiedHybridFuzzyARTMapMode mode;

        public ProcessModifiedHybridFuzzyARTMapMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }
    }
}