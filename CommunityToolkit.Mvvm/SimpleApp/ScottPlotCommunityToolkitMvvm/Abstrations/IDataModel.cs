namespace ScottPlotCommunityToolkitMvvm.Abstrations
{
    public interface IDataModel
    {
        float[]? DataX { get; set; }

        float[]? DataY { get; set; }

        public string StatusBarText { get; set; }
    }
}
