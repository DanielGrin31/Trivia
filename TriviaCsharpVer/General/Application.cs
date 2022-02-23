using System;
using System.Threading;

namespace TriviaServer
{
    public class Application : IApplication
    {
        public IServer server { get; set; }

        public Application(IServer server)
        {
            this.server = server;
        }

        public void Run()
        {
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                server.StartListener();
            });
            t.Start();

            Console.WriteLine("Server Started...!");
        }
    }
}