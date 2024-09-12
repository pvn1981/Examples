using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStatistics
{
    public static class DataSaverExtension
    {
        public static double GetStandartDeviation(this CircularBuffer<double> buffer)
        {
            var descriptiveStatistics = new DescriptiveStatistics(buffer.ToArray());
            return descriptiveStatistics.StandardDeviation;
        }

        public static double GetMax(this CircularBuffer<double> buffer)
        {
            var descriptiveStatistics = new DescriptiveStatistics(buffer.ToArray());
            return descriptiveStatistics.Maximum;
        }

        public static double GetMin(this CircularBuffer<double> buffer)
        {
            var descriptiveStatistics = new DescriptiveStatistics(buffer.ToArray());
            return descriptiveStatistics.Minimum;
        }

        public static double GetMean(this CircularBuffer<double> buffer)
        {
            var descriptiveStatistics = new DescriptiveStatistics(buffer.ToArray());
            return descriptiveStatistics.Mean;
        }
    }
}
