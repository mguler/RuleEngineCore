using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineCore.Abstract
{
    public class Message
    {
        public string Text { get; private set; }
        public Priority Priority { get; private set; }
        public Message(string messageText,Priority priority = Priority.Error)
        {
            Text = messageText;
            Priority = priority;
        }
    }
}
