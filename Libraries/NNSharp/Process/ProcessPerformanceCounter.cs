namespace NNSharp
{
    public class ProcessPerformanceCounter
    {
        int  count, right, wrong, np;

        public ProcessPerformanceCounter()
        {
        }

        public void RightIncrement()
        {
            ++right;
        }

        public void WrongIncrement()
        {
            ++wrong;
        }

        public void NonPredictIncrement()
        {
            ++np;    
        }

        public void Increment()
        {
            ++count;
        }

        public void Reset()
        {
            right = 0;
            wrong = 0;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int Right
        {
            get { return right; }

        }

        public int Wrong
        {
            get { return wrong; }
        }

        public int NonPredict
        {
            get { return np; }    
        }

        public int Total
        {
            get { return right + wrong + np; }
        }

        public double Accuracy
        {
            get { return ((double)Right / Total); }
        }

        public double AccuracyPercentage
        {
            get { return Accuracy * 100; }
        }
    }
}