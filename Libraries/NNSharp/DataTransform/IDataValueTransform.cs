using System;

namespace NNSharp
{
    public interface IDataValueTransform : IDataTransform
    {
        double TransformValue(double value);
    }
}