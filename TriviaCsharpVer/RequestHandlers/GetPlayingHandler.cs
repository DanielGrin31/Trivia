using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TriviaClassLib;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class GetPlayingHandler
    {
        public static RequestResult HandleGetPlaying(GetPlayingRequest getPlayingRequest, IRoomsRepository roomsRepository)
        {
            try
            {
                int roomId = getPlayingRequest.roomId;
                var room=roomsRepository.GetRoomById(roomId);
                if (room!=null)
                {
                    List<string> names= room.GetAllPlayingUsersNames().ToList();
                    GetPlayingResponse response = new GetPlayingResponse()
                    {
                        playingUsers = names
                    };
                    string serializedResponse = JsonSerializer.Serialize(response);
                    RequestResult result = new RequestResult()
                    {
                        Buffer = serializedResponse
                    };
                    return result;
                }
                else
                {
                    throw new Exception(ErrorGetter.GetRoomDoesNotExist());
                }
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }
    }
}