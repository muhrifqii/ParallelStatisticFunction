using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsParallel
{
    /// <summary>
    /// 7 statistic operations: mean, median, modes, sd, variance, range, linear regression
    /// </summary>
    public class FunctionClass
    {
        #region range
        /// <summary>
        /// Range Operator
        /// </summary>
        /// <param name="data">the data to be computed</param>
        /// <param name="miss">total missing values</param>
        /// <param name="size">the size of the data</param>
        /// <param name="elapsed">elapsed time</param>
        /// <returns>range</returns>
        public static double Range(double[] data, int miss, int size, out long elapsed)
        {
            double max, min;
            Stopwatch timer = Stopwatch.StartNew();
            max = min = data[0];            
            for (int i = 1; i < size - miss; i++)
            {
                max = data[i] > max ? data[i] : max;
                min = data[i] < min ? data[i] : min;
            }
            timer.Stop();
            elapsed = timer.ElapsedTicks;
            return max - min;
        }
        /// <summary>
        /// Range Operator
        /// </summary>
        /// <param name="data">the data to be computed</param>
        /// <param name="miss">total missing values</param>
        /// <param name="elapsed">elapsed time</param>
        /// <returns>range</returns>
        public static double Range(double[] data, int miss, out long elapsed)
        {
            double max, min;
            Stopwatch timer = Stopwatch.StartNew();
            max = min = data[0];
            for (int i = 1; i < data.Length - miss; i++)
            {
                max = data[i] > max ? data[i] : max;
                min = data[i] < min ? data[i] : min;
            }
            timer.Stop();
            elapsed = timer.ElapsedTicks;
            return max - min;
        }
        /// <summary>
        /// Range Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="elapsed">elapsed time</param>
        /// <returns>range</returns>
        public static double Range(double[] data, out long elapsed)
        {
            double max, min;
            Stopwatch timer = Stopwatch.StartNew();
            max = min = data[0];            
            for (int i = 1; i < data.Length; i++)
            {
                max = data[i] > max ? data[i] : max;
                min = data[i] < min ? data[i] : min;
            }
            timer.Stop();
            elapsed = timer.ElapsedTicks;
            return max - min;
        }
        #endregion
        #region mean
        /// <summary>
        /// Mean Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missingCount">total missing values</param>
        /// <param name="size">the size of data</param>
        /// <returns>mean</returns>
        public static double Mean(double[] data, int missingCount, int size)
        {
            System.Diagnostics.Debug.WriteLine("sum: " + data.Sum());
            return data.Sum() / (size - missingCount);
        }
        /// <summary>
        /// Mean Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missingCount">total missing values</param>
        /// <returns>mean</returns>
        public static double Mean(double[] data, int missingCount)
        {
            System.Diagnostics.Debug.WriteLine("sum: " + data.Sum());
            return data.Sum() / (data.Length - missingCount);
        }
        /// <summary>
        /// Mean Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <returns>mean</returns>
        public static double Mean(double[] data)
        {
            System.Diagnostics.Debug.WriteLine("sum: " + data.Sum());
            return data.Sum() / (data.Length);
        }
        #endregion
        #region median
        /// <summary>
        /// Median Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missingCount">total missing values</param>
        /// <param name="size">size of the data</param>
        /// <returns>median</returns>
        public static double Median(double[] data, int missingCount, int size)
        {
            bool isOdd = (size - missingCount) % 2 != 0;
            double[] x = new double[data.Length];
            double[] res = new double[data.Length];
            data.CopyTo(x, 0);
            res = x.OrderBy((val) => val).ToArray();

            for (int i = 0; i < res.Length; i++)
            {
                System.Diagnostics.Debug.Write(res[i] + " ");
            }
            System.Diagnostics.Debug.Write("\n");

            if (isOdd) return res[(size - missingCount) / 2];
            else return (res[(size - missingCount) / 2] + res[(size - missingCount) / 2 - 1]) / 2;
        }
        /// <summary>
        /// Median Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missingCount">total missing values</param>
        /// <returns>median</returns>
        public static double Median(double[] data, int missingCount)
        {
            bool isOdd = (data.Length - missingCount) % 2 != 0;
            double[] x = new double[data.Length];
            double[] res = new double[data.Length];
            data.CopyTo(x, 0);
            res = x.OrderBy((val) => val).ToArray();

            for (int i = 0; i < res.Length; i++)
            {
                System.Diagnostics.Debug.Write(res[i] + " ");
            }
            System.Diagnostics.Debug.Write("\n");

            if (isOdd) return res[(data.Length - missingCount) / 2];
            else return (res[(data.Length - missingCount) / 2] + res[(data.Length - missingCount) / 2 - 1]) / 2;
        }
        /// <summary>
        /// Median Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <returns>median</returns>
        public static double Median(double[] data)
        {
            bool isOdd = (data.Length) % 2 != 0;
            double[] x = new double[data.Length];
            double[] res = new double[data.Length];
            data.CopyTo(x, 0);
            res = x.OrderBy((val) => val).ToArray();

            for (int i = 0; i < res.Length; i++)
            {
                System.Diagnostics.Debug.Write(res[i] + " ");
            }
            System.Diagnostics.Debug.Write("\n");

            if (isOdd) return res[(data.Length) / 2];
            else return (res[(data.Length) / 2] + res[(data.Length) / 2 - 1]) / 2;
        }
        #endregion
        #region modes
        /// <summary>
        /// Modes Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missing">total missing values</param>
        /// <param name="size">size of the data</param>
        /// <returns>modes</returns>
        public static double Modes(double[] data, int missing, int size)
        {
            Dictionary<double, int> x = new Dictionary<double, int>();
            for (int i = 0; i < size - missing; i++)
            {
                if (!x.ContainsKey(data[i])) x[data[i]] = 1;
                else x[data[i]]++;
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
        /// <summary>
        /// Modes Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missing">total missing values</param>
        /// <returns>modes</returns>
        public static double Modes(double[] data, int missing)
        {
            Dictionary<double, int> x = new Dictionary<double, int>();
            for (int i = 0; i < data.Length - missing; i++)
            {
                if (!x.ContainsKey(data[i])) x[data[i]] = 1;
                else x[data[i]]++;
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
        /// <summary>
        /// Modes Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <returns>modes</returns>
        public static double Modes(double[] data)
        {
            Dictionary<double, int> x = new Dictionary<double, int>();
            for (int i = 0; i < data.Length; i++)
            {
                if (!x.ContainsKey(data[i])) x[data[i]] = 1;
                else x[data[i]]++;
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
        #endregion
        #region variance
        /// <summary>
        /// Variance Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missingCount">total missing values</param>
        /// <param name="size">the size of data</param>
        /// <returns>variance</returns>
        public static double Variance(double[] data, int missingCount, int size)
        {
            double result = 0;
            double theMean = Mean(data, missingCount, size);
            for (int i = 0; i < size - missingCount; i++)
            {
                result += Math.Pow(data[i] - theMean, 2);
            }
            result /= (size - missingCount);

            return result;
        }
        /// <summary>
        /// Variance Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <param name="missingCount">total missing values</param>
        /// <returns>variance</returns>
        public static double Variance(double[] data, int missingCount)
        {
            double result = 0;
            double theMean = Mean(data, missingCount);
            for (int i = 0; i < data.Length - missingCount; i++)
            {
                result += Math.Pow(data[i] - theMean, 2);
            }
            result /= (data.Length - missingCount);

            return result;
        }
        /// <summary>
        /// Variance Operator
        /// </summary>
        /// <param name="data">the data tobe computed</param>
        /// <returns>variance</returns>
        public static double Variance(double[] data)
        {
            double result = 0;
            double theMean = Mean(data);
            for (int i = 0; i < data.Length; i++)
            {
                result += Math.Pow(data[i] - theMean, 2);
            }
            result /= (data.Length);

            return result;
        }
        #endregion
        #region standardDeviation
        /// <summary>
        /// Standard Deviation Function
        /// </summary>
        /// <param name="data">the data</param>
        /// <param name="missingCount">total missing values</param>
        /// <param name="size">the size of data</param>
        /// <returns>standard deviation</returns>
        public static double StandardDeviation(double[] data, int missingCount, int size)
        {
            return Math.Sqrt(Variance(data, missingCount, size));
        }
        /// <summary>
        /// Standard Deviation Function
        /// </summary>
        /// <param name="data">the data</param>
        /// <param name="missingCount">total missing values</param>
        /// <returns>standard deviation</returns>
        public static double StandardDeviation(double[] data, int missingCount)
        {
            return Math.Sqrt(Variance(data, missingCount));
        }
        /// <summary>
        /// Standard Deviation Function
        /// </summary>
        /// <param name="data">the data</param>
        /// <returns>standard deviation</returns>
        public static double StandardDeviation(double[] data)
        {
            return Math.Sqrt(Variance(data));
        }
        #endregion
        #region linearRegression
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
        /// <param name="elapsed">elapsed time</param>
        public static void LinearRegression(double[] xVals, double[] yVals,
                                            int inclusiveStart, int exclusiveEnd,
                                            out double rsquared, out double yintercept,
                                            out double slope, out long elapsed)
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

            Stopwatch timer = Stopwatch.StartNew();
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
            timer.Stop();
            elapsed = timer.ElapsedTicks;
        }
        #endregion
        #region external library
        #endregion

        //range paralel : data dipecah jadi n array of data, 
        //cek max min tiap array of data yg dipecah,
        //cek max min tiap max min hasil dari array of data yg dipecah,
        //max min dikurangi

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
    /// <summary>
    /// current version, range and linear regression operation work in parallel computation
    /// </summary>
    public class ParallelFunctionClass
    {
        /// <summary>
        /// Linear Regression in Parallel. Fits a line to a collection of (x,y) points.
        /// </summary>
        /// <param name="xVals">The x-axis values.</param>
        /// <param name="yVals">The y-axis values.</param>
        /// <param name="inclusiveStart">The inclusive inclusiveStart index.</param>
        /// <param name="exclusiveEnd">The exclusive exclusiveEnd index.</param>
        /// <param name="rsquared">The r^2 value of the line.</param>
        /// <param name="yintercept">The y-intercept value of the line (i.e. y = ax + b, yintercept is b).</param>
        /// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
        /// <param name="elapsed">the running time.</param>
        public static void LinearRegressionPar(double[] xVals, double[] yVals,
                                            int inclusiveStart, int exclusiveEnd,
                                            out double rsquared, out double yintercept,
                                            out double slope, out long elapsed)
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
            double meanX, meanY, dblR;
            object lockObj = new object();

            Stopwatch timer = Stopwatch.StartNew();
            Task[] tobeDone = new Task[exclusiveEnd - inclusiveStart];
            int j = inclusiveStart;
            for (int i = 0; i < exclusiveEnd - inclusiveStart; i++)
            {
                tobeDone[i] = Task.Factory.StartNew((var) =>
                {
                    double x = (var as double[])[0];
                    double y = (var as double[])[1];
                    lock (lockObj)
                    {
                        sumCodeviates += x * y;
                        sumOfX += x;
                        sumOfY += y;
                        sumOfXSq += x * x;
                        sumOfYSq += y * y;
                    }
                    Debug.WriteLine("threadID: {0}, index num: {1}", Thread.CurrentThread.ManagedThreadId, (var as double[])[2]);

                    //j++;
                }, new double[] { xVals[i], yVals[i], i }, TaskCreationOptions.AttachedToParent);
            }
            Task.WaitAll(tobeDone);

            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            double RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            meanX = sumOfX / count;
            meanY = sumOfY / count;
            dblR = RNumerator / Math.Sqrt(RDenom);

            rsquared = dblR * dblR;
            yintercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;

            timer.Stop();
            elapsed = timer.ElapsedTicks;
        }
        public static double RangeParTask1(double[] data, int miss, int size, out long elapsed)
        {
            bool isOdd = size % 2 != 0;

            int j = 0;
            int n = size;

            if (!isOdd) n /= 2;
            else n = (n + 1) / 2;

            Task[] tasks1 = new Task[n];
            Task[] tasks2 = new Task[n];

            double max, min;
            max = min = data[0];

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                tasks1[i] = Task.Factory.StartNew(() =>
                {
                    max = data[i] > max ? data[i] : max;
                    min = data[i] < min ? data[i] : min;
                });
                tasks2[i] = Task.Factory.StartNew(() =>
                {
                    if (!isOdd)
                    {
                        max = data[i + n - 1] > max ? data[i + n - 1] : max;
                        min = data[i + n - 1] < min ? data[i + n - 1] : min; 
                    }
                    else
                    {
                        max = data[i + n - 2] > max ? data[i + n - 2] : max;
                        min = data[i + n - 2] < min ? data[i + n - 2] : min;
                    }
                });
            }
            Task.WaitAll(tasks1);
            Task.WaitAll(tasks2);
            timer.Stop();
            elapsed = timer.ElapsedTicks;
            return max - min;
            
        }
        public static double RangeParTask2(double[] data, int miss, int size, out long elapsed)
        {
            bool isOdd = size % 2 != 0;
            int j = 0;
            int n = size;
            if (n % 2 == 0) n /= 2;
            else n = (n + 1) / 2;

            Task[] tasks1 = new Task[n];

            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                tasks1[i] = Task.Factory.StartNew((Object obj) =>
                {
                    HelperRangeData check = obj as HelperRangeData;
                    if (check == null) return;
                    check.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    if (check.Max < check.Min)
                    {
                        double tmp = check.Max;
                        check.Max = check.Min;
                        check.Min = tmp;
                    }
                },
                new HelperRangeData()
                {
                    Index = i,
                    CreationTime = DateTime.Now.Ticks,
                    Max = ((!isOdd && j < size) || j != size - 1) ? data[j++] : data[j],
                    Min = ((!isOdd && j < size) || j != size - 1) ? data[j++] : data[j]
                });
            }
            Task.WaitAll(tasks1);
            double max, min;
            max = double.MinValue;
            min = double.MaxValue;
            for (int i = 0; i < tasks1.Length; i++)
            {
                var check = tasks1[i].AsyncState as HelperRangeData;
                Debug.WriteLine("id: " + check.Index + " on thread #" + check.ThreadNum + " ");
                max = check.Max > max ? check.Max : max;
                min = check.Min < min ? check.Min : min;
            }
            Debug.WriteLine("");
            timer.Stop();
            elapsed = timer.ElapsedTicks;
            return max - min;          
        }
        public static double RangeParTask3(double[] data, int miss, int size, out long elapsed)
        {
            double result = 0;
            bool isOdd = size % 2 != 0;
            int j = 0;
            int n = size;
            if (n % 2 == 0) n /= 2;
            else n = (n + 1) / 2;

            Task[] tasks1 = new Task[n];

            Stopwatch timer = Stopwatch.StartNew();
            //task pertama perlakuan khusus
            Task taskCuk = Task.Factory.StartNew(() =>
            {
                j = 0;
                for (int i = 0; i < n; i++)
                {
                    tasks1[i] = Task.Factory.StartNew((Object obj) =>
                    {
                        HelperRangeData check = obj as HelperRangeData;
                        if (check == null) return;
                        check.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                        if (check.Max < check.Min)
                        {
                            double tmp = check.Max;
                            check.Max = check.Min;
                            check.Min = tmp;
                        }
                    },
                    new HelperRangeData()
                    {
                        Index = i,
                        CreationTime = DateTime.Now.Ticks,
                        Max = (n % 2 == 0 || j != size - 1) ? data[j++] : data[j],
                        Min = (n % 2 == 0 || j != size - 1) ? data[j++] : data[j]
                    }, TaskCreationOptions.AttachedToParent);
                }

            });
            taskCuk.Wait();
            //right after taskCuk done, start new task
            Task taskMenehCuk = Task.Factory.StartNew(() =>
            {
                int ii = 0;
                bool first = true;
                while (n > 1)
                {
                    List<Task> tasks2 = new List<Task>();
                    List<Task> taskToCheck = new List<Task>();
                    if (first)
                    {
                        for (int xx = 0; xx < tasks1.Length; xx++)
                        {
                            taskToCheck.Add(tasks1[xx]);
                        }
                        first = false;
                    }
                    else
                    {
                        for (int xx = 0; xx < tasks2.Count; xx++)
                        {
                            taskToCheck.Add(tasks2[xx]);
                        }
                    }
                    bool thisIsOdd = n % 2 != 0;
                    int n_before = n;
                    if (!thisIsOdd) n /= 2;
                    else n = (n + 1) / 2;
                    ii = 0;
                    for (int k = 0; k < n; k++)
                    {
                        Task some = Task.Factory.StartNew((object sender) =>
                        {
                            HelperRangeData check = sender as HelperRangeData;
                            if (check == null) return;

                            Task grandChild1 = Task.Factory.StartNew((object obj) =>
                            {
                                //cek ganjil/genap
                                obj = (!thisIsOdd || ii != n_before - 1) ?
                                    taskToCheck[ii++].AsyncState as HelperRangeData : tasks1[ii].AsyncState as HelperRangeData;
                            }, new HelperRangeData(), TaskCreationOptions.AttachedToParent);
                            Task grandChild2 = Task.Factory.StartNew((object obj) =>
                            {
                                obj = (!thisIsOdd || ii != n_before - 1) ?
                                    taskToCheck[ii++].AsyncState as HelperRangeData : tasks1[ii].AsyncState as HelperRangeData;
                            }, new HelperRangeData(), TaskCreationOptions.AttachedToParent);

                            check.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                            HelperRangeData helper1 = grandChild1.AsyncState as HelperRangeData;
                            HelperRangeData helper2 = grandChild2.AsyncState as HelperRangeData;
                            check.Max = (helper1.Max > helper2.Max) ? helper1.Max : helper2.Max;
                            check.Min = (helper1.Min < helper2.Min) ? helper1.Min : helper2.Min;
                        },
                        new HelperRangeData()
                        {
                            Index = k,
                            CreationTime = DateTime.Now.Ticks,

                        }, TaskCreationOptions.AttachedToParent);

                        tasks2.Add(some);
                    }
                }
            });
            taskMenehCuk.Wait();
            timer.Stop();
            //result = max - min;
            elapsed = timer.ElapsedTicks;
            return result;
        }
        class HelperRangeData
        {
            public int Index { get; set; }
            public int ThreadNum { get; set; }
            public long CreationTime { get; set; }
            public double Max { get; set; }
            public double Min { get; set; }
        }
        
    }
    
}
