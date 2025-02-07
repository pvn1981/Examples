using System.Windows;
using System.Diagnostics;

using Microsoft.Xaml.Behaviors;

using ScottPlotCommunityToolkitMvvm.ViewModel;
using ScottPlotCommunityToolkitMvvm.Properties;

namespace EasyCommunityToolkitMvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataViewModel model = new DataViewModel();
            model.Plot = this.wpfPlot;
            DataContext = model;

            if(Settings.Default.UseTestData == true)
            {
                model.DataX = new float[] { 1, 2, 3, 4, 5 };
                model.DataY = new float[] { 1, 4, 9, 16, 25 };
            }

            model.UpdatePlot();

            // Create the Interaction Triggers for Loaded event
            var trigger = new Microsoft.Xaml.Behaviors.EventTrigger { EventName = "Loaded" };
            var invokeCommandAction = new InvokeCommandAction
            {
                Command = ((DataViewModel)DataContext).LoadedCommand
            };
            trigger.Actions.Add(invokeCommandAction);
            Interaction.GetTriggers(this).Add(trigger);
        }
    }
}