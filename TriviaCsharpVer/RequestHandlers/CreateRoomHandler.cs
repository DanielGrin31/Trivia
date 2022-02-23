using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Requests;
using TriviaClassLib.Responses;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class CreateRoomHandler
    {
        public static RequestResult HandleCreateRoom(CreateRoomRequest CreateRequest, IRoomsRepository _RoomsRepository)
        {
            try
            {
                // Check if a room already exists under this player's name
                List<RoomMetadata> rooms = _RoomsRepository.GetRooms().ToList();
                if (rooms.Exists(x => x.GetData().name == "Room of " + CreateRequest.name))
                {
                    throw new Exception(ErrorGetter.GetRoomWithUsernameAlreadyExists());
                }
                int id = 0;
                for (int i = 0; i <= rooms.Count; i++)
                {
                    if (_RoomsRepository.GetRoomById(i) == null)
                    {
                        id = i;
                        break;
                    }
                }

                RoomMetadata room = new RoomMetadata
                {
                    Host = new LoggedUser(CreateRequest.name),
                    users = new List<LoggedUser>() { new LoggedUser(CreateRequest.name) }
                };
                room.SetData(new RoomData()
                {
                    id = id,
                    isActive = true,
                    maxPlayers = CreateRequest.maxUsers,
                    name = "Room of " + CreateRequest.name,
                    timePerQuestion = CreateRequest.answerTimeout
                });

                _RoomsRepository.AddRoom(room);
                CreateRoomResponse createRoomResponse = new CreateRoomResponse()
                {
                    roomId = id
                };
                RequestResult result = new RequestResult()
                {
                    Buffer = JsonSerializer.Serialize<CreateRoomResponse>(createRoomResponse)
                };
                return result;
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }
    }
}