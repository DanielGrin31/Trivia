using System.Collections.Generic;
using TriviaClassLib;

namespace TriviaServer
{
    public interface IUsersRepository
    {
        User GetUserByUsername(string username);

        User AddUser(User user);

        User DeleteUser(User user);

        User UpdateUser(User newUser);

        IEnumerable<User> GetUsers();
    }
}