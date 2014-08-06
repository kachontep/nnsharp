namespace NNSharp
{
    public abstract class BaseStatsAlgorithms : IStatsAlgorithms
    {
        private ModifiedMapField mm;

        public ModifiedMapField MapField
        {
            get { return mm; }
            set { mm = value; }
        }

        public BaseStatsAlgorithms(ModifiedMapField mm)
        {
            this.mm = mm;    
        }

        public abstract double Compute(int category);
    }
}