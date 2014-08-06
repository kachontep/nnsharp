using System;

namespace NNSharp
{
    public static class FuzzyLogicUtil
    {
        public static Neuron MakeDummyNeuron(int inputSize)
        {
            Neuron dummy = new Neuron(LinearFunction.Instance,
                FuzzySetIntersectOperation.Instance);
            for (int i = 0; i < inputSize; i++)
                dummy.Weights.Add(1.0);
            return dummy;
        }

        public static double Norm(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return sum;
        }

        public static double[] Intersect(double[] value1, double[] value2, int length)
        {
            double[] values = new double[length];
            for (int i = 0; i < length; ++i)
                values[i] = Math.Min(value1[i], value2[i]);
            return values;
        }

        public static double ChoicingValue(double neuronOutput, double normOfWeight, double choiceParam)
        {
            return (neuronOutput / (normOfWeight + choiceParam));
        }

        public static int FindMax(double[] values)
        {
            int maxIndex = -1;
            double maxValue = 0;
            for (int i = 0; i < values.Length; ++i)
            {
                if (maxValue < values[i])
                {
                    maxIndex = i;
                    maxValue = values[i];
                }
            }
            return maxIndex;
        }

        public static void PrintNeuronLayerWeights(string name, NeuronLayer layer)
        {
            Console.WriteLine(name);
            foreach (Neuron neuron in layer)
            {
                ArraysUtil<double>.Print(neuron.Weights.ToArray());
            }
        }
    }
}