using Newtonsoft.Json;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using TriviaClassLib;
using TriviaClassLib.Models;
using TriviaClassLib.Requests;

namespace TriviaServer
{
    public class StartTriviaHandler
    {
        public static RequestResult HandleStartTrivia(StartTriviaRequest startTriviaRequest, IRoomsRepository roomsRepository, ArrayList connections)
        {
            int roomId = startTriviaRequest.roomId;
            var room = roomsRepository.GetRoomById(roomId);
            if (room != null)
            {
                StartTriviaData data = new StartTriviaData()
                {
                    room = room,
                    Questions = startTriviaRequest.Questions
                };
                string json = JsonConvert.SerializeObject(data);
                var relevantConnections = connections.ToArray().Where(x => ((Connection)x).roomId == roomId
                 && ((Connection)x).username != room.Host?.GetUsername());
                foreach (var connection in relevantConnections)
                {
                    var stream = ((Connection)connection).stream;
                    if (stream != null && stream.CanWrite)
                    {
                        stream.Write(Encoding.ASCII.GetBytes(json));
                    }
                }
                room.SetInactive();
                StartTriviaResponse response = new StartTriviaResponse()
                {
                    room = data.room,
                };
                return new RequestResult()
                {
                    Buffer = JsonConvert.SerializeObject(response)
                };
            }
            else
            {
                throw new Exception(ErrorGetter.GetRoomDoesNotExist());
            }
        }
    }
}