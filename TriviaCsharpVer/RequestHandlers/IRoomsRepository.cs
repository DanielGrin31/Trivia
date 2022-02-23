using System.Collections.Generic;
using TriviaClassLib;

namespace TriviaServer
{
    public interface IRoomsRepository
    {
        RoomMetadata AddRoom(RoomMetadata room);

        RoomMetadata DeleteRoom(RoomMetadata room);

        RoomMetadata GetRoomById(int id);

        IEnumerable<RoomMetadata> GetRooms();

        IEnumerable<RoomData> GetRoomsData();

        RoomMetadata UpdateRoom(RoomMetadata newRoom);
    }
}