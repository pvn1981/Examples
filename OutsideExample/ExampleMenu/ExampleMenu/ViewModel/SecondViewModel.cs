using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleMenu.ViewModel
{
    public class SecondViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public SecondViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;

            //создаем список чисел
            NumbersList = Enumerable.Range(1, 10).ToList();
        }

        //Properties

        /// <summary>
        /// Список чисел для ComboBox
        /// </summary>
        private List<int> _NumbersList;
        public List<int> NumbersList
        {
            get { return _NumbersList; }
            set
            {
                _NumbersList = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(NumbersList)));
            }
        }

        /// <summary>
        /// Выбранное число в списке чисел
        /// </summary>
        private string _SelectedNumber;
        public string SelectedNumber
        {
            get { return _SelectedNumber; }
            set
            {
                _SelectedNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedNumber)));
            }
        }


        //Commands

        /// <summary>
        /// Сообщение пользователю
        /// </summary>
        private RelayCommand _ShowMessageCommand;
        public RelayCommand ShowMessageCommand
        {
            get
            {
                return _ShowMessageCommand = _ShowMessageCommand ??
                  new RelayCommand(OnShowMessage, CanShowMessage);
            }
        }
        private bool CanShowMessage()
        {
            return true;
        }
        private void OnShowMessage()
        {
            _MainCodeBehind.ShowMessage($"Вы выбрали: {SelectedNumber}");
        }
    }
}
