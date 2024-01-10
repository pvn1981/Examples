using AppWithLocks.Infrastructure.Abstractions;
using System;
using System.Windows;

namespace AppWithLocks.Infrastructure
{
    /// <summary>
    /// Реализация интерфейса <see cref="IMessageBoxService"/> для WPF
    /// </summary>
    public class MessageboxService : IMessageBoxService
    {
        /// <inheritdoc />
        public MessageboxResponse ShowMessagebox(string message, MessageboxKind messageboxKind, string title = null)
        {
            var result = MessageBox.Show(message, title, GetButtonFromMessageBoxKind(messageboxKind));
            return GetMessageboxResponseFromResult(result);
        }

        private static MessageboxResponse GetMessageboxResponseFromResult(MessageBoxResult messageboxResult)
        {
            switch (messageboxResult)
            {
                case MessageBoxResult.Cancel:
                    return MessageboxResponse.Cancel;

                case MessageBoxResult.No:
                    return MessageboxResponse.No;

                case MessageBoxResult.None:
                    return MessageboxResponse.None;

                case MessageBoxResult.OK:
                    return MessageboxResponse.Ok;

                case MessageBoxResult.Yes:
                    return MessageboxResponse.Yes;

                default:
                    throw new ArgumentException(string.Format("Unsupported message box result '{0}'"), messageboxResult.ToString());
            }
        }

        private static MessageBoxButton GetButtonFromMessageBoxKind(MessageboxKind messageboxKind)
        {
            switch (messageboxKind)
            {
                case MessageboxKind.Ok:
                    return MessageBoxButton.OK;

                case MessageboxKind.OKCancel:
                    return MessageBoxButton.OKCancel;

                case MessageboxKind.YesNo:
                    return MessageBoxButton.YesNo;

                case MessageboxKind.YesNoCancel:
                    return MessageBoxButton.YesNoCancel;

                default:
                    throw new ArgumentException(string.Format("Unsupported message box kind '{0}'"), messageboxKind.ToString());
            }
        }
    }
}

