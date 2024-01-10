using AppWithLocks.Infrastructure;
using AppWithLocks.Infrastructure.Abstractions;

namespace AppWithLocks.DesignTime
{
    internal class MockMessageBoxService : IMessageBoxService
    {
        public MessageboxResponse ShowMessagebox(string message, MessageboxKind messageboxKind, string title = null)
        {
            return MessageboxResponse.Ok;
        }
    }
}