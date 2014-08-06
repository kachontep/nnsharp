using System;

namespace NNSharp
{
    public class EntropyStatsAlgorithms : BaseStatsAlgorithms
    {
        public EntropyStatsAlgorithms(ModifiedMapField mm) : base(mm)
        {
        }

        public override double Compute(int category)
        {
            double probCategory = MapField.Sums[category]/MapField.Total;
            double sumEntropy = 0;
            for(int i = 0; i < MapField.NumberOfClasses; ++i)
            {
                if (MapField.Stats[category][i] != 0 &&MapField.Sums[category] != 0)
                {
                    double probClass = MapField.Stats[category][i]/MapField.Sums[category];
                    if (probClass != 0)
                    {
                        sumEntropy += probClass*Math.Log(probClass, 2);
                    }
                }
            }
            return -1*probCategory*sumEntropy;
        }
    }
}