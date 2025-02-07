using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EasyCommunityToolkitMvvm.Model;
using OpenTK.Graphics.ES20;
using ScottPlotCommunityToolkitMvvm.Abstrations;

namespace ScottPlotCommunityToolkitMvvm.ViewModel
{
    public class DataViewModel : ObservableObject, IDataModel
    {
        private Data _data;
        private ScottPlot.WPF.WpfPlot? _plot;

        public ScottPlot.WPF.WpfPlot? Plot
        {
            get { return _plot; }
            set { _plot = value; }
        }

        public float[]? DataX
        {
            get => _data.DataX;
            set 
            {
                _data.DataX = value;
                UpdatePlot();
            }
        }

        public float[]? DataY
        {
            get => _data.DataY;
            set
            { 
                _data.DataY = value;
                UpdatePlot();
            }
        }

        public string StatusBarText { get; set; }

        public RelayCommand LoadedCommand { get; private set; }

        public DataViewModel()
        {
            _data = new Data();

            LoadedCommand = new RelayCommand(OnLoaded);
            StatusBarText = "";
        }

        private void OnLoaded()
        {
            StatusBarText = string.Format("Загружено");
            OnPropertyChanged(nameof(StatusBarText));
        }

        public void UpdatePlot()
        {
            if (_plot != null)
            { 
                _plot.Plot.Title("Данные с прибора");
                _plot.Plot.XLabel("Время (мс)");
                _plot.Plot.YLabel("Амплитуда (мА)");

                if (DataX != null && DataY != null)
                {
                _plot.Plot.Add.Scatter(DataX, DataY);
                _plot.Plot.Axes.AutoScale();
                }

                _plot.Refresh();
            }

            StatusBarText = string.Format("Обновлено");
            OnPropertyChanged(nameof(StatusBarText));
        }
    }
}