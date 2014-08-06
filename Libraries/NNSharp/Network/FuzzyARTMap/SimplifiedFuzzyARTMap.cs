using System;

namespace NNSharp
{
    public class SimplifiedFuzzyARTMap : ISupervisedLearning
    {
        private double[] output;

        private bool training;

        private NeuronLayer map;

        private SimplifiedFuzzyART artA;

        private SimplifiedFuzzyART artB;

        private double Vigilance;

        public double Beta;

        public double BasedVigilanceA;

        public double BasedVigilanceB;

        public bool FastCommitedSlowLearningOption = true;

        public SimplifiedFuzzyARTMap(int inputSizeA, int inputSizeB,
            double artABasedVigilance, double artAChoiceValue, double artABeta)
        {
            this.map = new NeuronLayer();
            this.Beta = 1.0;
            this.artA = new SimplifiedFuzzyART(inputSizeA, 0.5, artAChoiceValue, false);
            this.artB = new SimplifiedFuzzyART(inputSizeB, 1.0, 0.0001, false);
            this.Vigilance = 1.0;
            this.BasedVigilanceA = artABasedVigilance;
            this.ArtA.Beta = artABeta;
            this.BasedVigilanceB = 1.0;
            this.ArtB.Beta = 1.0;
        }

        #region ISupervisedLearning Members

        public void Run(double[][] data, double[][] target)
        {
            if (data.GetUpperBound(0) != target.GetUpperBound(0))
                throw new ArgumentException("Data and target are different dimension.");

            for (int i = 0; i <= data.GetUpperBound(0); i++)
                Run(data[i], target[i]);
        }

        public void Run(double[] data, double[] target)
        {
            training = true;
            // Increment into FuzzyART A
            ArtA.Vigilance = BasedVigilanceA;
            ArtA.Run(data);
            // Increment into FuzzyART B
            ArtB.Vigilance = BasedVigilanceB;
            ArtB.Run(target);
            Process();
        }

        public void Run(double[] data)
        {
            training = false;
            // Increment into FuzzyART A
            artA.Vigilance = BasedVigilanceA;
            artA.Run(data);
            Process();
        }

        #endregion

        private void Process()
        {
            bool isSuccess = false;
            while (!isSuccess)
            {
                // Select target weight
                int winnerNeuronIndex = ArtA.WinningNeuronPos;

                Neuron weightNeuron = null;
                if (winnerNeuronIndex >= Map.Count)
                {
                    // Create new weight neuron in mapfield.
                    weightNeuron = Map.Neurons(
                        Map.AddNeuron(FuzzyLogicUtil.MakeDummyNeuron(ArtB.InputSize)));
                }
                else
                {
                    weightNeuron = Map.Neurons(winnerNeuronIndex);
                }

                if (training)
                {
                    // Check vigilance condition
                    double[] artBValues = artB.Output;
                    weightNeuron.Input(artBValues);
                    double normOfSimilarity = weightNeuron.Output();
                    double testVigilance = normOfSimilarity / FuzzyLogicUtil.Norm(artBValues);
                    if (testVigilance >= Vigilance)
                    {
                        output = FuzzyLogicUtil.Intersect(weightNeuron.Weights.ToArray(), artBValues, ArtB.InputSize);

                        // Modify new mapfield weight.
                        for (int i = 0; i < weightNeuron.Weights.Count; ++i)
                        {
                            weightNeuron.Weights[i] = (Beta * output[i]) + ((1 - Beta) * weightNeuron.Weights[i]);
                        }

                        // Call ArtA to adjust its winner neuron weight.
                        bool isWeightAdjusted = false;
                        if (FastCommitedSlowLearningOption)
                        {
                            if (IsUnCommited(ArtA.F2.Neurons(ArtA.WinningNeuronPos)))
                            {
                                double beta = ArtA.Beta;
                                ArtA.Beta = 1.0;
                                artA.AdjustWeight();
                                ArtA.Beta = beta;
                                isWeightAdjusted = true;
                            }
                        }
                        if (!isWeightAdjusted)
                            ArtA.AdjustWeight();

                        // Call ArtB to adjust its winner neuron weight.
                        ArtB.AdjustWeight();

                        isSuccess = true;
                    }
                    else
                    {
                        double newVigilance = ArtA.WinningVigilance + ArtA.Choice;
                        ArtA.Vigilance = newVigilance > 1 ? 1.0 : newVigilance;
                        ArtA.Reset(winnerNeuronIndex);
                    }
                }
                else
                {
                    output = weightNeuron.Weights.ToArray();
                    isSuccess = true;
                }
            }
            training = false;
        }

        bool IsUnCommited(Neuron neuron)
        {
            bool isUnCommited = true;
            if (neuron != null)
            {
                for (int i = 0; i < neuron.Weights.Count; i++)
                {
                    if (neuron.Weights[i] != 1)
                    {
                        isUnCommited = false;
                    }
                }
            }
            return isUnCommited;
        }

        public double[] Output
        {
            get { return output; }
        }

        public NeuronLayer Map
        {
            get { return map; }
        }

        public SimplifiedFuzzyART ArtA
        {
            get { return artA; }
        }

        public SimplifiedFuzzyART ArtB
        {
            get { return artB; }
        }
    }
}