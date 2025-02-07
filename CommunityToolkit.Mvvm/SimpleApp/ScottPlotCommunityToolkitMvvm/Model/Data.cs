using ScottPlot;
using System.Data;
using System.Windows.Markup;

namespace EasyCommunityToolkitMvvm.Model
{
    public class Data
    {
        private float[]? _dataX;
        private float[]? _dataY;

        public Data()
        {
        }

        public float[]? DataX
        {
            get => _dataX;
            set => _dataX = value;
        }

        public float[]? DataY
        {
            get => _dataY;
            set => _dataY = value;
        }
    }
}
