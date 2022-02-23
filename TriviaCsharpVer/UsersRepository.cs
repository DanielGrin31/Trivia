using System.Collections.Generic;
using System.Linq;
using TriviaClassLib;

namespace TriviaServer
{
    public class UsersRepository : IUsersRepository
    {
        private List<User> users;

        public UsersRepository()
        {
            users = new List<User>()
            {
                new User("daniel","2134"," "),
                new User("grinberg","2134"," "),
                new User("a","s"," "),
                new User("hi","1"," "),
            };
        }

        public User AddUser(User user)
        {
            if (GetUserByUsername(user.GetUsername()) == null)
            {
                users.Add(user);
            }
            return user;
        }

        public User DeleteUser(User user)
        {
            users.RemoveAll(x => x.GetUsername() == user.GetUsername());
            return user;
        }

        public User GetUserByUsername(string username)
        {
            return users.Where(x => x.GetUsername() == username).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User UpdateUser(User newUser)
        {
            User oldUser = GetUserByUsername(newUser.GetUsername());
            if (oldUser != null)
            {
                oldUser.SetPassword(newUser.GetPassword());
                oldUser.SetUsername(newUser.GetUsername());
            }
            return oldUser;
        }
    }
}