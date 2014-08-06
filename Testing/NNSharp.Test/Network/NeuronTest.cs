using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class NeuronTest
    {
        [Test]
        public void TestInputOutput()
        {
            double[] input = { 1, 2, 3, 4, 5 };
            double[] weights = { 1, 2, 3, 4, 5 };
            double expected = 55;

            Neuron neuron = new Neuron(LinearFunction.Instance);
            for (int i = 0; i < weights.Length; i++)
                neuron.Weights.Add(weights[i]);
            
            neuron.Input(input);

            Assert.AreEqual(expected, neuron.Output());
        }
    }
}