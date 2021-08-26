using GalaSoft.MvvmLight.Messaging;
using System;

namespace GuessTheNumber.Utils
{
    enum MessageTypes
    {
        ChangeMainView
    }

    public static class ChangeMainViewMessage
    {
        public static void Send(string message)
        {
            Messenger.Default.Send(message, MessageTypes.ChangeMainView);
        }

        public static void Register(object recipient, Action<string> action)
        {
            Messenger.Default.Register<string>(recipient, MessageTypes.ChangeMainView, action);
        }
    }
}
