namespace NNSharp
{
    public abstract class ProcessBaseParameter
    {
        private int noOfClasses;

        private int inputSize, targetSize, limitedEpochs;

        private string trainginFile, testingFile, outputFile;

        private double limitedMseValue;

        private bool normalizedValue;

        #region Default Constants
        protected const string DEFAULT_TRAINING_FILE = "dataTraining.txt";

        protected const string DEFAULT_TESTING_FILE = "dataTesting.txt";

        protected const string DEFAULT_OUTPUT_FILE = "dataOutput.txt";
        #endregion

        public int InputSize
        {
            get { return inputSize; }
            set { inputSize = value; }
        }

        public int TargetSize
        {
            get { return targetSize; }
            set { targetSize = value; }
        }

        public string TrainingFile
        {
            get { return trainginFile == null ? DEFAULT_TRAINING_FILE : trainginFile; }
            set { trainginFile = value; }
        }

        public string TestingFile
        {
            get { return testingFile == null ? DEFAULT_TESTING_FILE : testingFile; }
            set { testingFile = value; }
        }

        public string OutputFile
        {
            get { return outputFile == null ? DEFAULT_OUTPUT_FILE : outputFile; }
            set { outputFile = value; }
        }

        public double LimitedMseValue
        {
            get { return limitedMseValue; }
            set { limitedMseValue = value; }
        }

        public int LimitedEpochs
        {
            get { return limitedEpochs; }
            set { limitedEpochs = value; }
        }

        public bool NormalizedValue
        {
            get { return normalizedValue; }
            set { normalizedValue = value; }
        }

        public int NoOfClasses
        {
            get { return noOfClasses; }
            set { noOfClasses = value; }
        }
    }
}