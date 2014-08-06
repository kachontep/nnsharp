namespace NNSharp
{
    public class ProcessOrderedFuzzyARTMapParameter : ProcessSimplifiedFuzzyARTMapParameter
    {
        private int noOfClusters;

        public int NoOfClusters
        {
            get { return noOfClusters; }
            set { noOfClusters = value; }
        }
    }
}