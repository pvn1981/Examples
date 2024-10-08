using FilterMedian;
using System.Diagnostics;
using System.Drawing;

namespace FilterMedianTest
{
    public class UnitTestsMain
    {
        private FilterMedian<double> filterMedian;

        [SetUp]
        public void Setup()
        {
            int size = 5;
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