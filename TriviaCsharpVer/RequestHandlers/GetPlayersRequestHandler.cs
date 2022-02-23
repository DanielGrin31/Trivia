using System;
using System.Collections.Generic;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Requests;
using TriviaClassLib.Responses;
using TriviaServer.Utility;

namespace TriviaServer.RequestHandlers
{
    public class GetPlayersRequestHandler
    {
        public static RequestResult HandleGetPlayers(GetPlayersRequest request, IRoomsRepository roomsRepository)
        {
            var room = roomsRepository.GetRoomById(request.roomId);
            if (room != null)
            {
                List<string> users = (List<string>)room.GetAllUsersNames();
                GetPlayersResponse response = new GetPlayersResponse
                {
                    players = users
                };
                var result = new RequestResult();
                result.Buffer = JsonSerializer.Serialize(response, typeof(GetPlayersResponse));
                return result;
            }
            else
            {
                return ErrorMaker.MakeError(new Exception(ErrorGetter.GetRoomDoesNotExist()));
            }
        }
    }
}