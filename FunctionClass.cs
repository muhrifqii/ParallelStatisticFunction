using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSPSS
{
    class FunctionClass
    {
        public static double Range(double[] data)
        {
            return data.Max() - data.Min();
        }        

        public static double Mean(double[] data)
        {
            return data.Sum() / data.Length;
        }

        public static double Median(double[] data)
        {
            bool isOdd = data.Length % 2 != 0;
            double[] x = new double[data.Length];
            double[] res = new double[data.Length];
            data.CopyTo(x, 0);
            res = x.OrderBy((val) => val).ToArray();

            if (isOdd) return res[data.Length / 2];
            else return (res[data.Length / 2] + res[data.Length / 2 - 1]) / 2;
        }

        public static double Modes(double[] data)
        {
            Dictionary<double, int> x = new Dictionary<double, int>();
            foreach(double dob in data)
            {
                if (!x.ContainsKey(dob)) x[dob] = 1;
                else x[dob]++;
            }
            double mode = 0;
            int count = 0;
            foreach (KeyValuePair<double, int> pair in x)
            {
                if (pair.Value > count)
                {
                    count = pair.Value;
                    mode = pair.Key;
                }
            }
            return mode;
        }

        public static double Variance(double[] data)
        {
            double result = 0;
            double theMean = Mean(data);
            foreach(double dob in data)
            {
                result += Math.Pow(dob - theMean, 2);
            }
            result /= data.Length;

            return result;
        }

        public static double StandardDeviation(double[] data)
        {
            return Math.Sqrt(Variance(data));
        }

        /// <summary>
        /// Fits a line to a collection of (x,y) points.
        /// </summary>
        /// <param name="xVals">The x-axis values.</param>
        /// <param name="yVals">The y-axis values.</param>
        /// <param name="inclusiveStart">The inclusive inclusiveStart index.</param>
        /// <param name="exclusiveEnd">The exclusive exclusiveEnd index.</param>
        /// <param name="rsquared">The r^2 value of the line.</param>
        /// <param name="yintercept">The y-intercept value of the line (i.e. y = ax + b, yintercept is b).</param>
        /// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
        public static void LinearRegression(double[] xVals, double[] yVals,
                                            int inclusiveStart, int exclusiveEnd,
                                            out double rsquared, out double yintercept,
                                            out double slope)
        {
            //Debug.Assert(xVals.Length == yVals.Length);
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double ssX = 0;
            double ssY = 0;
            double sumCodeviates = 0;
            double sCo = 0;
            double count = exclusiveEnd - inclusiveStart;

            for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
            {
                double x = xVals[ctr];
                double y = yVals[ctr];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            double RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            double meanX = sumOfX / count;
            double meanY = sumOfY / count;
            double dblR = RNumerator / Math.Sqrt(RDenom);
            rsquared = dblR * dblR;
            yintercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
        }

        //public static double RangeParallel(double[] data)
        //{
        //    double max = data[0];
        //    double min = data[0];

        //    Parallel.Invoke(() =>
        //    {
        //        for (int i = 0; i < data.Length; i++)
        //        {
        //            max = (data[i] > max) ? data[i] : max;
        //        }
        //    }, () =>
        //    {
        //        for (int i = 0; i < data.Length; i++)
        //        {
        //            min = (data[i] < min) ? data[i] : min;
        //        }
        //    });

        //    Parallel.For(1, data.Length, (i) =>
        //    {
        //        max = (data[i] > max) ? data[i] : max;
        //        min = (data[i] < min) ? data[i] : min;
        //    });
        //    return max - min;
        //}
    }
}
