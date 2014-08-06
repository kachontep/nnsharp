using System;

namespace NNSharp
{
    public interface IDataDimensionTransform : IDataTransform
    {
        double[] TransformDimension(double[] value);
    }
}