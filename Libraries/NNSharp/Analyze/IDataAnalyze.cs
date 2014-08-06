namespace NNSharp
{
    public interface IDataAnalyze
    {
        void Analyze(double[][] data);
        void AnalyzeAsync(double[] data);
    }
}