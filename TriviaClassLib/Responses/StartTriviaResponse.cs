using System.Runtime.Serialization;

namespace TriviaClassLib
{
    public class StartTriviaResponse : ISerializable
    {
        public RoomMetadata room { get; set; }

        public StartTriviaResponse()
        {
        }

        public StartTriviaResponse(SerializationInfo info, StreamingContext context)
        {
            room = (RoomMetadata)info.GetValue(nameof(room), typeof(RoomMetadata));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(room), room);
        }
    }
}