namespace TriviaServer
{
    public interface IApplication
    {
        IServer server { get; set; }

        void Run();
    }
}