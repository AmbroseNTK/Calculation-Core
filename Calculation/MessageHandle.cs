using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{

    public class MessageHandle
    {
        public enum MessageType
        {
            Info,
            Warning,
            Error,
        }

        public class Message
        {
            private MessageType messageType;
            private string messageText;

            public Message() { }
            public Message(MessageType messageType, string messageText)
            {
                this.MessageType = messageType;
                this.MessageText = messageText;
            }

            public MessageType MessageType { get => messageType; set => messageType = value; }
            public string MessageText { get => messageText; set => messageText = value; }
        }

        private MessageHandle()
        {
            messageList = new List<Message>();
            errorFlag = false;
        }
        private static MessageHandle instance;
        public static MessageHandle GetInstance()
        {
            if (instance == null)
            {
                instance = new MessageHandle();
            }
            return instance;
        }

        private bool errorFlag;


        private List<Message> messageList;

        public List<Message> MessageList { get => messageList; set => messageList = value; }
        public bool ErrorFlag { get => errorFlag; set => errorFlag = value; }

        public List<Message> GetFilteredMessages(Func<Message,bool> filter)
        {
            return messageList.Where(filter).ToList(); 
        }

        public void DeleteFilteredMessages(Func<Message,bool> filter)
        {
            List<Message> removedList = GetFilteredMessages(filter);
            foreach(Message message in removedList)
            {
                messageList.Remove(message);
            }
        }

        public void ClearMessage()
        {
            messageList.Clear();
        }

        public void ClearAll()
        {
            ClearMessage();
            errorFlag = false;
        }


    }
}
