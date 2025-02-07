using ScottPlotCommunityToolkitMvvm.Abstrations;
using ScottPlotCommunityToolkitMvvm.ViewModel;

namespace ScottPlotCommunityToolkitMvvm.DesignTime
{
    public static class DesignTimeData
    {
        public static IDataModel DataViewModel
        {
            get
            {
                var model = new DataViewModel();

                model.DataX = new float[] { 1, 2, 3, 4, 5 };
                model.DataY= new float[] { 1, 4, 9, 16, 25 };

                model.StatusBarText = "Вывод в статусную строку";

                return model;
            }
        }
    }
}
