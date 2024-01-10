using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

using GalaSoft.MvvmLight;
using Ninject;
using Ninject.Parameters;
using AppWithLocks.Infrastructure.Abstractions;
using System.ComponentModel;
using System.Windows;

namespace AppWithLocks.Infrastructure
{
    /// <summary>
    /// Реализация интерфейса <see cref="IWindowService"/> в соответствии с требованиями MVVM-паттерна
    /// </summary>
    public class WindowService : IWindowService
    {
        /// <inheritdoc />
        public void OpenWindow<T>(string viewName, object model = null) where T : ViewModelBase
        {
            FindWindow<T>(viewName, model).Show();
        }

        /// <inheritdoc />
        public void OpenWindow<T>(object model = null) where T : ViewModelBase
        {
            FindWindow<T>(null, model).Show();
        }

        /// <inheritdoc />
        public void OpenDialog<T>(string viewName, object model = null) where T : ViewModelBase
        {
            FindWindow<T>(viewName, model).ShowDialog();
        }

        /// <inheritdoc />
        public void OpenDialog<T>(object model = null) where T : ViewModelBase
        {
            FindWindow<T>(null, model).ShowDialog();
        }

        /// <summary>
        /// Выполняет подбор наболее подходящего типа представления и создаёт его экземпляр
        /// </summary>
        /// <typeparam name="T">
        /// Тип менеджера представления окна (класса, выступающего в роли DataContext создаваемого окна)
        /// </typeparam>
        /// <param name="viewName">
        /// Имя представления. Это имя будет использоваться для поиска подходящего типа создаваемого окна.
        /// Если не указано, для поиска будет использоваться имя типа менеджера, причём
        /// суффикс -ViewModel будет заменён на -Window.
        /// </param>
        /// <param name="model">
        /// Экземпляр, передаваемый в аргументы конструктора менеджера представления
        /// </param>
        /// <returns>The window</returns>
        private Window FindWindow<T>(string viewName, object model) where T : ViewModelBase
        {
            var windowName = string.Empty;
            var viewModelName = typeof(T).Name;
            if (!string.IsNullOrEmpty(viewName))
            {
                windowName = viewName;
            }
            else
            {
                windowName = viewModelName.Substring(0, viewModelName.Length - 9) + "Window";
            }

            Debug.WriteLine(string.Format("WindowService.FindWindow :: Looking for window '{0}' for view model '{1}', view name override = '{2}'", windowName, viewModelName, viewName));

            Type windowType;

            windowType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => typeof(WindowView).IsAssignableFrom(t) && t.Name == windowName);
            if (windowType == null)
            {
                windowType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => typeof(Window).IsAssignableFrom(t) && t.Name == windowName);
                if (windowType == null)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Unable to find Window for view model {0}", typeof(T)));
                }
                else
                {
                    var window = (Window)Assembly.GetExecutingAssembly().CreateInstance(windowType.FullName);
                    return window;
                }
            }
            else
            {
                // Инъекция аргумента в конструктор
                var modelArgument = new ConstructorArgument("model", model);

                var window = (Window)Assembly.GetExecutingAssembly().CreateInstance(windowType.FullName);
                if (model != null)
                    window.DataContext = model;
                else
                    window.DataContext = AppWithLocksApplication.Current.Container.Get<T>(modelArgument);
                return window;
            }
        }
    }
}
