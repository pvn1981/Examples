using System;

using Ninject;

using AppWithLocks.Infrastructure.Abstractions;

namespace AppWithLocks.Infrastructure
{
        /// <summary>
        /// Представляет информацию о текущем экземпляре MVVM-приложения.
        /// Служит локатором для высокоуровневых компонентов.
        /// </summary>
        public class AppWithLocksApplication
    {
            /// <summary>
            /// Текущий экземпляр приложения
            /// </summary>
            private static AppWithLocksApplication current;

            /// <summary>
            /// Маркер первичной загрузки приложения.
            /// </summary>
            private bool hasBootstrapped = false;

            /// <summary>
            /// Этот конструктор защищён от прямого вызова
            /// </summary>
            private AppWithLocksApplication()
            {
            }

            /// <summary>
            /// Возвращает текущий экземпляр приложения
            /// </summary>
            public static AppWithLocksApplication Current
            {
                get
                {
                    if (current == null)
                    {
                        current = new AppWithLocksApplication();
                    }

                    return current;
                }
            }

            /// <summary>
            /// Возвращает контейнер зависимостей
            /// </summary>
            public IKernel Container { get; private set; }

            /// <summary>
            /// Выполняет первичную загрузку приложения, включая создание всех высокоуровневых компонентов
            /// </summary>
            public void Bootstrap()
            {
                if (this.hasBootstrapped)
                {
                    throw new InvalidOperationException("Illegal attempt to bootstrap the application twice.");
                }

                // Настраиваем контейнер зависимостей
                this.Container = new StandardKernel(new DependencyContainer());

                // Создание и регистрация зависимостей
                this.Container.Bind<IWindowService>().To<WindowService>();
                this.Container.Bind<IMessageBoxService>().To<MessageboxService>();

                // Завершаем инициализацию установкой флага
                this.hasBootstrapped = true;
            }
        }
}
