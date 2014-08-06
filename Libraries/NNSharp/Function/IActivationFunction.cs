namespace NNSharp
{
    public interface IActivationFunction
    {
        double Activate(double value);
        double Activate1stDiff(double value);
        double Activate2ndDiff(double value);
    }
}