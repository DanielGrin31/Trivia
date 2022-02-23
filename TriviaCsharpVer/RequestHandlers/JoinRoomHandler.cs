using GUI.ServerCommunication.Responses;
using System;
using System.Linq;
using System.Text.Json;
using TriviaClassLib;

namespace TriviaServer
{
    public class JoinRoomHandler
    {
        public static RequestResult HandleJoinRoom(string username, int roomId, IRoomsRepository roomsRepository, ILoggedUsersRepository loggedUsersRepository)
        {
            RoomMetadata room = roomsRepository.GetRoomById(roomId);
            bool roomExists = room != null;
            if (roomExists == false)
            {
                throw new Exception(ErrorGetter.GetRoomDoesNotExist());
            }
            if (room.IsActive()==false)
            {
                throw new Exception(ErrorGetter.GetRoomIsNotActive());
            }

            LoggedUser user = loggedUsersRepository.GetUserByUsername(username);
            bool userLoggedIn = user != null;
            if (userLoggedIn == false)
            {
                throw new Exception(ErrorGetter.GetUserNotLoggedIn());
            }
            bool userExistsInRoom = room.GetAllUsersNames().Where(x => x == username).FirstOrDefault() != null;
            if (userExistsInRoom)
            {
                throw new Exception(ErrorGetter.GetUserAlreadyExistsInRoom());
            }

            room.AddUser(user);
            room.playingUsers.Add(user);
            if (room.IsFull())
            {
                room.SetInactive();
            }
            JoinRoomResponse response = new JoinRoomResponse()
            {
                status = (int)Codes.JOINROOM
            };
            return new RequestResult()
            {
                Buffer = JsonSerializer.Serialize(response)
            };
        }
    }
}