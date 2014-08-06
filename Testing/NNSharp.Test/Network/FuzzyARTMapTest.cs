using System;

using NUnit.Framework;

using NNSharp;

namespace NNSharp.Test
{
    [TestFixture]
    public class FuzzyARTMapTest
    {
        private const int INPUT_SIZE = 4;
        private const int TARGET_SIZE = 2;
        private const double ART_A_BASED_VIGILANCE = 0.5;
        private const double ART_A_CHOICE_VALUE = 0.001;
        private const double ART_A_BETA = 0.8;

        private SimplifiedFuzzyARTMap fuzzy;
        private double[][] train;
        private double[][] target;
        private double[] input;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            train = new double[4][] ;
            train[0] = new double[] { 0.9429, 0.0571, 0.0571, 0.9429 };
            train[1] = new double[] { 0.8286, 0.1429, 0.1714, 0.8571 };
            train[2] = new double[] { 0.9143, 0.0, 0.0857, 1.0 };
            train[3] = new double[] { 0.8857, 0.0286, 0.1143, 0.9714 };

            target = new double[4][];
            target[0] = new double[] { 1, 0 };
            target[1] = new double[] { 0, 1 };
            target[2] = new double[] { 1, 0 };
            target[3] = new double[] { 0, 1 };
            
            input = new double[] { 0.8857, 0.1429, 0.1143, 0.8571 };
        }

        [SetUp]
        public void SetUp()
        {
            fuzzy = new SimplifiedFuzzyARTMap(INPUT_SIZE, TARGET_SIZE,
                ART_A_BASED_VIGILANCE, ART_A_CHOICE_VALUE, ART_A_BETA);
        }

        [TearDown]
        public void TearDown()
        {
            fuzzy = null;
        }

        [Test]
        public void TestTrainAndInput()
        {
            double[] expect = new double[] { 1, 0 };

            fuzzy.FastCommitedSlowLearningOption = false;
            fuzzy.Run(train[0], target[0]);
            fuzzy.Run(train[1], target[1]);
            fuzzy.Run(train[2], target[2]);
            fuzzy.Run(train[3], target[3]);
            fuzzy.Run(input);

            double[] output = fuzzy.Output;
            Validate(expect, output);
        }

        private void Validate(double[] expect, double[] output)
        {
            if (expect.Length != output.Length)
                Assert.Fail("Dimension are different");

            for(int i = 0; i < expect.Length; i++)
            {
                if( expect[i] != output[i])
                {
                    Assert.Fail("elements at position " + i + " are different value. [ expect : " +
                        expect[i] + ", output : " + output[i] + " ]");
                }
            }
        }
    }
}