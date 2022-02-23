using System.Collections.Generic;
using System.Linq;
using TriviaClassLib;

namespace TriviaServer
{
    public class LoggedUsersRepository : ILoggedUsersRepository
    {
        private List<LoggedUser> users;

        public LoggedUsersRepository()
        {
            users = new List<LoggedUser>()
            {
                new LoggedUser("daniel")
            };
        }

        public LoggedUser AddUser(LoggedUser user)
        {
            if (GetUserByUsername(user.GetUsername()) == null)
            {
                users.Add(user);
            }
            return user;
        }

        public LoggedUser DeleteUser(LoggedUser user)
        {
            users.RemoveAll(x => x.GetUsername() == user.GetUsername());
            return user;
        }

        public LoggedUser GetUserByUsername(string username)
        {
            return users.Where(x => x.GetUsername() == username).FirstOrDefault();
        }

        public IEnumerable<LoggedUser> GetUsers()
        {
            return users;
        }

        public LoggedUser UpdateUser(LoggedUser newUser)
        {
            LoggedUser oldUser = GetUserByUsername(newUser.GetUsername());
            if (oldUser != null)
            {
                oldUser.SetUsername(newUser.GetUsername());
            }
            return oldUser;
        }
    }
}