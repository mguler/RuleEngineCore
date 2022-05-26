namespace RuleEngineCore.Abstract
{
    public class Message
    {
        public string Code { get; set; }
        public string Text { get; private set; }
        public Priority Priority { get; private set; }
        public Message(string messageText, Priority priority = Priority.Error)
        {
            Text = messageText;
            Priority = priority;
        }
        public Message(string messageText, string code , Priority priority = Priority.Error)
        {
            Text = messageText;
            Code = code;
            Priority = priority;
        }
    }
}
