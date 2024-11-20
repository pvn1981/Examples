using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using EasyCommunityToolkitMvvm.Model;

namespace EasyCommunityToolkitMvvm.ViewModel
{
    public class DataViewModel : ObservableObject
    {
        #region Private 
        private ICommand? _saveCommand;

        private ICommand? _cancelCommand;

        private Data Data { get; set; }

        private void Save()
        {
            Data.SavedName = Data.CurrentName;

            OnPropertyChanged(nameof(SavedName));
        }

        private void Cancel()
        {
            Data.CurrentName = "Current";

            OnPropertyChanged(nameof(CurrentName));
        }

        #endregion Private 

        #region Public properties
        public string? CurrentName
        {
            get
            {
                return Data.CurrentName;
            }

            set
            {
                Data.CurrentName = value;
            }
        }

        public string? SavedName
        {
            get
            {
                return Data.SavedName;
            }

            set
            {
                Data.SavedName = value;
            }
        }

        #endregion Public properties

        #region Command

        public ICommand? SaveCommand
        {
            get
            {
                return _saveCommand;
            }
        }

        public ICommand? CancelCommand
        {
            get
            {
                return _cancelCommand;
            }
        }

        #endregion Command

        #region Public 

        public DataViewModel()
        {
            _saveCommand = new RelayCommand(() => Save());
            _cancelCommand = new RelayCommand(() => Cancel());

            Data = new Data() { CurrentName = "Current", SavedName = "Saved" };
        }

        #endregion Public
    }
}