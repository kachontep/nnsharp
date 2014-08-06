using System;

namespace NNSharp
{
    public class ModifiedMapField
    {
        private int numberOfClasses;

        public int NumberOfClasses
        {
            get { return numberOfClasses; }
        }

        private int numberOfCategories;

        public int NumberOfCategories
        {
            get { return numberOfCategories; }
        }

        private double[][] stats;

        public double[][] Stats
        {
            get { return stats; }
        }

        private double[] sums;

        public double[] Sums
        {
            get { return sums; }   
            set { sums = value; }
        }

        private double total;
        
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public ModifiedMapField(int numberOfClasses)
        {
            this.numberOfClasses = numberOfClasses;
            this.numberOfCategories = 0;
            this.stats = new double[0][];
            this.sums = new double[0];
        }

        public void NewCategory()
        {         
            double[][] newStatsMapField = new double[numberOfCategories+1][];
            Array.Copy(stats, 0, newStatsMapField, 0, numberOfCategories);
            stats = newStatsMapField;

            double[] newSums = new double[numberOfCategories + 1];
            Array.Copy(sums, 0, newSums, 0, numberOfCategories);
            sums = newSums;

            numberOfCategories++;
        }

        public void Increment(int category, int targetClass)
        {
            if (category < 0 || category >= numberOfCategories)
            {
                throw new ArgumentException("Invalid category index.");
            }
            if (targetClass <= 0)
            {
                throw new ArgumentException("Invalid target class.");
            }
            if (stats[category] == null)
            {
                stats[category] = new double[numberOfClasses];    
            }

            ++stats[category][targetClass - 1];
            ++sums[category];
            ++total;
        }

        public void Decrement(int category, int targetClass)
        {
            if (category < 0 || category >= numberOfCategories)
            {
                throw new ArgumentException("Invalid category index.");
            }
            if (targetClass <= 0)
            {
                throw new ArgumentException("Invalid target class.");
            }

            --stats[category][targetClass - 1];
            --sums[category];
            --total;
        }

        public void ClearStats()
        {
            for(int i = 0; i < numberOfCategories; ++i)
            {
                for (int j = 0; j < numberOfClasses; ++j)
                    stats[i][j] = 0;
                sums[i] = 0;
            }
            total = 0;
        }
    }
}
