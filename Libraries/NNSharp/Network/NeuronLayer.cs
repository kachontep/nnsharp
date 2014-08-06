using System;
using System.Collections;

namespace NNSharp
{
    [Serializable]
    public class NeuronLayer : CollectionBase
    {
        private NeuronLayer link;

        public NeuronLayer()
        {
        }

        public NeuronLayer(NeuronLayer link)
        {
            this.link = link;
        }

        public int AddNeuron(Neuron neuron)
        {
            return InnerList.Add(neuron);
        }

        public void RemoveNeuron(Neuron neuron)
        {
            InnerList.Remove(neuron);
        }

        public void RemoveNeuronAt(int index)
        {
            InnerList.RemoveAt(index);
        }

        public Neuron Neurons(int index)
        {
            return (Neuron)InnerList[index];
        }

        public void Input(int targetNeuron, double[] values)
        {
            if (targetNeuron >= 0 && targetNeuron < this.Count)
            {
                this.Neurons(targetNeuron).Input(values);
            }
        }

        public void Input(double[] values)
        {
            for (int i = 0; i < this.Count; ++i)
                this.Neurons(i).Input(values);

            if (Link != null)
            {
                Link.Input(this.Output());
            }
        }

        public double[] Output()
        {
            double[] values = new double[this.Count];
            for (int i = 0; i < this.Count; ++i)
                values[i] = this.Neurons(i).Output();
            return values;
        }

        public NeuronLayer Link
        {
            get { return link; }
        }

        public new int Count
        {
            get { return InnerList.Count; }
        }
    }
}