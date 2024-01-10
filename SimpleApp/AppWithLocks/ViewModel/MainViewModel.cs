using GalaSoft.MvvmLight;
using System.ComponentModel;
using AppWithLocks.Converters;
using AppWithLocks.Primitives;

using AppWithLocks.Managers;
using AppWithLocks.Infrastructure.Abstractions;
using System;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.IO;

namespace AppWithLocks.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        const string registrationCodeFile = "codereg.dat";
        const string activationCodeFile = "cedeact.dat";

        public ICommand ActivateWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    string currentDir = System.IO.Directory.GetCurrentDirectory();
                    string fullFileName = Path.Combine(currentDir, activationCodeFile);

                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fullFileName))
                    {
                        writer.WriteLine(ActivationCodeText);
                    }

                    CheckActivation();
                });
            }
        }

        public ICommand GetActivatingCodeCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    string currentDir = System.IO.Directory.GetCurrentDirectory();
                    string fullFileName = Path.Combine(currentDir, registrationCodeFile);

                    string tmpRegistrationCodeText = "";

                    if (File.Exists(fullFileName))
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(fullFileName))
                        {
                            tmpRegistrationCodeText = reader.ReadLine();
                        }

                        string tmpSerial = ActCodeGenerator.GetSerialFromCode(tmpRegistrationCodeText);
                        ActivationCodeText = ActCodeGenerator.GenerateLicenseKey(tmpSerial);
                    }

                    RaisePropertyChanged(nameof(ActivationCodeText));
                });
            }
        }

        public ICommand SaveRegistrationCodeCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SerialText = WindowsParams.GetHwid(TypeActivate);
                    RegistrationCodeText = ActCodeGenerator.GetCodeFromSerial(SerialText);

                    string currentDir = System.IO.Directory.GetCurrentDirectory();
                    string fullFileName = Path.Combine(currentDir, registrationCodeFile);

                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fullFileName))
                    {
                        writer.WriteLine(RegistrationCodeText);
                    }

                    CheckActivation();
                });
            }
        }

        public TypeAppMode TypeAppMode
        {
            get
            {
                return typeAppMode;
            }

            set
            {
                typeAppMode = value;

                if (TypeAppMode == Primitives.TypeAppMode.DemoMode)
                {
                    IsEnableAppMode = true;
                }
                else
                {
                    IsEnableAppMode = false;
                }

                RaisePropertyChanged(nameof(IsEnableAppMode));
            }
        }

        public TypeActivate TypeActivate
        {
            get
            {
                return typeActivate;
            }

            set
            {
                typeActivate = value;
              
                SerialText = WindowsParams.GetHwid(TypeActivate);
                RegistrationCodeText = ActCodeGenerator.GetCodeFromSerial(SerialText);

                string tmpSerial = ActCodeGenerator.GetSerialFromCode(RegistrationCodeText);
                ActivationCodeText = ActCodeGenerator.GenerateLicenseKey(tmpSerial);

                RaisePropertyChanged(nameof(SerialText));
                RaisePropertyChanged(nameof(RegistrationCodeText));
                RaisePropertyChanged(nameof(ActivationCodeText));
            }
        }

        public bool IsEnableAppMode { get; set; }

        public string SerialText { get; set; }

        public string ActivationCodeText { get; set; }

        public string RegistrationCodeText { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IWindowService windowService, IMessageBoxService messageboxService) : base()
        {
            this.windowService = windowService;
            this.messageboxService = messageboxService;

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///

            // TypeAppMode = Primitives.TypeAppMode.DemoMode;
            TypeActivate = Primitives.TypeActivate.ActivateTypeDisk;

            CheckActivation();
        }

        private void CheckActivation()
        {
            TypeAppMode = TypeAppMode.DemoMode;

            string hwIddisk = WindowsParams.GetHwid(TypeActivate.ActivateTypeDisk);
            ActivationCodeText = ActCodeGenerator.GenerateLicenseKey(hwIddisk);

            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string fullFileName = Path.Combine(currentDir, activationCodeFile);

            string tmpActivationCodeText = "";

            if (File.Exists(fullFileName))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(fullFileName))
                {
                    tmpActivationCodeText = reader.ReadLine();
                }

                if (tmpActivationCodeText.Contains(ActivationCodeText))
                {
                    TypeAppMode = TypeAppMode.WorkMode;
                }
            }
        }

        private void Activatesoftware()
        {
            string hwIdFull = WindowsParams.GetHwid(TypeActivate.ActivateTypeProcessorAndDisk);

            string hwIdProcessor = WindowsParams.GetHwid(TypeActivate.ActivateTypeProcessor);

            string hwIddisk = WindowsParams.GetHwid(TypeActivate.ActivateTypeDisk);
        }

        private readonly IWindowService windowService;
        private readonly IMessageBoxService messageboxService;

        private TypeAppMode typeAppMode;
        private TypeActivate typeActivate;
    }
}