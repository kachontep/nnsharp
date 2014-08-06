namespace NNSharp
{
    public class ProcessSimplifiedFuzzyARTMapParameter : ProcessBaseParameter
    {
        private double choicingParam;

        private double artABasedVigilance;

        private double artABeta;

        public double ChoicingParam
        {
            get { return choicingParam; }
            set { choicingParam = value; }
        }

        public double ArtABasedVigilance
        {
            get { return artABasedVigilance; }
            set { artABasedVigilance = value; }
        }

        public double ArtABeta
        {
            get { return artABeta; }
            set { artABeta = value; }
        }

    }
}