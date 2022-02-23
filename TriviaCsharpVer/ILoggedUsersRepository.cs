using System.Collections.Generic;
using TriviaClassLib;

namespace TriviaServer
{
    public interface ILoggedUsersRepository
    {
        LoggedUser GetUserByUsername(string username);

        LoggedUser AddUser(LoggedUser user);

        LoggedUser DeleteUser(LoggedUser user);

        LoggedUser UpdateUser(LoggedUser newUser);

        IEnumerable<LoggedUser> GetUsers();
    }
}