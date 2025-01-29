using System.Windows;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EasyCommunityToolkitMvvm.Model;

using ScottPlot;

namespace EasyCommunityToolkitMvvm.ViewModel
{
    public class DataViewModel : ObservableObject
    {
        private Data _data;
        private ScottPlot.WPF.WpfPlot? _plot;

        public float[] DataX
        {
            get => _data.DataX;
        }

        public float[] DataY
        {
            get => _data.DataY;
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

        public void UpdatePlot(ScottPlot.WPF.WpfPlot plot)
        {
            _plot = plot;

            _plot.Plot.Title("Данные с прибора");
            _plot.Plot.XLabel("Время (мс)");
            _plot.Plot.YLabel("Амплитуда (мА)");

            _plot.Plot.Add.Scatter(DataX, DataY);
            _plot.Plot.Axes.AutoScale();

            _plot.Refresh();

            StatusBarText = string.Format("Обновлено");
            OnPropertyChanged(nameof(StatusBarText));
        }
    }
}