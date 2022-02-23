using System.Net.Sockets;

namespace TriviaClassLib.Models
{
    /// <summary>
    /// Class that represents a connect to a user in a room
    /// </summary>
    public class Connection
    {
        #region Fields
        /// <summary>
        /// username associated with connection
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// The id of the room
        /// </summary>
        public int roomId { get; set; }
        /// <summary>
        /// The stream(client) the connection is representing
        /// </summary>
        public NetworkStream stream { get; set; } 
        #endregion
    }
}