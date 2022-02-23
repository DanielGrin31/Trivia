using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TriviaClassLib.Responses
{
    public class GetPlayersResponse : ISerializable
    {
        public List<string> players { get; set; } = new List<string>();

        public GetPlayersResponse()
        {
        }

        public GetPlayersResponse(SerializationInfo info, StreamingContext context)
        {
            players = (List<string>)info.GetValue("players", typeof(List<string>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("players", players);
        }
    }
}