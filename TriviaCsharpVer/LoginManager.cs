using System;
using TriviaClassLib;

namespace TriviaServer
{
    public class LoginManager : ILoginManager
    {
        public IUsersRepository _UsersRepository { get; set; }
        public ILoggedUsersRepository _LoggedUsersRepository { get; set; }

        public LoginManager(IUsersRepository usersRepository, ILoggedUsersRepository loggedUsersRepository)
        {
            _UsersRepository = usersRepository;
            _LoggedUsersRepository = loggedUsersRepository;
        }

        public void Login(string name, string password)
        {
            // Login Request - Check if user exists, if yes - log him in.
            bool userExists = _UsersRepository.GetUserByUsername(name) != null;
            if (userExists == false)
            {
                throw new Exception(ErrorGetter.GetUserDoesNotExist());
            }
            bool PasswordMatches = _UsersRepository.GetUserByUsername(name).GetPassword() == password;
            if (PasswordMatches == false)
            {
                throw new Exception(ErrorGetter.GetWrongPassword());
            }
            if (_LoggedUsersRepository.GetUserByUsername(name) != null)
            {
                throw new Exception(ErrorGetter.GetUserLoggedIn());
            }
            LoggedUser user = new LoggedUser(name);
            _LoggedUsersRepository.AddUser(user);
        }
    }
}