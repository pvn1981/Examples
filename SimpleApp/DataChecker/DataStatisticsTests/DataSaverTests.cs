using NUnit.Framework;

using DataStatistics;

namespace DataStatisticsTests
{
    public class DataSaverTests
    {
        CircularBuffer<double> _dataSaver;

        [SetUp]
        public void Setup()
        {
            _dataSaver = new CircularBuffer<double>(7);
        }

        [Test]
        public void TestLastData()
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

            Assert.IsTrue(_dataSaver[6] == arrayData[6]);
        }

        [Test]
        public void TestLastData1()
        {
            double[] arrayData = { 10.004, 10.007};

            foreach (double v in arrayData)
            {
                _dataSaver.PushBack(v);
            }

            Assert.IsFalse(_dataSaver.IsEmpty);
            Assert.IsFalse(_dataSaver.IsFull);

            Assert.IsTrue(_dataSaver.Count == 2);
        }

        [Test]
        public void TestLastData10()
        {
            double[] arrayData = { 10.004,
                10.003,
                10.004,
                10.011,
                10.013,
                10.014,
                10.007,
                10.005,
                10.011,
                10.001};

            foreach (double v in arrayData)
            {
                _dataSaver.PushBack(v);
            }

            Assert.IsFalse(_dataSaver.IsEmpty);
            Assert.IsTrue(_dataSaver.IsFull);

            Assert.IsTrue(_dataSaver.Front() == arrayData[3]);

            int size = _dataSaver.Count;
            for (int i = 0; i < size; i++)
            {
                Assert.IsTrue(_dataSaver[i] == arrayData[i+ 3]);
            }
            
            Assert.IsTrue(_dataSaver.Back() == arrayData[9]);
        }

        [Test]
        public void TestLastData7()
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

            int size = _dataSaver.Count;
            for (int i = 0; i < size; i++)
            {
                Assert.IsTrue(_dataSaver[i] == arrayData[i]);
            }
        }
    }
}