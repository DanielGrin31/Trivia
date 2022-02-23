using System.Collections.Generic;
using System.Linq;
using TriviaClassLib;

namespace TriviaServer
{
    public class RoomsRepository : IRoomsRepository
    {
        private List<RoomMetadata> rooms;

        public RoomsRepository()
        {
            rooms = new List<RoomMetadata>()
            {
                new RoomMetadata(
                new RoomData()
                {
                    id=0,
                    isActive=true,
                    maxPlayers=3,
                    name="daniel",
                    timePerQuestion=10
                },new List<LoggedUser>(){
                    new LoggedUser("daniel")
                })
            };
        }

        public RoomMetadata GetRoomById(int id)
        {
            return rooms.Where(x => x.GetId() == id).FirstOrDefault();
        }

        public IEnumerable<RoomMetadata> GetRooms()
        {
            return rooms;
        }

        public RoomMetadata AddRoom(RoomMetadata room)
        {
            if (rooms.Exists(x => x.GetId() == room.GetId()) == false)
            {
                rooms.Add(room);
            }
            return room;
        }

        public RoomMetadata DeleteRoom(RoomMetadata room)
        {
            rooms.RemoveAll(x => x.GetId() == room.GetId());
            return room;
        }

        public RoomMetadata UpdateRoom(RoomMetadata newRoom)
        {
            var oldRoom = rooms.Where(x => x.GetId() == newRoom.GetId()).FirstOrDefault();
            if (oldRoom != null)
            {
                oldRoom.GetData().isActive = newRoom.GetData().isActive;
                oldRoom.GetData().maxPlayers = newRoom.GetData().maxPlayers;
                oldRoom.GetData().name = newRoom.GetData().name;
                oldRoom.GetData().timePerQuestion = newRoom.GetData().timePerQuestion;
                oldRoom.users = newRoom.users;
            }
            return oldRoom;
        }

        public IEnumerable<RoomData> GetRoomsData()
        {
            List<RoomData> RoomsData = new List<RoomData>();
            foreach (var roomMetaData in rooms)
            {
                if (roomMetaData != null)
                {
                    if (roomMetaData.GetData() != null)
                    {
                        RoomsData.Add(roomMetaData.GetData());
                    }
                }
            }
            return RoomsData;
        }
    }
}