using System;
using System.Collections.Generic;
using System.IO;

namespace NNSharp
{
    public class ProcessSimplifiedFuzzyARTMap
    {
        DataSetReader trainingData, testData;

        DataSetWriter outputData;

        DataTransformChain[] inputTransformers1;

        DataTransformChain targetTransform;

        DataTransformChain inputTransformers2;

        DataTransformChain outputTransformers;

        SimplifiedFuzzyARTMap network;

        List<double[]> oldArtAWeights;

        ProcessSimplifiedFuzzyARTMapParameter parameter;

        ProcessPerformanceCounter performanceCounter;

        MaxMinAnalyzer analyzer;


        public ProcessSimplifiedFuzzyARTMap()
        {
        }

        public ProcessSimplifiedFuzzyARTMap(int inputSize, int targetSize, int noOfClases, double basedVigilance, double choiceValue,
            double beta, double mse, int epochs)
        {
            ProcessSimplifiedFuzzyARTMapParameter parameter =
                new ProcessSimplifiedFuzzyARTMapParameter();

            parameter.InputSize = inputSize;
            parameter.TargetSize = targetSize;
            parameter.NoOfClasses = noOfClases;
            parameter.ArtABasedVigilance = basedVigilance;
            parameter.ChoicingParam = choiceValue;
            parameter.ArtABeta = beta;
            parameter.LimitedMseValue = mse;
            parameter.LimitedEpochs = epochs;

            this.Parameter = parameter;
        }

        public ProcessSimplifiedFuzzyARTMap(
            ProcessSimplifiedFuzzyARTMapParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter mustn't be null.");
            }
            this.Parameter = parameter;
        }

        void Initialize()
        {
            performanceCounter = new ProcessPerformanceCounter();

            // Create fuzzy art map network.
            network = new SimplifiedFuzzyARTMap(Parameter.InputSize * 2,
                Parameter.NoOfClasses * 2, Parameter.ArtABasedVigilance, Parameter.ChoicingParam, Parameter.ArtABeta);
            network.FastCommitedSlowLearningOption = true;

            // Analyze max-min of input columns
            AnalyzeMaxMin();

            // Initialize inputtransformers level 1
            inputTransformers1 = new DataTransformChain[Parameter.InputSize];
            InitializeInputDataTransform(inputTransformers1, Parameter.InputSize);

            // inputtransformation level 2
            inputTransformers2 = new DataTransformChain();
            inputTransformers2.AppendDataTransform(new ComplementDataTransform(1.0));

            // Target column 
            targetTransform = new DataTransformChain();
            targetTransform.AppendDataTransform(new OneOfNDataTransform(Parameter.NoOfClasses));
            targetTransform.AppendDataTransform(new ComplementDataTransform(1.0));

            // Output transform 
            outputTransformers = new DataTransformChain();
            outputTransformers.AppendDataTransform(new UnComplementDataTransform());
            outputTransformers.AppendDataTransform(new ReverseOneOfNDataTransform(Parameter.NoOfClasses));
        }

        void AnalyzeMaxMin()
        {
            // Find max-min value for each column
            analyzer = new MaxMinAnalyzer(Parameter.InputSize);
            double[] input = new double[Parameter.InputSize];
            DataSetReader reader = null;
            if (File.Exists(Parameter.TrainingFile))
            {
                reader = new DataSetReader(Parameter.TrainingFile,
                    Parameter.InputSize, Parameter.TargetSize);
            }
            else if (File.Exists(Parameter.TestingFile))
            {
                reader = new DataSetReader(Parameter.TestingFile,
                    parameter.InputSize, Parameter.TargetSize);
            }

            if (reader == null)
                throw new ArgumentException("Process must have a trainging file or testing file.");

            // Analyze training file.
            while (reader.Read(input, null))
            {
                for (int i = 0; i < Parameter.InputSize; i++)
                    analyzer.AnalyzeValue(i, input[i]);
            }
            // Analyze testing file.
            reader = new DataSetReader(Parameter.TestingFile, Parameter.InputSize, Parameter.TargetSize);
            while (reader.Read(input, null))
            {
                for (int i = 0; i < Parameter.InputSize; i++)
                    analyzer.AnalyzeValue(i, input[i]);
            }
        }

        void SaveOldWeights()
        {
            oldArtAWeights.Clear();
            for (int i = 0; i < network.ArtA.F2.Count; i++)
            {
                double[] weight = new double[Parameter.InputSize];
                for (int j = 0; j < Parameter.InputSize; j++)
                {
                    weight[j] = network.ArtA.F2.Neurons(i).Weights[j];
                }
                oldArtAWeights.Add(weight);
            }
        }

        double CalculateMse()
        {
            double mse = 0, distance = 0;
            for (int i = 0; i < network.ArtA.F2.Count; i++)
            {
                distance = 0;
                for (int j = 0; j < Parameter.InputSize; j++)
                {
                    if (i >= oldArtAWeights.Count)
                        distance += Math.Pow(network.ArtA.F2.Neurons(i).Weights[j], 2);
                    else
                        distance += Math.Pow(network.ArtA.F2.Neurons(i).Weights[j] -
                             oldArtAWeights[i][j], 2);
                }
                mse += distance;
            }
            mse /= network.ArtA.F2.Count;
            return mse;
        }

        public virtual void InitializeInputDataTransform(DataTransformChain[] inputTransformers, int inputSize)
        {
            // Normalize all input columns
            for (int i = 0; i < Parameter.InputSize; i++)
            {
                inputTransformers[i] = new DataTransformChain();
                if (!parameter.NormalizedValue)
                {
                    inputTransformers[i].AppendDataTransform(new MinMaxDataTransform(analyzer.MinValues[i], analyzer.MaxValues[i]));
                }
            }

        }

        public void Train()
        {
            oldArtAWeights = new List<double[]>();
            bool isWeightsChanged = true, completedLimited = false;
            do
            {
                SaveOldWeights();
                trainingData = new DataSetReader(Parameter.TrainingFile,
                    Parameter.InputSize, Parameter.TargetSize);
                double[] data = new double[Parameter.InputSize];
                double[] target = new double[Parameter.TargetSize];
                while (trainingData.Read(data, target))
                {
                    // transform input level 1
                    for (int i = 0; i < Parameter.InputSize; i++)
                    {
                        data[i] = inputTransformers1[i].TransformToValue(data[i]);
                    }
                    // transform input level 2
                    double[] dataInput = inputTransformers2.TransformToDimension(data);

                    // transform target 
                    double[] targetInput = targetTransform.TransformToDimension(target);

                    network.Run(dataInput, targetInput);
                }
                double mseValue = CalculateMse();
                if (mseValue < Parameter.LimitedMseValue)
                    isWeightsChanged = false;
                performanceCounter.Increment();
                if (parameter.LimitedEpochs != 0
                    && parameter.LimitedEpochs <= performanceCounter.Count)
                    completedLimited = true;
            }
            while (!completedLimited && isWeightsChanged);
        }

        public void Test()
        {
            Performance.Reset();

            testData = new DataSetReader(Parameter.TestingFile, Parameter.InputSize,
                Parameter.TargetSize);
            outputData = new DataSetWriter(Parameter.OutputFile, false,
                Parameter.InputSize, Parameter.TargetSize);

            double[] data1 = new double[Parameter.InputSize];    // Original data from dataset file.
            double[] data2 = new double[Parameter.InputSize];    // Temporaly transformed data (from data1).
            double[] target = new double[Parameter.TargetSize];
            double[] output = new double[1];
            while (testData.Read(data1, target))
            {
                // transform input level 1
                for (int i = 0; i < Parameter.InputSize; i++)
                {
                    data2[i] = inputTransformers1[i].TransformToValue(data1[i]);
                }
                // transform input level 2
                double[] dataInput = inputTransformers2.TransformToDimension(data2);

                network.Run(dataInput);
                output[0] = outputTransformers.TransformToValue(network.Output);
                outputData.Write(data1, output, target);

                if (Math.Round(output[0], 1) == Math.Round(target[0], 1))
                    performanceCounter.RightIncrement();
                else
                    performanceCounter.WrongIncrement();
            }
            outputData.Close();
        }

        void Report()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Total            Data : " + performanceCounter.Total + " items");
            Console.WriteLine("Right prediction data : " + performanceCounter.Right + " items");
            Console.WriteLine("Wrong prediction data : " + performanceCounter.Wrong + " items");
            Console.WriteLine("Non prediction data   : " + performanceCounter.NonPredict + " items");
            Console.WriteLine("Number of Categories  : " + network.ArtA.F2.Count);
            Console.WriteLine("Based Vigilance A     : " + parameter.ArtABasedVigilance);
            Console.WriteLine("Beta A                : " + parameter.ArtABeta);
            Console.WriteLine("Traing Count          : " + performanceCounter.Count + " epochs");
            Console.WriteLine("Accuracy Percentage   : {0:0.00} %", performanceCounter.AccuracyPercentage);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public void Process()
        {
            Initialize();
            Train();
            Test();
            Report();
        }

        public SimplifiedFuzzyARTMap Network
        {
            get { return network; }
            set { network = value; }
        }


        public ProcessSimplifiedFuzzyARTMapParameter Parameter
        {
            get { return parameter; }
            set { parameter = value; Initialize();  }
        }

        public ProcessPerformanceCounter Performance
        {
            get { return performanceCounter; }
        }
    }
}
