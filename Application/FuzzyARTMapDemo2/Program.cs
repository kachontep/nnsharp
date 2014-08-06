using System;
using System.Collections.Generic;
using System.Text;

using NNSharp;

namespace FuzzyARTMapDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessSimplifiedFuzzyARTMap processor
            //    = new ProcessSimplifiedFuzzyARTMap(19, 1, 7, 0.7, 0.0001, 0.05, 1.0e-8, 1000);

            //ProcessOrderedFuzzyARTMap processor
            //    = new ProcessOrderedFuzzyARTMap(19, 1, 7, 7, 0.00, 0.05, 1.0e-8);

            ProcessModifiedHybridFuzzyARTMap processor =
                new ProcessModifiedHybridFuzzyARTMap(19, 1, 7, 0.93, 0.001, 0.05, 0.01, 0.05, 1.0e-4, 1.0e-8);
            processor.Parameter.LimitedEpochs = 100;

            processor.Process();
        }
    }
}
