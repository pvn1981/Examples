using DataStatistics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStatisticsTests
{
    [TestFixture]
    internal class DataSaverExtensionTest
    {
        CircularBuffer<double> _dataSaver;

        [SetUp]
        public void SetUp()
        {
            _dataSaver = new CircularBuffer<double>(7);
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [TearDown]
        public void SetDown()
        {
            Trace.Flush();
        }


        [Test]
        public void TestStandartDeviation()
        {
            double[] arrayData = { 10.004,
                10.003,
                10.004,
                10.011,
                10.013,
                10.014,
                10.007};

            foreach (double v in arrayData)
            {
                _dataSaver.PushBack(v);
            }

            Assert.IsFalse(_dataSaver.IsEmpty);
            Assert.IsTrue(_dataSaver.IsFull);

            double standartDeviation = _dataSaver.GetStandartDeviation();
            Assert.AreEqual(standartDeviation, 0.0046188021535169994, 1e-6);
        }

        [Test]
        public void TestBadData()
        {
            double[] arrayData = { 10.004,
                10.003,
                10.004,
                10.020,
                10.013,
                10.014,
                10.007,
                10.005,
                10.003,
                10.004,
                10.008,
                10.013,
                10.014,
                10.007,
                10.008};

            Debug.WriteLine("\n\tDATA");
            foreach (double v in arrayData)
            {
                _dataSaver.PushBack(v);

                if(_dataSaver.IsFull)
                {
                    double[] tmp = _dataSaver.ToArray();
                    foreach (double data in tmp)
                    {
                        Debug.Write(string.Format(" {0}", data));
                    }

                    Debug.WriteLine("");
                }
            }

            Debug.WriteLine("\n\tSORT");
            _dataSaver.Clear();
            foreach (double v in arrayData)
            {
                _dataSaver.PushBack(v);

                if (_dataSaver.IsFull)
                {
                    double[] tmp = _dataSaver.ToArray();
                    Array.Sort(tmp);

                    foreach (double data in tmp)
                    {
                        Debug.Write(string.Format(" {0}", data));
                    }

                    Debug.WriteLine("");
                }
            }

            Assert.IsFalse(_dataSaver.IsEmpty);
            Assert.IsTrue(_dataSaver.IsFull);

            double standartDeviation = _dataSaver.GetStandartDeviation();
            Assert.AreEqual(0.004140393356054292, standartDeviation, 1e-6);

            double min = _dataSaver.GetMin();
            Assert.AreEqual(10.003, min, 1e-6);

            double max = _dataSaver.GetMax();
            Assert.AreEqual(10.014, max, 1e-6);

            double mean = _dataSaver.GetMean();
            Assert.AreEqual(10.008142857142856, mean, 1e-6);

            // 10.02 -mean =  0.010714285714287
            // 3 sigma = 0.0194201662491050013
        }
    }
}
