using System;
using System.Collections.Generic;

namespace NNSharp
{
    public enum ProcessModifiedHybridFuzzyARTMapMode
    {
        EXTERNAL,
        INTERNAL,
        DUAL
    }

    public class ProcessModifiedHybridFuzzyARTMap
    {
        DataSetReader trainingData, testData;

        DataSetWriter outputData;

        DataTransformChain[] inputTransformers1;

        DataTransformChain targetTransform;

        DataTransformChain inputTransformers2;

        DataTransformChain outputTransformers;

        IOrderingAlgorithms mcoa;

        SimplifiedFuzzyARTMap fartmap;

        ModifiedFuzzyARTMap mfartmap;

        List<double[]> oldArtAWeights;

        ProcessModifiedHybridFuzzyARTMapParameter param;

        ProcessPerformanceCounter performanceCounter;

        MaxMinAnalyzer analyzer;

        public ProcessModifiedHybridFuzzyARTMap()
        {
        }

        public ProcessModifiedHybridFuzzyARTMap(int inputSize, int targetSize, int numberOfClasses, double basedVigilance,
            double vigilanceAdjustRate, double weightAdjustRate, double maximumEntropy, double maximumTotalEntropy, 
            double choicingParam, double limitedMse)
        {
            ProcessModifiedHybridFuzzyARTMapParameter param =
                new ProcessModifiedHybridFuzzyARTMapParameter();

            param.InputSize = inputSize;
            param.TargetSize = targetSize;
            param.NoOfClasses = numberOfClasses;
            param.ArtABasedVigilance = basedVigilance;
            param.VigilanceAdjustRate = vigilanceAdjustRate;
            param.ArtABeta = weightAdjustRate;
            param.MaximumEntropy = maximumEntropy;
            param.MaximumTotalEntropy = maximumTotalEntropy;
            param.ChoicingParam = choicingParam;
            param.LimitedMseValue = limitedMse;
            param.Mode = ProcessModifiedHybridFuzzyARTMapMode.DUAL;

            this.Parameter = param;
        }

        public ProcessModifiedHybridFuzzyARTMap(
            ProcessModifiedHybridFuzzyARTMapParameter parameter)
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

            if (param.Mode == ProcessModifiedHybridFuzzyARTMapMode.INTERNAL ||
                    param.Mode == ProcessModifiedHybridFuzzyARTMapMode.DUAL)
            {
                mfartmap = new ModifiedFuzzyARTMap(param.InputSize, param.NoOfClasses, param.ChoicingParam,
                    param.ArtABasedVigilance, param.MaximumEntropy, param.MaximumTotalEntropy, param.VigilanceAdjustRate, param.ArtABeta);
            }
            else
            {
                fartmap = new SimplifiedFuzzyARTMap(2*param.InputSize, 2*param.NoOfClasses, param.ArtABasedVigilance, 
                    param.ChoicingParam, param.ArtABeta);
            }

            if (param.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL ||
                    param.Mode == ProcessModifiedHybridFuzzyARTMapMode.DUAL)
            {
                mcoa = new ModifiedClusteringOrderingAlgorithms(param.NoOfClasses);
            }

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

            if (param.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL)
            {
                for (int i = 0; i < fartmap.ArtA.F2.Count; ++i)
                {
                    double[] weight = new double[2 * Parameter.InputSize];
                    for (int j = 0; j < 2 * Parameter.InputSize; ++j)
                    {
                        weight[j] = fartmap.ArtA.F2.Neurons(i).Weights[j];
                    }
                    oldArtAWeights.Add(weight);
                }
            }
            else
            {
                for (int i = 0; i <= mfartmap.Categories.GetUpperBound(0); i++)
                {
                    double[] weight = new double[2 * Parameter.InputSize];
                    for (int j = 0; j < 2 * Parameter.InputSize; j++)
                    {
                        weight[j] = mfartmap.Categories[i][j];
                    }
                    oldArtAWeights.Add(weight);
                }
            }
        }

        double CalculateMse()
        {
            double mse = 0, distance = 0;

            if (param.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL)
            {
                for (int i = 0; i < fartmap.ArtA.F2.Count; i++)
                {
                    distance = 0;
                    for (int j = 0; j < 2 * Parameter.InputSize; j++)
                    {
                        if (i >= oldArtAWeights.Count)
                            distance += Math.Pow(fartmap.ArtA.F2.Neurons(i).Weights[j], 2);
                        else
                            distance += Math.Pow(fartmap.ArtA.F2.Neurons(i).Weights[j] -
                                 oldArtAWeights[i][j], 2);
                    }
                    mse += distance;
                }
                mse /= fartmap.ArtA.F2.Count;
            }
            else
            {
                for (int i = 0; i <= mfartmap.Categories.GetUpperBound(0); i++)
                {
                    distance = 0;
                    for (int j = 0; j < 2 * Parameter.InputSize; j++)
                    {
                        if (i >= oldArtAWeights.Count)
                            distance += Math.Pow(mfartmap.Categories[i][j], 2);
                        else
                            distance += Math.Pow(mfartmap.Categories[i][j] -
                                 oldArtAWeights[i][j], 2);
                    }
                    mse += distance;
                }
                mse /= mfartmap.NumberOfCategories;
            }
 
            return mse;
        }

        public virtual void InitializeInputDataTransform(DataTransformChain[] inputTransformers, int inputSize)
        {
            // Normalize all input columns
            for (int i = 0; i < Parameter.InputSize; i++)
            {
                inputTransformers[i] = new DataTransformChain();
                if (!param.NormalizedValue)
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

            // Order input and target pattern before.
            if (param.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL ||
                    param.Mode == ProcessModifiedHybridFuzzyARTMapMode.DUAL)
            {
                mcoa.OrderSequence(data, target);
            }
            do
            {
                SaveOldWeights();

                // Training ordered fuzzy art map
                if (param.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL)
                {
                    fartmap.Run(data, target);
                }
                else
                {
                    mfartmap.Run(data, target);
                }

                double mseValue = CalculateMse();
                if (mseValue < Parameter.LimitedMseValue)
                {
                    isWeightsChanged = false;
                }

                performanceCounter.Increment();

                if (param.LimitedEpochs != 0
                    && param.LimitedEpochs <= performanceCounter.Count)
                {
                    completedLimited = true;
                }
            }
            while (!completedLimited && isWeightsChanged);
        }

        public void Test()
        {
         
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

                if (Parameter.Mode == ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL)
                {
                    fartmap.Run(dataInput);
                    output[0] = outputTransformers.TransformToValue(fartmap.Output);
                }
                else
                {
                    mfartmap.Run(dataInput);
                    output[0] = outputTransformers.TransformToValue(mfartmap.Output);
                }
                outputData.Write(data1, output, target);

                if (((int)output[0]) != 0)
                {
                    if (((int)output[0]) == ((int)target[0]))
                        performanceCounter.RightIncrement();
                    else
                        performanceCounter.WrongIncrement();
                }
                else
                {

                    performanceCounter.NonPredictIncrement();
                }
            }
            outputData.Close();
        }

        void Report()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Total            Data : " + performanceCounter.Total + " items");
            Console.WriteLine("Right prediction data : " + performanceCounter.Right + " items");
            Console.WriteLine("Wrong prediction data : " + performanceCounter.Wrong + " items");
            Console.WriteLine("Non prediction data : " + performanceCounter.NonPredict + " items");
            Console.WriteLine("Based Vigilance       : " + param.ArtABasedVigilance);
            Console.WriteLine("Weight Adjust Rate    : " + param.ArtABeta);
            Console.WriteLine("Vigilance Adjust Rate : " + param.VigilanceAdjustRate);

            if (Parameter.Mode != ProcessModifiedHybridFuzzyARTMapMode.EXTERNAL)
            {
                Console.WriteLine("Number of Categories     : " + (mfartmap.Categories.GetUpperBound(0) + 1));
            }
            else
            {
                Console.WriteLine("Number of Categories     : " + (fartmap.ArtA.F2.Count));
            }

            Console.WriteLine("Maximum Entropy       : " + param.MaximumEntropy);
            Console.WriteLine("Maximum Total Entropy : " + param.MaximumTotalEntropy);
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

        public ModifiedFuzzyARTMap MArtMap
        {
            get { return mfartmap; }
        }

        public SimplifiedFuzzyARTMap FArtMap
        {
            get { return fartmap; }
        }

        public ProcessModifiedHybridFuzzyARTMapParameter Parameter
        {
            get { return param; }
            set { param = value; Initialize(); }
        }

        public ProcessPerformanceCounter Performance
        {
            get { return performanceCounter; }
        }
    }
}