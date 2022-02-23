namespace TriviaServer
{
    public interface ILoginManager
    {
        ILoggedUsersRepository _LoggedUsersRepository { get; set; }
        IUsersRepository _UsersRepository { get; set; }

        void Login(string name, string password);
    }
}