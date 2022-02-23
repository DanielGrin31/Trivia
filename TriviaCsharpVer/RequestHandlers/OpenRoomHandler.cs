using System;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Responses;

namespace TriviaServer
{
    public class OpenRoomHandler
    {
        public static RequestResult HandleOpenRoom(IRoomsRepository roomsRepository, int roomId, string username)
        {
            RoomMetadata room = roomsRepository.GetRoomById(roomId);
            if (room != null)
            {
                if (room.GetUserByUsername(username) != null)
                {
                    bool isHost = room.Host?.GetUsername() == username;
                    OpenRoomResponse response = new OpenRoomResponse()
                    {
                        IsHost = isHost
                    };
                    RequestResult requestResult = new RequestResult()
                    {
                        Buffer = JsonSerializer.Serialize<OpenRoomResponse>(response)
                    };
                    return requestResult;
                }
                else
                {
                    throw new Exception(ErrorGetter.GetUserDoesNotExistInRoom());
                }
            }
            else
            {
                throw new Exception(ErrorGetter.GetRoomDoesNotExist());
            }
        }
    }
}