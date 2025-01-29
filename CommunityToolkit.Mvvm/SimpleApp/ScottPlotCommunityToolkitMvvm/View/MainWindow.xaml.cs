using EasyCommunityToolkitMvvm.ViewModel;
using Microsoft.Xaml.Behaviors;
using ScottPlot.WPF;
using System.Windows;

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

            DataContext = new DataViewModel();
            ((DataViewModel)DataContext).UpdatePlot(wpfPlot);

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