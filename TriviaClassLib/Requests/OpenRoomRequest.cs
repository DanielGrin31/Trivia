using System.Runtime.Serialization;

namespace TriviaClassLib.Requests
{
    public class OpenRoomRequest : ISerializable
    {
        public int roomId { get; set; }
        public string username { get; set; }

        public OpenRoomRequest()
        {
        }

        public OpenRoomRequest(SerializationInfo info, StreamingContext context)
        {
            roomId = info.GetInt32(nameof(roomId));
            username = info.GetString(nameof(username));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(roomId), roomId);
            info.AddValue(nameof(username), username);
        }
    }
}