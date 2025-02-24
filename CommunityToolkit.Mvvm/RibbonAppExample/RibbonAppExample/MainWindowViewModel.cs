using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RibbonAppExample
{
    public class MainWindowViewModel : ObservableObject
    {
        public RelayCommand Button1Command { get; }

        public MainWindowViewModel()
        {
            Button1Command = new RelayCommand(ExecuteButton1Command);
        }

        private void ExecuteButton1Command()
        {
            // Your command logic here
            MessageBox.Show("Ribbon button clicked!", "Message Box Title", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
