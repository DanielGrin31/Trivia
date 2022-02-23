using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TriviaClassLib
{
    /// <summary>
    /// a trivia Room model that contains data about the room,host and users
    /// </summary>
    public class RoomMetadata : ISerializable
    {
        #region Fields
        [JsonRequired]
        private RoomData roomData;
        public List<LoggedUser> users { get; set; }
        public List<LoggedUser> playingUsers { get; set; } = new List<LoggedUser>();
        public LoggedUser Host { get; set; }
        #endregion

        #region Constructors
        public RoomMetadata()
        {
        }

        public RoomMetadata(SerializationInfo info, StreamingContext context)
        {
            roomData = (RoomData)info.GetValue(nameof(roomData), typeof(RoomData));
            Host = (LoggedUser)info.GetValue(nameof(Host), typeof(LoggedUser));
            users = (List<LoggedUser>)info.GetValue(nameof(users), typeof(List<LoggedUser>));
        }

        public RoomMetadata(RoomData roomData, List<LoggedUser> users)
        {
            this.roomData = roomData;
            this.users = users;
        }
        #endregion

        #region Methods
        public LoggedUser GetUserByUsername(string username)
        {
            return users.Where(x => x.GetUsername() == username).FirstOrDefault();
        }

        public int GetId()
        {
            return roomData.id;
        }

        public void SetData(RoomData value)
        {
            roomData = value;
        }

        public RoomData GetData()
        {
            return roomData;
        }

        public void AddUser(LoggedUser user)
        {
            if (users.Exists(x => x.GetUsername() == user.GetUsername()) == false)
            {
                users.Add(user);
            }
        }

        public void RemoveUser(LoggedUser user)
        {
            users.RemoveAll(x => x.GetUsername() == user.GetUsername());
        }

        public IEnumerable<LoggedUser> GetAllUsers()
        {
            return users;
        }
        public IEnumerable<LoggedUser> GetAllPlayingUsers()
        {
            return playingUsers;
        }

        public IEnumerable<string> GetAllPlayingUsersNames()
        {
            List<string> names = new List<string>();
            foreach (var user in playingUsers)
            {
                if (user != null)
                {
                    names.Add(user.GetUsername());
                }
            }
            return names;
        }

        public IEnumerable<string> GetAllUsersNames()
        {
            List<string> names = new List<string>();
            foreach (var user in users)
            {
                if (user != null)
                {
                    names.Add(user.GetUsername());
                }
            }
            return names;
        }
        public bool IsFull()
        {
            return roomData.maxPlayers <= users.Count;
        }
        public bool IsActive()
        {
            return roomData.isActive;
        }
        public void SetInactive()
        {
            roomData.isActive = false;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(("roomData"), GetData());
            info.AddValue(nameof(Host), Host);
            info.AddValue(nameof(users), users);
        } 
        #endregion
    }
}