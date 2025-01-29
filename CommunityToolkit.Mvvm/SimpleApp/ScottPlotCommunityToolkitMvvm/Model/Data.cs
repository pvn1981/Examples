using ScottPlot;
using System.Data;
using System.Windows.Markup;

namespace EasyCommunityToolkitMvvm.Model
{
    public class Data
    {
        const int _pointCountX = 5;
        const int _pointCountY = 5;

        private float[] _dataX;

        private float[] _dataY;

        public Data()
        {
            // Example data
            _dataX = new float[_pointCountX] { 1, 2, 3, 4, 5 };
            _dataY = new float[_pointCountY] { 1, 4, 9, 16, 25 };
        }

        public float[] DataX
        {
            get { return _dataX; }
        }

        public float[] DataY
        {
            get { return _dataY; }
        }
    }
}
