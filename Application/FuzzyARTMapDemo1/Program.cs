using System;
using System.Collections.Generic;
using System.Text;

using NNSharp;

namespace FuzzyARTMapDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessSimplifiedFuzzyARTMap processor =
            //    new ProcessSimplifiedFuzzyARTMap(13, 1, 3, 0, 0.001, 0.1, 1.0e-8, 10);

            //ProcessOrderedFuzzyARTMap processor =
            //    new ProcessOrderedFuzzyARTMap(4, 1, 3, 3, 0.00, 0.1, 1.0e-8);

            ProcessModifiedHybridFuzzyARTMap processor =
                new ProcessModifiedHybridFuzzyARTMap(13, 1, 3, 0.0, 0.01, 0.01, 0.02, 0.06, 1.0e-4, 1.0e-8);

            processor.Parameter.NormalizedValue = true;
            processor.Parameter.TrainingFile = "wine.0.tn.txt";
            processor.Parameter.TestingFile = "wine.0.ts.txt";
            processor.Parameter.LimitedEpochs = 10;

            processor.Process();
        }
    }
}
