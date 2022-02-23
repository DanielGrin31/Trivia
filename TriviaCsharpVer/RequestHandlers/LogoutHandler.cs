using TriviaClassLib;

namespace TriviaServer
{
    public class LogoutHandler
    {
        public static RequestResult HandleLogout(string name, ILoggedUsersRepository loggedUsersRepository)
        {
            loggedUsersRepository.DeleteUser(loggedUsersRepository.GetUserByUsername(name));
            return new RequestResult();
        }
    }
}