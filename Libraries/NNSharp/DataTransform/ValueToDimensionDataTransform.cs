namespace NNSharp
{
    public class ValueToDimensionDataTransform : IDataValueToDimensionTransform
    {
        #region IDataValueToDimensionTransform Members

        public double[] TransformValueToDimension(double value)
        {
            return new double[] { value };
        }

        #endregion
    }
}