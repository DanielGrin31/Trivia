using System.Runtime.Serialization;

namespace TriviaClassLib
{
    public class LoggedUser : ISerializable
    {
        #region Fields
        /// <summary>
        /// Usernmae of the logged user
        /// </summary>
        public string username { get; set; }
        #endregion

        #region Constructors
        public LoggedUser(SerializationInfo info, StreamingContext context)
        {
            username = info.GetString(nameof(username));
        }

        public LoggedUser(string username)
        {
            this.username = username;
        }

        public LoggedUser()
        {
        }
        #endregion

        #region Methods
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(username), username);
        }

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        } 
        #endregion
    }
}