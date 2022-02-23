namespace TriviaClassLib
{
    public class Message
    {
        public byte[] buffer;
        public string message;
        public bool erroredOut = false;

        public Message(byte[] buf, string mes)
        {
            this.buffer = buf;
            this.message = mes;
        }
    }
}