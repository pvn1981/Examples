using System;
using GalaSoft.MvvmLight;

namespace AppWithLocks.Infrastructure.Abstractions
{
    /// <summary>
    /// Интерфейс службы, отвечающей за создания и управления окнами приложения
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Открывает окно, соответствующее указанному типу менеджера
        /// </summary>
        /// <typeparam name="T">
        /// Тип менеджера представления
        /// </typeparam>
        /// <param name="viewName">
        /// Имя класса представления, которое требуется открыть
        /// </param>
        /// <param name="model">
        /// Экземпляр, передаваемый в конструктор менеджера представления (т.н. модель в MVVM-паттерне)
        /// </param>
        void OpenWindow<T>(string viewName, object model = null) where T : ViewModelBase;

        /// <summary>
        /// Открывает окно, соответствующее указанному типу менеджера
        /// </summary>
        /// <typeparam name="T">
        /// Тип менеджера представления
        /// </typeparam>
        /// <param name="model">
        /// Экземпляр, передаваемый в конструктор менеджера представления (т.н. модель в MVVM-паттерне)
        /// </param>
        void OpenWindow<T>(object model = null) where T : ViewModelBase;

        /// <summary>
        /// Открывает модальное окно, соответствующее указанному типу менеджера
        /// </summary>
        /// <typeparam name="T">
        /// Тип менеджера представления
        /// </typeparam>
        /// <param name="viewName">
        /// Имя класса представления, которое требуется открыть
        /// </param>
        /// <param name="model">
        /// Экземпляр, передаваемый в конструктор менеджера представления (т.н. модель в MVVM-паттерне)
        /// </param>
        void OpenDialog<T>(string viewName, object model = null) where T : ViewModelBase;

        /// <summary>
        /// Открывает модальное окно, соответствующее указанному типу менеджера
        /// </summary>
        /// <typeparam name="T">
        /// Тип менеджера представления
        /// </typeparam>
        /// <param name="model">
        /// Экземпляр, передаваемый в конструктор менеджера представления (т.н. модель в MVVM-паттерне)
        /// </param>
        void OpenDialog<T>(object model = null) where T : ViewModelBase;
    }
}
