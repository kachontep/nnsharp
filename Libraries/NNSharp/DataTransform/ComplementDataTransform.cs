using System;

namespace NNSharp
{
    public class ComplementDataTransform : IDataDimensionTransform
    {
        private double maxValue;

        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public ComplementDataTransform(double maxValue)
        {
            MaxValue = maxValue;
        }

        #region IDataDimensionTransform Members

        public double[] TransformDimension(double[] value)
        {
            int size = value.Length;
            double[] newValue = new double[2 * size];
            for (int i = 0; i < size; i++)
            {
                newValue[i] = value[i];
                newValue[i + size] = MaxValue - value[i];
            }
            return newValue;
        }

        #endregion
    }
}