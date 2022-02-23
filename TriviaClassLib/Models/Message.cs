namespace TriviaTestClient
{
    public class Message
    {
        #region Fields
        /// <summary>
        /// Buffer where the messages are stored
        /// </summary>
        public byte[] buffer;
        /// <summary>
        /// the actual message translation of the buffer
        /// </summary>
        public string message;
        /// <summary>
        /// boolean property that indicates if the message is an error message
        /// </summary>
        public bool erroredOut = false;
        #endregion

        #region Constructors
        public Message(byte[] buf, string mes)
        {
            this.buffer = buf;
            this.message = mes;
        } 
        #endregion
    }
}