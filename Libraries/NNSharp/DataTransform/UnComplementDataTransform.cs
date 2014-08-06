using System;

namespace NNSharp
{
    public class UnComplementDataTransform : IDataDimensionTransform
    {

        #region IDataDimensionTransform Members

        public double[] TransformDimension(double[] value)
        {
            int midSize = value.Length / 2;
            double[] newValue = new double[midSize];
            for (int i = 0; i < midSize; i++)
                newValue[i] = value[i];
            return newValue;
        }

        #endregion
    }
}