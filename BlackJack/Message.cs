namespace TDDBlackJack
{
    public class Message
    {
        private Message(string content)
        {
            Content = content;
        }
        public Message(string content, Player sentTo, Player sentFrom) : this(content)
        {
            SentTo = sentTo;
            SentFrom = sentFrom;
        }
        public string Content { get; set;}
        public Player SentTo { get; set;}
        public Player SentFrom { get; set; }
    }
}
