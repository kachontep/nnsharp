namespace NNSharp
{
    public interface ISupervisedLearning
    {
        // Synchronous training.
        void Run(double[][] data, double[][] target);
        // Asynchronous training.
        void Run(double[] data, double[] target);
        // Normal running.
        void Run(double[] data);
    }
}