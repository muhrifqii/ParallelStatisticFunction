//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ParallelSPSS
//{
//    class FunctionClass
//    {
//        public static double Range(double[] data, int miss, int size)
//        {
//            double max, min;
//            max = min = data[0];
//            for(int i = 1; i < size - miss; i++)
//            {
//                max = data[i] > max ? data[i] : max;
//                min = data[i] < min ? data[i] : min;
//            }
//            return max - min;
//        }        

//        public static double Mean(double[] data, int missingCount, int size)
//        {
//            System.Diagnostics.Debug.WriteLine("sum: " + data.Sum());
//            return data.Sum() / (size - missingCount);
//        }

//        public static double Median(double[] data, int missingCount, int size)
//        {
//            ////make sure the list is sorted, but use a new array
//            //double[] sortedPNumbers = (double[])data.Clone();
//            //Array.Sort(sortedPNumbers);

//            ////get the median
//            //int sortedSize = sortedPNumbers.Length;
//            //int mid = sortedSize / 2;
//            //double median = (sortedSize % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
//            //return median;

//            bool isOdd = (size - missingCount) % 2 != 0;
//            double[] x = new double[data.Length];
//            double[] res = new double[data.Length];
//            data.CopyTo(x, 0);
//            res = x.OrderBy((val) => val).ToArray();

//            for (int i = 0; i < res.Length; i++)
//            {
//                System.Diagnostics.Debug.Write(res[i] + " ");
//            }
//            System.Diagnostics.Debug.Write("\n");

//            if (isOdd) return res[(size - missingCount) / 2];
//            else return (res[(size - missingCount) / 2] + res[(size - missingCount) / 2 - 1]) / 2;
//        }

//        public static double Modes(double[] data, int missing, int size)
//        {
//            Dictionary<double, int> x = new Dictionary<double, int>();
//            for(int i=0;i<size - missing; i++)
//            {
//                if (!x.ContainsKey(data[i])) x[data[i]] = 1;
//                else x[data[i]]++;
//            }
//            double mode = 0;
//            int count = 0;
//            foreach (KeyValuePair<double, int> pair in x)
//            {
//                if (pair.Value > count)
//                {
//                    count = pair.Value;
//                    mode = pair.Key;
//                }
//            }
//            return mode;
//        }

//        public static double Variance(double[] data, int missingCount, int size)
//        {
//            double result = 0;
//            double theMean = Mean(data, missingCount, size);
//            for (int i = 0; i < size - missingCount; i++)
//            {
//                result += Math.Pow(data[i] - theMean, 2);
//            }
//            result /= (size - missingCount);

//            return result;
//        }

//        /// <summary>
//        /// Standard Deviation Function
//        /// </summary>
//        /// <param name="data">the data</param>
//        /// <param name="missingCount">total missing values</param>
//        /// <param name="size">the size of data</param>
//        /// <returns></returns>
//        public static double StandardDeviation(double[] data, int missingCount, int size)
//        {
//            return Math.Sqrt(Variance(data, missingCount, size));
//        }

//        /// <summary>
//        /// Fits a line to a collection of (x,y) points.
//        /// </summary>
//        /// <param name="xVals">The x-axis values.</param>
//        /// <param name="yVals">The y-axis values.</param>
//        /// <param name="inclusiveStart">The inclusive inclusiveStart index.</param>
//        /// <param name="exclusiveEnd">The exclusive exclusiveEnd index.</param>
//        /// <param name="rsquared">The r^2 value of the line.</param>
//        /// <param name="yintercept">The y-intercept value of the line (i.e. y = ax + b, yintercept is b).</param>
//        /// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
//        public static void LinearRegression(double[] xVals, double[] yVals,
//                                            int inclusiveStart, int exclusiveEnd,
//                                            out double rsquared, out double yintercept,
//                                            out double slope)
//        {
//            //Debug.Assert(xVals.Length == yVals.Length);
//            double sumOfX = 0;
//            double sumOfY = 0;
//            double sumOfXSq = 0;
//            double sumOfYSq = 0;
//            double ssX = 0;
//            double ssY = 0;
//            double sumCodeviates = 0;
//            double sCo = 0;
//            double count = exclusiveEnd - inclusiveStart;

//            for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
//            {
//                double x = xVals[ctr];
//                double y = yVals[ctr];
//                sumCodeviates += x * y;
//                sumOfX += x;
//                sumOfY += y;
//                sumOfXSq += x * x;
//                sumOfYSq += y * y;
//            }
//            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
//            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
//            double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
//            double RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
//             * (count * sumOfYSq - (sumOfY * sumOfY));
//            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

//            double meanX = sumOfX / count;
//            double meanY = sumOfY / count;
//            double dblR = RNumerator / Math.Sqrt(RDenom);
//            rsquared = dblR * dblR;
//            yintercept = meanY - ((sCo / ssX) * meanX);
//            slope = sCo / ssX;
//        }

//        //range paralel : data dipecah jadi n array of data, 
//        //cek max min tiap array of data yg dipecah,
//        //cek max min tiap max min hasil dari array of data yg dipecah,
//        //max min dikurangi

//        public static double RangeParTask(double[] data, int miss, int size)
//        {
//            double result = 0;
//            int splitSize = size / 2;
//            bool isOdd = size % 2 != 0;

//            Task[] tasks1 = new Task[splitSize];
//            int j = 0;
//            for (int i = 1; i < tasks1.Length; i++)
//            {
//                tasks1[i] = Task.Factory.StartNew((Object obj) =>
//                {
//                    HelperRangeData check = obj as HelperRangeData;
//                    if (check == null) return;
//                    check.ThreadNum = Thread.CurrentThread.ManagedThreadId;
//                    if(check.Max < check.Min)
//                    {
//                        double tmp = check.Max;
//                        check.Max = check.Min;
//                        check.Min = tmp;
//                    }
//                },
//                new HelperRangeData()
//                {
//                    Index = i, CreationTime = DateTime.Now.Ticks,
//                    Max = data[j++], Min = data[j++]
//                });
//            }
//            Task.WaitAll(tasks1);

//            return result;
//        }

//        class HelperRangeData
//        {
//            public int Index { get; set; }
//            public int ThreadNum { get; set; }
//            public long CreationTime { get; set; }
//            public double Max { get; set; }
//            public double Min { get; set; }
//        }

//        //public static double RangeParallel(double[] data)
//        //{
//        //    double max = data[0];
//        //    double min = data[0];

//        //    Parallel.Invoke(() =>
//        //    {
//        //        for (int i = 0; i < data.Length; i++)
//        //        {
//        //            max = (data[i] > max) ? data[i] : max;
//        //        }
//        //    }, () =>
//        //    {
//        //        for (int i = 0; i < data.Length; i++)
//        //        {
//        //            min = (data[i] < min) ? data[i] : min;
//        //        }
//        //    });

//        //    Parallel.For(1, data.Length, (i) =>
//        //    {
//        //        max = (data[i] > max) ? data[i] : max;
//        //        min = (data[i] < min) ? data[i] : min;
//        //    });
//        //    return max - min;
//        //}
//    }
//}
