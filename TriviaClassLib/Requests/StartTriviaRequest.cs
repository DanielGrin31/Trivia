using System.Collections.Generic;
using System.Runtime.Serialization;
using TriviaClassLib.Models;

namespace TriviaClassLib.Requests
{
    public class StartTriviaRequest : ISerializable
    {
        public int roomId { get; set; }
        public IEnumerable<Question> Questions { get; set; }

        public StartTriviaRequest()
        {
        }

        public StartTriviaRequest(SerializationInfo info, StreamingContext context)
        {
            roomId = info.GetInt32(nameof(roomId));
            Questions = (IEnumerable<Question>)info.GetValue(nameof(Questions), typeof(IEnumerable<Question>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(roomId), roomId);
            info.AddValue(nameof(Questions), Questions);
        }
    }
}