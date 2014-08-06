namespace NNSharp
{
    public interface IUnsupervisedLearning
    {
        // Synchronous running.
        void Run(double[][] data);
        // Asynchronous running.
        void Run(double[] data);
    }
}