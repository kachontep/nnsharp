using System;
using System.Collections.Generic;

namespace NNSharp
{
    public class SimplifiedFuzzyART : IUnsupervisedLearning
    {
        private double normOfInputs;

        private int winningNeuronPos;

        private double winningVigilance;

        private int inputSize;

        private double[] input;

        private double[] output;

        private NeuronLayer f1;

        private NeuronLayer f2;

        private List<double> choiceValues;


        public double Vigilance;

        public double Choice;

        public double Beta;

        public bool AutoAdjustWeight;

        
        public SimplifiedFuzzyART(int inputSize, double vigilance, 
            double choice, bool autoAdjustWeight)
        {
            this.inputSize = inputSize;
            Vigilance = vigilance;
            Choice = choice;
            AutoAdjustWeight = autoAdjustWeight;
            this.f2 = new NeuronLayer();
            this.f1 = new NeuronLayer(this.f2);
            choiceValues = new List<double>();

            Initialize();
        }

        public SimplifiedFuzzyART(int inputSize)
            : this(inputSize, 0.5, 0.001, true)
        {
        }

        public SimplifiedFuzzyART(int inputSize, double vigilance,
            double choice) : this(inputSize, vigilance, choice, true)
        {
        }

        private void Initialize()
        {
            for (int i = 0; i < InputSize; ++i)
            {
                Neuron neuron = new Neuron(LinearFunction.Instance);
                for (int j = 0; j < InputSize; ++j)
                {
                    if (i == j)
                        neuron.Weights.Add(1.0);
                    else
                        neuron.Weights.Add(0.0);
                }
                f1.AddNeuron(neuron);
            }
        }

        #region IUnsupervisedLearning Members

        public void Run(double[][] data)
        {
            for (int i = 0; i < data.GetUpperBound(0); ++i)
                Run(data[i]);
        }

        public void Run(double[] data)
        {
            input = data;
            // Compute norm of input values.
            normOfInputs = FuzzyLogicUtil.Norm(data);

            // Transfer input values.
            f1.Input(data);

            // Calculate initial choicing value
            ChoiceValues.Clear();
            for (int i = 0; i < f2.Count; ++i)
            {
                double normOfWeight = FuzzyLogicUtil.Norm(F2.Neurons(i).Weights.ToArray());
                ChoiceValues.Add(FuzzyLogicUtil.ChoicingValue(F2.Neurons(i).Output(), normOfWeight, Choice));
            }

            Process();
        }

        #endregion

        private void Process()
        {
            bool isSuccess = false;
            while (!isSuccess)
            {
                int max = FuzzyLogicUtil.FindMax(ChoiceValues.ToArray());
                double normOfSimilarity = 0;

                if (max != -1)
                {
                    normOfSimilarity = F2.Neurons(max).Output();
                }
                else
                {
                    // Indicate that there is no eligible neuron
                    // as winner, so create a dummy neuron in F2 layer.
                    max = F2.AddNeuron(FuzzyLogicUtil.MakeDummyNeuron(InputSize));
                    ChoiceValues.Add(
                        FuzzyLogicUtil.ChoicingValue(normOfInputs, 1.0 * InputSize, Choice));
                    normOfSimilarity = normOfInputs;
                }

                // Calculate and compare with vigilance
                winningVigilance = normOfSimilarity / normOfInputs;
                if (winningVigilance >= Vigilance)
                {
                    winningNeuronPos = max;
                    isSuccess = true;
                }
                else
                {
                    ChoiceValues[max] = 0;
                }
            }

            // Adjust neuron weight automatically. if it is set.
            if (AutoAdjustWeight)
                AdjustWeight();

            // Calculate output.
            output = FuzzyLogicUtil.Intersect(F2.Neurons(WinningNeuronPos).Weights.ToArray(),
                    InputData, InputSize);
        }

        public void AdjustWeight()
        {
            Neuron winnerNeuron = F2.Neurons(winningNeuronPos);
            double[] intersect = FuzzyLogicUtil.
                Intersect(InputData, winnerNeuron.Weights.ToArray(), InputSize);
            // Modify new art a weight.
            for (int i = 0; i < this.InputSize; ++i)
            {
                winnerNeuron.Weights[i] = (Beta * intersect[i]) + ((1 - Beta) * winnerNeuron.Weights[i]);
            }
        }

        public void Reset(int index)
        {
            ChoiceValues[index] = 0;
            Process();
        }

        public double[] Output
        {
            get
            {
                return output;
            }
        }

        public int WinningNeuronPos
        {
            get { return winningNeuronPos; }
        }

        public double WinningVigilance
        {
            get { return winningVigilance; }
        }

        public int InputSize
        {
            get { return inputSize; }
        }

        public double[] InputData
        {
            get { return input; }
        }

        public NeuronLayer F1
        {
            get { return f1; }
        }

        public NeuronLayer F2
        {
            get { return f2; }
        }

        private List<double> ChoiceValues
        {
            get { return choiceValues; }
        }

    }
}