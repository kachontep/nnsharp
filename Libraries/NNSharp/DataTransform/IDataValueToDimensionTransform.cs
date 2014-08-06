namespace NNSharp
{
    public interface IDataValueToDimensionTransform : IDataTransform
    {
        double[] TransformValueToDimension(double value);
    }
}