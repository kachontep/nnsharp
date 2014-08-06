using System;

namespace NNSharp
{
    public class SigmoidalFunction : IActivationFunction
    {
        #region ITransferFunction Members

        public double Activate(double value)
        {
            return 1 / Math.Pow(Math.E, -value);
        }

        public double Activate1stDiff(double value)
        {
            throw new System.NotImplementedException();
        }

        public double Activate2ndDiff(double value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
