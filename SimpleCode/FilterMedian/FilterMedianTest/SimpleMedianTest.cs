using FilterMedian;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterMedianTest
{
    public class SimpleMedianTest
    {
        private FilterMedian<double> filterMedian;

        [SetUp]
        public void Setup()
        {
            int size = 3;
            filterMedian = new FilterMedian<double>(size);
        }

        [Test]
        public void Test1()
        {
            double[] arrayData = { 10.004,
                10.003,
                10.004,
                10.011,
                10.013,
                10.014,
                10.006,
                10.009,
                10.012,
                10.003,
                10.006,
                10.007};

            foreach (double v in arrayData)
            {
                filterMedian.Add(v);

                Debug.WriteLine(string.Format("Added {0} \t MEDIAN: {1}", v, filterMedian.GetMedian()));
            }

            // Assert.Pass();
        }
    }
}
