using System;
using System.Collections.Generic;

namespace NNSharp
{
    [Serializable]
    public class Neuron
    {
        private double netValue;
        private List<double> weights;
        private IActivationFunction transferFunc;
        private IWeightInputOperation operateFunc;

        public Neuron(IActivationFunction transferFunc, IWeightInputOperation operateFunc)
        {
            this.transferFunc = transferFunc;
            this.operateFunc = operateFunc;
            this.weights = new List<double>();
        }

        public Neuron(IActivationFunction transferFunc)
            : this(transferFunc, MultiplyOperationFunction.Instance)
        {
        }

        public void Input(double[] values)
        {
            if (weights.Count != values.Length)
                throw new ArgumentException("Values dimension isn't equal to Weights dimension.( weights : "
                    + weights.Count + ", values : " + values.Length + " )");

            this.NetValue = 0;
            for (int i = 0; i < Weights.Count; ++i)
                NetValue += operateFunc.Operate(weights[i], values[i]);
        }

        public double Output()
        {
            return transferFunc.Activate(NetValue);
        }

        public double NetValue
        {
            get { return netValue; }
            private set { netValue = value; }
        }

        public List<double> Weights
        {
            get { return weights; }
            set { weights = value; }
        }

    }
}