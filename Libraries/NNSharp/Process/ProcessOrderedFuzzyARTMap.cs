using System;
using System.Collections.Generic;

namespace NNSharp
{
    public class ProcessOrderedFuzzyARTMap
    {
        DataSetReader trainingData, testData;

        DataSetWriter outputData;

        DataTransformChain[] inputTransformers1;

        DataTransformChain targetTransform;

        DataTransformChain inputTransformers2;

        DataTransformChain outputTransformers;

        OrderedFuzzyARTMap network;

        List<double[]> oldArtAWeights;

        ProcessOrderedFuzzyARTMapParameter parameter;

        ProcessPerformanceCounter performanceCounter;

        MaxMinAnalyzer analyzer;

        public ProcessOrderedFuzzyARTMap()
        {
        }

        public ProcessOrderedFuzzyARTMap(int inputSize, int targetSize, int noOfClases, int noOfClusters, double basedVigilance, 
            double beta, double mse)
        {
            ProcessOrderedFuzzyARTMapParameter parameter =
                new ProcessOrderedFuzzyARTMapParameter();

            parameter.InputSize = inputSize;
            parameter.TargetSize = targetSize;
            parameter.NoOfClasses = noOfClases;
            parameter.NoOfClusters = noOfClusters;
            parameter.ArtABasedVigilance = basedVigilance;
            parameter.ArtABeta = beta;
            parameter.LimitedMseValue = mse;

            this.Parameter = parameter;
        }

        public ProcessOrderedFuzzyARTMap(
            ProcessOrderedFuzzyARTMapParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("Parameter mustn't be null.");
            }
            this.Parameter = parameter;
        }

        void Initialize()
        {
            performanceCounter = new ProcessPerformanceCounter();

            // Create fuzzy art map network.
            SimplifiedFuzzyARTMap simplifiedFuzzyARTMap = new SimplifiedFuzzyARTMap(Parameter.InputSize * 2, 
                Parameter.NoOfClasses * 2, Parameter.ArtABasedVigilance, Parameter.ChoicingParam, Parameter.ArtABeta);
            simplifiedFuzzyARTMap.FastCommitedSlowLearningOption = true;

            // Create ordered fuzzy art map network
            network = new OrderedFuzzyARTMap(simplifiedFuzzyARTMap, Parameter.NoOfClusters);

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
            DataSetReader reader = new DataSetReader(Parameter.TrainingFile, 
                Parameter.InputSize, Parameter.TargetSize);
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
            for (int i = 0; i < network.FuzzyARTMap.ArtA.F2.Count; i++)
            {
                double[] weight = new double[Parameter.InputSize];
                for (int j = 0; j < Parameter.InputSize; j++)
                {
                    weight[j] = network.FuzzyARTMap.ArtA.F2.Neurons(i).Weights[j];
                }
                oldArtAWeights.Add(weight);
            }
        }

        double CalculateMse()
        {
            double mse = 0, distance = 0;
            for (int i = 0; i < network.FuzzyARTMap.ArtA.F2.Count; i++)
            {
                distance = 0;
                for(int j = 0; j < Parameter.InputSize; j++) 
                {
                    if (i >= oldArtAWeights.Count)
                       distance += Math.Pow(network.FuzzyARTMap.ArtA.F2.Neurons(i).Weights[j], 2);
                    else
                       distance += Math.Pow(network.FuzzyARTMap.ArtA.F2.Neurons(i).Weights[j] -
                            oldArtAWeights[i][j], 2);
                }
                mse += distance;
            }
            mse /= network.FuzzyARTMap.ArtA.F2.Count;
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
            // Read all training data and transforming them.
            trainingData = new DataSetReader(Parameter.TrainingFile,
                Parameter.InputSize, Parameter.TargetSize);
            double[][] data, target;
            trainingData.ReadAll(out data, out target);
            for (int i = 0; i < trainingData.Count; ++i)
            {
                // transform input level 1
                for (int j = 0; j < Parameter.InputSize; ++j)
                {
                    data[i][j] = inputTransformers1[j].TransformToValue(data[i][j]);
                }
                // transform input level 2
                data[i] = inputTransformers2.TransformToDimension(data[i]);

                // transform target
                target[i] = targetTransform.TransformToDimension(target[i]);
            }

            oldArtAWeights = new List<double[]>();
            bool isWeightsChanged = true, completedLimited = false;
            do
            {
                SaveOldWeights();

                // Training ordered fuzzy art map
                network.Run(data, target);

                double mseValue = CalculateMse();
                if (mseValue < Parameter.LimitedMseValue)
                    isWeightsChanged = false;
                performanceCounter.Increment();
                if (parameter.LimitedEpochs != 0
                    && parameter.LimitedEpochs <= performanceCounter.Count)
                {
                    completedLimited = true;
                }
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
                output[0] = outputTransformers.TransformToValue(network.FuzzyARTMap.Output);
                outputData.Write(data1, output, target);

                if (Math.Round(output[0], 2) == Math.Round(target[0], 2))
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

        public OrderedFuzzyARTMap Network
        {
            get { return network; }
            set { network = value; }
        }


        public ProcessOrderedFuzzyARTMapParameter Parameter
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
