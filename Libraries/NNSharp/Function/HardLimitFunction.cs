using System;

namespace NNSharp
{
    public class HardLimitFunction : IActivationFunction
    {

        #region IActivationFunction Members

        public double Activate(double value)
        {
            // Return 1 if value is greater than zero,otherwise 0.
            return value >= 0 ? 1.0 : 0.0; 
        }

        public double Activate1stDiff(double value)
        {
            throw new NotImplementedException();
        }

        public double Activate2ndDiff(double value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}