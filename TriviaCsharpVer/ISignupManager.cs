namespace TriviaServer
{
    public interface ISignupManager
    {
        IUsersRepository _UsersRepository { get; set; }
        ILoggedUsersRepository _LoggedUsersRepository { get; set; }

        void Signup(string name, string password, string email);
    }
}