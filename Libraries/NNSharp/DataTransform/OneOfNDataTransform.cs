using System;

namespace NNSharp
{
    public class OneOfNDataTransform : IDataDimensionTransform
    {
        private int numberOfItems;
        public int NumberOfItems
        {
            get { return numberOfItems; }
        }

        public OneOfNDataTransform(int numberOfItems)
        {
            this.numberOfItems = numberOfItems;
        }

        #region IDataDimensionTransform Members

        public double[] TransformDimension(double[] value)
        {
            double[] newValue = new double[numberOfItems];
            for (int i = 0; i < numberOfItems; ++i)
                newValue[i] = 0.0;
            int index = (int) value[0] - 1;
            if (index >= 0)
                newValue[index] = 1.0;
            return newValue;
        }

        #endregion
    }
}