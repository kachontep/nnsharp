using System.Collections;

namespace NNSharp
{
    public class DataTransformChain : CollectionBase
    {
        public void AppendDataTransform(IDataTransform dataTransform)
        {
            InnerList.Add(dataTransform);
        }

        protected virtual object Transform(object value)
        {
            object result = value;
            foreach (IDataTransform dataTransform in this.InnerList)
            {
                if (dataTransform is IDataValueTransform)
                {
                    result = ((IDataValueTransform)dataTransform)
                        .TransformValue(((double)result));
                }
                else if (dataTransform is IDataDimensionTransform)
                {
                    result = ((IDataDimensionTransform)dataTransform)
                        .TransformDimension((double[])result);
                }
                else if (dataTransform is IDataValueToDimensionTransform)
                {
                    result = ((IDataValueToDimensionTransform)dataTransform)
                        .TransformValueToDimension((double)result);
                }
                else if (dataTransform is IDataDimensionToValueTransform)
                {
                    result = ((IDataDimensionToValueTransform)dataTransform)
                        .TransformDimensionToValue((double[])result);
                }
            }
            return result;
        }

        public double TransformToValue(object value) 
        {
            return (double)Transform(value);
        }

        public double[] TransformToDimension(object value)
        {
            return (double[])Transform(value);
        }
    }
}