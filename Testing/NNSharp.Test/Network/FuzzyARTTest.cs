using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class FuzzyARTTest
    {
        private const double VIGILANCE = 0.5;
        private const double CHOICE = 0.0001;

        private SimplifiedFuzzyART art;
        private double[][] input;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            input = new double[4][];
            input[0] = new double[] { 0.9429, 0.0571, 0.0571, 0.9429 };
            input[1] = new double[] { 0.8286, 0.1429, 0.1714, 0.8571 };
            input[2] = new double[] { 0.9143, 0, 0.0857, 1.0 };
            input[3] = new double[] { 0.8857, 0.0286, 0.1143, 0.9714 };
        }

        [SetUp]
        public void SetUp()
        {
            art = new SimplifiedFuzzyART(4, VIGILANCE, CHOICE);
            art.Beta = 0.8;
        }

        [TearDown]
        public void TearDown()
        {
            art = null;
        }

        [Test]
        public void TestOneInput()
        {
            art.Run(input[0]);
            Assert.AreEqual(1, art.F2.Count);
            Assert.AreEqual(0, art.WinningNeuronPos);
        }

        [Test]
        public void TestTwoInput()
        {
            art.Run(input[0]);
            art.Run(input[1]);
            Assert.AreEqual(0, art.WinningNeuronPos);
        }

        [Test]
        public void TestThreeInput()
        {
            art.Run(input[0]);
            art.Run(input[1]);
            art.Run(input[2]);
            Assert.AreEqual(0, art.WinningNeuronPos);
        }

        [Test]
        public void TestFourInput()
        {
            art.Run(input[0]);
            art.Run(input[1]);
            art.Run(input[2]);
            art.Run(input[3]);
            Assert.AreEqual(0, art.WinningNeuronPos);
        }
    }
}