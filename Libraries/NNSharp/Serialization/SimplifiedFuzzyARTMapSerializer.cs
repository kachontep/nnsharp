using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using NNSharp;

public class SimplifiedFuzzyARTMapSerializer
{
    public void Serialize(string filepath , SimplifiedFuzzyARTMap network)
    {
        Dictionary<String, String> props = new Dictionary<String, String>();
        props.Add("InputSizeA", network.ArtA.InputSize.ToString());
        props.Add("InputSizeB", network.ArtB.InputSize.ToString());
        props.Add("ArtAVigilance", network.BasedVigilanceA.ToString());
        props.Add("ArtAChoiceValue", network.ArtA.Choice.ToString());
        props.Add("ArtABeta", network.ArtA.Beta.ToString());

        // Write weights of neuron in f2 layer of ART-A
        props.Add("ArtANeuronSize", network.ArtA.F2.Count.ToString());
        for (int i = 1; i <= network.ArtA.F2.Count; i++)
        {
            StringBuilder sb = new StringBuilder();
            for(int j = 0; j < network.ArtA.InputSize - 1; j++)
                sb.Append(network.ArtA.F2.Neurons(i).Weights[j].ToString() + ",");
            sb.Append(network.ArtA.F2.Neurons(i).Weights[network.ArtA.InputSize-1].ToString());
            props.Add("ArtA-N-" + i.ToString(), sb.ToString());
        }

        // Write weights of neuron in f2 layer of ART-B
        props.Add("ArtBNeuronSize", network.ArtB.F2.Count.ToString());
        for (int i = 1; i <= network.ArtB.F2.Count; i++)
        {
            StringBuilder sb = new StringBuilder();
            for(int j = 0; j < network.ArtB.InputSize - 1; j++)
                sb.Append(network.ArtB.F2.Neurons(i).Weights[j].ToString() + ",");
            sb.Append(network.ArtB.F2.Neurons(i).Weights[network.ArtB.InputSize-1].ToString());
            props.Add("ArtB-N-" + i.ToString(), sb.ToString());
        }

        // Write weights of neuron in map field layer
        props.Add("MapNeuronSize", network.Map.Count.ToString());
        for (int i = 1; i <= network.Map.Count; i++)
        {
            StringBuilder sb = new StringBuilder();
            for(int j = 0; j < network.ArtB.InputSize - 1; j++)
                sb.Append(network.Map.Neurons(i).Weights[j].ToString() + ",");
            sb.Append(network.Map.Neurons(i).Weights[network.ArtB.InputSize-1].ToString());
            props.Add("Map-N-" + i.ToString(), sb.ToString());
        }

        StringBuilder data = new StringBuilder();
        foreach (string key in props.Keys)
        {
            data.Append(key + "=" + props[key] + "\n");
        }

        StreamWriter writer = new StreamWriter(filepath);
        writer.Write(data.ToString());
        writer.Close();
    }

    public SimplifiedFuzzyARTMap DeSerialize(string filepath)
    {
        StreamReader reader = new StreamReader(filepath);
        string data = reader.ReadToEnd();
        reader.Close();

        SimplifiedFuzzyARTMap network = null;

        if (data != null && data != String.Empty)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            // Insert key and value from data string.
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                string[] sections = line.Split('=');
                props.Add(sections[0], sections[1]);
            }

            int inputSizeA = Convert.ToInt32(props["InputSizeA"]);
            int inputSizeB = Convert.ToInt32(props["InputSizeB"]);
            double artABasedVigilance = Convert.ToDouble(props["ArtAVigilance"]);
            double artAChoiceValue = Convert.ToDouble(props["ArtAChoiceValue"]);
            double artABeta = Convert.ToDouble(props["ArtABeta"]);

            network = new SimplifiedFuzzyARTMap(inputSizeA, inputSizeB,
                artABasedVigilance, artAChoiceValue, artABeta);

            // Store weights of each neuron in art-a.
            int artAF2NeuronSize = Convert.ToInt32(props["ArtANeuronSize"]);
            for(int i = 1; i <= artAF2NeuronSize; i++)
            {
                string weightsStr = props["ArtA-N-" + i];
                Neuron neuron = new Neuron(LinearFunction.Instance);
                string[] weights = weightsStr.Split(',');
                for (int j = 0; j < inputSizeA; j++)
                    neuron.Weights.Add(Convert.ToDouble(weights[j]));
                network.ArtA.F2.AddNeuron(neuron);
            }

            // Store weights of each neuron in art-b.
            int artBF2NeuronSize = Convert.ToInt32(props["ArtBNeuronSize"]);
            for(int i = 1; i <= artBF2NeuronSize; i++)
            {
                string weightsStr = props["ArtB-N-" + i];
                Neuron neuron = new Neuron(LinearFunction.Instance);
                string[] weights = weightsStr.Split(',');
                for (int j = 0; j < inputSizeB; j++)
                    neuron.Weights.Add(Convert.ToDouble(weights[j]));
                network.ArtB.F2.AddNeuron(neuron);
            }

            // Store weights of each neuron in map field layer.
            int mapNeuronSize = Convert.ToInt32(props["MapNeuronSize"]);
            for (int i = 1; i <= mapNeuronSize; i++)
            {
                string weightsStr = props["Map-N-" + i];
                Neuron neuron = new Neuron(LinearFunction.Instance);
                string[] weights = weightsStr.Split(',');
                for (int j = 0; j < inputSizeB; j++)
                    neuron.Weights.Add(Convert.ToDouble(weights[j]));
                network.Map.AddNeuron(neuron);
            }
        }
        return network;
    }
}