namespace TriviaServer
{
    public interface IServer
    {
        IRoomsRepository _RoomsRepository { get; set; }
        IMainRequestHandler _RequestHandler { get; set; }

        void HandleDeivce(object obj);

        void StartListener();
    }
}