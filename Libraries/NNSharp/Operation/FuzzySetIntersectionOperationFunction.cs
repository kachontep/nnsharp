using System;

namespace NNSharp
{
    public class FuzzySetIntersectOperation : IWeightInputOperation
    {
        public static readonly FuzzySetIntersectOperation Instance
            = new FuzzySetIntersectOperation();

        #region IOperationFunction Members

        public double Operate(double val1, double val2)
        {
            return (val1 > val2) ? val2 : val1;
        }

        #endregion
    }
}