using System.Collections.Generic;

namespace TriviaClassLib.Responses
{
    public class GetRoomsResponse
    {
        public int status { get; set; }
        public List<RoomData> rooms { get; set; } = new List<RoomData>();
    }
}