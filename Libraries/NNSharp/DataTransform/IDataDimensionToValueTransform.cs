using System;

namespace NNSharp
{
    public interface IDataDimensionToValueTransform : IDataTransform
    {
        double TransformDimensionToValue(double[] values);
    }
}