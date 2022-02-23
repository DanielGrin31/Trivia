using System.Runtime.Serialization;

namespace TriviaClassLib.Requests
{
    public class GetPlayersRequest : ISerializable
    {
        public int roomId { get; set; }

        public GetPlayersRequest()
        {
        }

        public GetPlayersRequest(SerializationInfo info, StreamingContext context)
        {
            roomId = info.GetInt32(nameof(roomId));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(roomId), roomId);
        }
    }
}