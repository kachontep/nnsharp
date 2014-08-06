using System;

namespace NNSharp
{
    public class MultiplyOperationFunction : IWeightInputOperation
    {
        public static readonly MultiplyOperationFunction Instance
            = new MultiplyOperationFunction();

        #region IOperationFunction Members

        public double Operate(double val1, double val2)
        {
            return val1 * val2;
        }

        #endregion
    }
}