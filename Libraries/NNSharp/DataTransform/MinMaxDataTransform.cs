using System;

namespace NNSharp
{
    public class MinMaxDataTransform : IDataValueTransform
    {
        private double orgMin, orgMax;
        public double OriginalMin
        {
            get { return orgMin; }
            set { orgMin = value; }
        }
        public double OriginalMax
        {
            get { return orgMax; }
            set { orgMax = value; }
        }

        private double newMin, newMax;
        public double NewMin
        {
            get { return newMin; }
            set { newMin = value; }
        }
        public double NewMax
        {
            get { return newMax; }
            set { newMax = value; }
        }

        public MinMaxDataTransform(double orgMin, double orgMax,
            double newMin, double newMax)
        {
            OriginalMin = orgMin;
            OriginalMax = orgMax;
            NewMin = newMin;
            NewMax = newMax;
        }

        public MinMaxDataTransform(double orgMin, double orgMax)
            : this(orgMin, orgMax, 0.0, 1.0)
        {
        }

        #region IDataValueTransform Members

        public double TransformValue(double value)
        {
            double newValue = 0.0;
            if (OriginalMax > OriginalMin)
                newValue = ((value - OriginalMin) / (OriginalMax - OriginalMin) * (NewMax - NewMin)) + NewMin;
            return newValue;
        }

        #endregion
    }
}