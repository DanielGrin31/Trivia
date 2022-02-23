using System;
using TriviaClassLib;

namespace TriviaServer
{
    public class SignupManager : ISignupManager
    {
        public SignupManager(IUsersRepository usersRepository, ILoggedUsersRepository loggedUsersRepository)
        {
            _UsersRepository = usersRepository;
            _LoggedUsersRepository = loggedUsersRepository;
        }

        public IUsersRepository _UsersRepository { get; set; }
        public ILoggedUsersRepository _LoggedUsersRepository { get; set; }

        public void Signup(string username, string password, string email)
        {
            // Signup request - create a user in the database, create a logged user, add it to the vector.

            // First we check if the user already exists
            bool userExists = _UsersRepository.GetUserByUsername(username) != null;
            if (userExists)
            {
                throw new Exception(ErrorGetter.GetUserAlreadyExists());
            }
            _UsersRepository.AddUser(new User(username, password, email));
            _LoggedUsersRepository.AddUser(new LoggedUser(username));
        }
    }
}