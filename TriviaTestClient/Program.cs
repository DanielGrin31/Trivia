using System;
using System.Text.Json;
using System.Threading;
using TriviaClassLib.Requests;

namespace TriviaTestClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Thread.Sleep(2000);
            Communicator c = new Communicator();
            //while (true)
            //{
            for (int i = 0; i < 2; i++)
            {
                string msg = "101|" + JsonSerializer.Serialize<LoginRequest>(new LoginRequest()
                {
                    username = "grinberg",
                    password = "2134"
                }); //Console.ReadLine();
                c.Send(msg);
                Console.WriteLine($"Recieved: {c.Recieve().message}");
            }
            //}

            Console.ReadLine();
        }
    }
}