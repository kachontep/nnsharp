using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class NeuronLayerTest
    {
        private const int NEURON_SIZE = 4;

        private NeuronLayer layer1, layer2;

        [SetUp]
        public void SetUp()
        {
            layer2 = new NeuronLayer();
            layer1 = new NeuronLayer(layer2);

            double[,] weights1 = new double[,] { { 1, 1,1 ,1 }, { 1, 1, 1, 1 },
                                      {1, 1, 1, 1}, { 1, 1, 1, 1}};
            double[,] weights2 = new double[,]{ { 1, 1, 1,1 }, { 1, 1, 1, 1 },
                                      {1, 1, 1, 1}, { 1, 1, 1, 1}};
                            
            for (int i = 0; i < NEURON_SIZE; i++)
            {
                Neuron neuron1 = new Neuron(LinearFunction.Instance);
                for(int j = 0; j <= weights1.GetUpperBound(0); j++)
                    neuron1.Weights.Add(weights1[i,j]);
                layer1.AddNeuron(neuron1);

                Neuron neuron2 = new Neuron(LinearFunction.Instance);
                for (int j = 0; j <= weights2.GetUpperBound(0); j++)
                    neuron2.Weights.Add(weights2[i,j]);
                layer2.AddNeuron(neuron2);
            }
        }

        [Test]
        public void TestInputNeuron()
        {
            double[] input = { 0.25, 0.25, 0.25, 0.25 };
            double[] expect = { 1, 0, 1, 0 };

            layer1.Input(0, input);
            layer1.Input(2, input);
            double[] output = layer1.Output();

            Validate(expect, output);
        }

        [Test]
        public void TestInputNeurons()
        {
            double[] input = { 0.25, 0.25, 0.25, 0.25 };
            double[] expect = { 1, 1, 1, 1 };

            layer1.Input(input);
            double[] output = layer1.Output();

            Validate(expect, output);
        }

        [Test]
        public void TestInputNeuronLink()
        {
            double[] input = { 0.25, 0.25, 0.25, 0.25 };
            double[] expect = { 4, 4, 4, 4 };

            layer1.Input(input);
            double[] output =layer2.Output();

            Validate(expect, output);
        }

        private  void Validate(double[] expect, double[] output)
        {
            Assert.AreEqual(expect.Length, output.Length, "Output and expect have different dimension.");
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(expect[i], output[i],
                    "Value mismatch at i = " + i);
            }
        }
    }
}