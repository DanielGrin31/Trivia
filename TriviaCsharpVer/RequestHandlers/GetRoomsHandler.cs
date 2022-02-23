using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Responses;

namespace TriviaServer.RequestHandlers
{
    public class GetRoomsHandler
    {
        public static RequestResult HandleGetRooms(IRoomsRepository roomsRepository)
        {
            List<RoomData> roomData = roomsRepository.GetRoomsData().Where(x=>x.isActive).ToList();
            GetRoomsResponse response = new GetRoomsResponse()
            {
                rooms = roomData,
                status = 55
            };
            RequestResult result = new RequestResult()
            {
                Buffer = JsonSerializer.Serialize<GetRoomsResponse>(response)
            };
            return result;
        }
    }
}