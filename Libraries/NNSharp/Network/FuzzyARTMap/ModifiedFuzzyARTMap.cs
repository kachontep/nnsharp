using System;

namespace NNSharp
{
    public class ModifiedFuzzyARTMap : ISupervisedLearning
    {
        private readonly double[] NONPREDICT_OUTPUT;

        private ModifiedMapField mm;

        private EntropyStatsAlgorithms esa;

        private DataTransformChain tf;

        private DataTransformChain rtf;

        private int inputSize;

        public int InputSize
        {
            get { return inputSize; }
            set { inputSize = value; }
        }

        private int targetSize;

        public int TargetSize
        {
            get { return targetSize;}
            set { targetSize = value; }
        }

        private double[] vigilances;

        public double[] Vigilances
        {
            get { return vigilances; }
        }

        private double choicingParam;

        public double ChoicingParam
        {
            get { return choicingParam; }
            set { choicingParam = value; }
        }

        private double basedVigilance;

        public double BasedVigilance
        {
            get { return basedVigilance; }
            set { basedVigilance = value; }
        }

        private double vigilanceAdjustRate;

        public double VigilanceAdjustRate
        {
            get { return vigilanceAdjustRate; }
            set { vigilanceAdjustRate = value; }
        }

        private double weightAdjustRate;

        public double WeightAdjustRate
        {
            get { return weightAdjustRate; }
            set { weightAdjustRate = value; }
        }

        private double maximumEntropy;

        public double MaximumEntropy
        {
            get { return maximumEntropy; }
            set { maximumEntropy = value; }
        }

        private double maximumTotalEntropy;

        public double MaximumTotalEntropy
        {
            get { return maximumTotalEntropy; }    
            set { maximumTotalEntropy = value; }
        }

        private double[][] categories;

        public double[][] Categories
        {
            get { return categories; }
        }

        private int[] categoryTargetClasses;

        public int[] CategoryTargetClasses
        {
            get { return categoryTargetClasses; }
        }

        private int numberOfCategories;

        public int NumberOfCategories
        {
            get { return numberOfCategories; }
        }

        private int numberOfClasses;

        public int NumberOfClasses
        {
            get { return numberOfClasses; }
            set { numberOfClasses = value; }
        }

        private double[] input;

        public double[] Input
        {
            get { return input; }
        }
        
        private double[] output;

        public double[] Output
        {
            get { return output; }
        }

        private double[] target;

        private string mode;

        public ModifiedFuzzyARTMap(int inputSize, int numberOfClasses, 
            double choicingParam, double basedVigilance, double maximumEntropy,
            double maximumTotalEntropy, double vigilanceAdjustRate, double weightAdjustRate)
        {
            mm = new ModifiedMapField(numberOfClasses);
            esa = new EntropyStatsAlgorithms(mm);

            tf = new DataTransformChain();
            tf.AppendDataTransform(new OneOfNDataTransform(numberOfClasses));
            tf.AppendDataTransform(new ComplementDataTransform(1.0));

            rtf = new DataTransformChain();
            rtf.AppendDataTransform(new UnComplementDataTransform());
            rtf.AppendDataTransform(new ReverseOneOfNDataTransform(numberOfClasses));

            this.inputSize = inputSize;
            this.targetSize = numberOfClasses*2;
            this.numberOfClasses = numberOfClasses;
            this.choicingParam = choicingParam;
            this.basedVigilance = basedVigilance;
            this.MaximumEntropy = maximumEntropy;
            this.maximumTotalEntropy = maximumTotalEntropy;
            this.vigilanceAdjustRate = vigilanceAdjustRate;
            this.weightAdjustRate = weightAdjustRate;

            vigilances = new double[0];
            categoryTargetClasses = new int[0];
            categories = new double[0][];

            // Create unprediction output 
            NONPREDICT_OUTPUT = new double[targetSize];
        }

        private void Process()
        {
            double[] choicingValues = ComputeChoicingValues(input,
                    categories, numberOfCategories, choicingParam); ;

            int targetClass = 0;
            if (mode == "TRAIN")
            {
                targetClass = (int) rtf.TransformToValue(target);
            }

            int category = 0;
            bool nonprediction = false;
            bool uncommited = false;
            bool testVigilance = false;
            while(!testVigilance)
            {
                category = MaxChoicingValues(choicingValues);

                if (mode == "TRAIN")
                {
                    if (category != -1)
                    {
                        double vigilance = ComputeVigilance(input, categories[category]);
                        if (vigilance >= vigilances[category])
                        {
                            mm.Increment(category, targetClass);
                            double entropy = esa.Compute(category);

                            if (entropy > maximumEntropy)
                            {
                                mm.Decrement(category, targetClass);
                                choicingValues[category] = 0;
                            }
                            else
                            {
                                testVigilance = true;   
                            }
                        }
                        else
                        {
                            choicingValues[category] = 0;
                        }
                    }
                    else
                    {
                        category = NewCategory();
                        mm.Increment(category, targetClass);
                        uncommited = true;
                        testVigilance = true;
                    }
                }

                if (mode == "TEST")
                {
                    if (category != -1)
                    {
                        double vigilance = ComputeVigilance(input, categories[category]);
                        if (vigilance < vigilances[category])
                        {
                            choicingValues[category] = 0;
                        }
                    }
                    else
                    {
                        nonprediction = true;
                    }
                    testVigilance = true;
                }
            }

            if (mode == "TRAIN")
            {
                AdjustWeight(input, category, weightAdjustRate, uncommited);
            }
            
            if (mode == "TEST")
            {
                if (!nonprediction)
                {
                    bool success = false;
                    if (categoryTargetClasses != null)
                    {
                        if (category >= 0 && category < numberOfCategories)
                        {
                            output = tf.TransformToDimension(new double[] {categoryTargetClasses[category]});
                            success = true;
                        }
                    }
                    if (!success)
                    {
                        output = null;
                    }
                }
                else
                {
                    output = NONPREDICT_OUTPUT;
                }
            }
        }

        private double[] ComputeChoicingValues(double[] input, double[][] categories, 
            int numberOfCategories, double choicingParam)
        {
            double[] choicingValues = new double[numberOfCategories];
            for(int i = 0; i < numberOfCategories; ++i)
            {
                choicingValues[i] = 
                    FuzzyLogicUtil.Norm(FuzzyLogicUtil.Intersect(input, categories[i], 2*inputSize))/
                        (choicingParam + FuzzyLogicUtil.Norm(categories[i]));
            }
            return choicingValues;
        }

        private double ComputeVigilance(double[] input, double[] category)
        {
            double vigilance = FuzzyLogicUtil.Norm(FuzzyLogicUtil.Intersect(input, category, 2*inputSize))
                /FuzzyLogicUtil.Norm(input);
            return vigilance;
        }

        private int MaxChoicingValues(double[] choicingValues)
        {
            int maxCategory = -1;
            double maxValue = 0;
            for(int i = 0; i <= choicingValues.GetUpperBound(0); ++i)
            {
                if ( choicingValues[i] > maxValue)
                {
                    maxCategory = i;
                    maxValue = choicingValues[i];
                }
            }
            return maxCategory;
        }

        private int NewCategory()
        {
            double[][] newCategories = new double[numberOfCategories + 1][];
            Array.Copy(categories, 0, newCategories, 0, numberOfCategories);
            newCategories[numberOfCategories] = NewUnCommitedCategory();
            categories = newCategories;

            double[] newVigilances = new double[numberOfCategories + 1];
            Array.Copy(vigilances, 0, newVigilances, 0, numberOfCategories);
            newVigilances[numberOfCategories] = basedVigilance;
            vigilances = newVigilances;

            mm.NewCategory();

            return numberOfCategories++;
        }

        private double[] NewUnCommitedCategory()
        {
            double[] category = new double[2*inputSize];
            for(int i = 0;i < 2*inputSize; ++i)
            {
                category[i] = 1.0;
            }
            return category;
        }

        private void AdjustWeight(double[] input, int category, double weightAdjustRate, 
            bool uncommited)
        {
            for(int i = 0; i < 2*inputSize; ++i)
            {
                double oldWeight = categories[category][i], newWeight = 0;
                if (uncommited)
                {
                    newWeight = Math.Min( oldWeight, input[i]);
                }
                else
                {
                    newWeight = weightAdjustRate*Math.Min(oldWeight, input[i]) +
                                (1 - weightAdjustRate)*oldWeight;
                }
                categories[category][i] = newWeight;
            }
        }

        #region ISupervisedLearning Members

        public void Run(double[][] data, double[][] target)
        {
            mm.ClearStats();

            for(int i = 0; i <= data.GetUpperBound(0); ++i)
            {
                Run(data[i], target[i]);    
            }

            CompleteOneEpoch();
        }

        public void Run(double[] data, double[] target)
        {
            mode = "TRAIN";

            this.input = data;
            this.target = target;

            Process();
        }

        public void Run(double[] data)
        {
            mode = "TEST";

            this.input = data;
            this.target = null;

            Process();
        }

        #endregion

        public void CompleteOneEpoch()
        {
            // Adjust each vigilance of category, based on entropy.
            IncreaseCategoryVigilances();

            // Store the most population of target class into category's target class
            SaveCategoryTargetClasses();
        }

        private void IncreaseCategoryVigilances()
        {
            // Check total entropy of all categories.
            double totalEntropy = 0;
            do
            {
                // Compute total entropy.
                totalEntropy = 0;
                double[] entropies = new double[numberOfCategories];
                for (int i = 0; i < numberOfCategories; ++i)
                {
                    entropies[i] = esa.Compute(i);
                    totalEntropy += entropies[i];
                }

                if (totalEntropy > maximumTotalEntropy)
                {
                    int maxIndex = -1;
                    double maxValue = Double.MinValue;
                    for (int j = 0; j < NumberOfCategories; ++j)
                    {
                        if (entropies[j] > maxValue)
                        {
                            maxIndex = j;
                            maxValue = entropies[j];
                        }
                    }

                    if (maxIndex != -1)
                    {
                        // Reset weights and increase vigilance.
                        //for (int k = 0; k < 2 * inputSize; ++k)
                        //{
                        //    categories[maxIndex][k] = 1.0;
                        //}

                        for (int k = 0; k < numberOfClasses; ++k)
                        {
                            mm.Stats[maxIndex][k] = 0;
                        }
                        mm.Total -= mm.Sums[maxIndex];
                        mm.Sums[maxIndex] = 0;

                        double newVigilance = vigilances[maxIndex] + vigilanceAdjustRate;
                        vigilances[maxIndex] = (newVigilance > 1.0) ? 1.0 : newVigilance;
                    }
                }
            } while (totalEntropy > maximumTotalEntropy);
        }

        private void SaveCategoryTargetClasses()
        {
            if (categoryTargetClasses.Length < numberOfCategories)
            {
                int[] newCategoryTestClasses = new int[numberOfCategories];
                Array.Copy(categoryTargetClasses, 0, newCategoryTestClasses, 0, categoryTargetClasses.Length);
                categoryTargetClasses = newCategoryTestClasses;
            }

            for (int i = 0; i < numberOfCategories; ++i)
            {
                int targetClass = categoryTargetClasses[i];

                double maxValue = 0;
                for (int j = 1; j <= numberOfClasses; ++j)
                {
                    if (mm.Stats[i][j - 1] > maxValue)
                    {
                        targetClass = j;
                        maxValue = mm.Stats[i][j - 1];
                    }
                }

                categoryTargetClasses[i] = targetClass;
            }
        }

    }
}