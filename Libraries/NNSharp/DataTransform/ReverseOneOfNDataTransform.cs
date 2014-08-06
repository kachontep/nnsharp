using System;

namespace NNSharp
{
    public class ReverseOneOfNDataTransform : IDataDimensionToValueTransform
    {
        private int numberOfItems;

        public ReverseOneOfNDataTransform(int numberOfItems)
        {
            this.numberOfItems = numberOfItems;
        }

        #region IDataDimensionToValueTransform Members

        public double TransformDimensionToValue(double[] values)
        {
            if (values.Length != numberOfItems)
                throw new Exception("Values dimension doesn't equal to number of items.");

            double value = 0;
            for (int i = numberOfItems - 1; i >= 0; i--)
            {
                if (Math.Round(values[i], 1) == 1.0)
                    value = i + 1;
            }
            return value;
        }

        #endregion
    }
}