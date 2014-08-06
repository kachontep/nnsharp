using System;

namespace NNSharp
{
    public static class ArraysUtil<T>
    {
        public static T[] SubRange(T[] array, int start, int length)
        {
            T[] newArray = new T[length];
            for (int i = 0; (i < length) && (start + i < array.Length); ++i)
                newArray[i] = array[i];
            return newArray;
        }

        public static void SubRange(T[] array, int start, int length, T[] subarray)
        {
            if (subarray.Length < length)
                throw new ArgumentException("Sub array isn't enought for subrange.");

            for (int i = 0; (i < length) && (start + i < array.Length); i++)
                subarray[i] = array[start + i];
        }

        public static void Print(T[] array)
        {
            Console.Write("[ ");
            foreach (T a in array)
                Console.Write(a.ToString() + " ");
            Console.WriteLine("]");
        }
    }
}