namespace AppWithLocks.Infrastructure.Abstractions
{
    /// <summary>
    /// Интерфейс службы, отвечающей за создание диалоговых окон
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Порождает модальное (блокирующее) окно диалога
        /// </summary>
        /// <param name="message">Сообщение для отображения</param>
        /// <param name="messageboxKind">Тип сообщения</param>
        /// <param name="title">Заголовок модального окна</param>
        /// <returns>Ответ пользователя (выбранный им в ходе работы с диалогом)</returns>
        MessageboxResponse ShowMessagebox(string message, MessageboxKind messageboxKind, string title = null);
    }
}
