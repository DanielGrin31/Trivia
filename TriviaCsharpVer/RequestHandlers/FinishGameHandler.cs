using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Models;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class FinishGameHandler
    {
        public static RequestResult HandleFinishGames(FinishGameRequest finishGameRequest, ArrayList connections, IRoomsRepository roomsRepository)
        {
            string username = finishGameRequest.username;
            int roomId = finishGameRequest.roomId;
            var room = roomsRepository.GetRoomById(roomId);
            if (room != null)
            {
                bool finished = false;
                LoggedUser loggedUser = room.GetUserByUsername(username);
                room.playingUsers.RemoveAll(x => x.username == loggedUser.username);

                if (room.playingUsers.Count == 0)
                {
                    finished = true;
                    var Relevantconnections = connections.ToArray().Where(x => ((Connection)x).roomId == roomId/*&&((Connection)x).username==username*/);
                    string json = JsonSerializer.Serialize(new FinishGameResponse() { Finished = true, IsHost = false });
                    foreach (var connection in Relevantconnections)
                    {
                        var stream = ((Connection)connection).stream;
                        if (stream != null && stream.CanWrite)
                        {
                            stream.Write(Encoding.ASCII.GetBytes(json));
                            Console.WriteLine(json);
                        } 
                    }
                }
                if (finished==false)
                {
                    return new RequestResult()
                    {
                        Buffer = JsonSerializer.Serialize(new FinishGameResponse() { Finished = false })
                    };
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception(ErrorGetter.GetRoomDoesNotExist());
            }
        }

    }
}
