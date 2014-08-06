namespace NNSharp
{
    public class LinearFunction : IActivationFunction
    {
        public static readonly LinearFunction Instance
            = new LinearFunction();

        #region ITransferFunction Members

        public double Activate(double value)
        {
            return value;
        }

        public double Activate1stDiff(double value)
        {
            return 1;
        }

        public double Activate2ndDiff(double value)
        {
            return 0;
        }

        #endregion
    }
}