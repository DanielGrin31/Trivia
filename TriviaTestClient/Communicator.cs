using System;
using System.Net;
using System.Net.Sockets;

namespace TriviaTestClient
{
    public class Communicator
    {
        private TcpClient Client = new TcpClient();
        private NetworkStream stream;
        public IPAddress IP = IPAddress.Parse("127.0.0.1");
        private int port = 13000;

        public Communicator()
        {
            Connect();
        }

        public void Connect()
        {
            //Client= new TcpClient(new IPEndPoint(IP, port));
            Client.Connect(IP, port);
            stream = Client.GetStream();
        }

        public void Send(String message)
        {
            try
            {
                // Translate the Message into ASCII.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                // Bytes Array to receive Server Response.
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        public Message Recieve()
        {
            Int32 bytes = 0;
            Byte[] data = new Byte[4096];
            String response = String.Empty;
            // Read the Tcp Server Response Bytes.
            bytes = stream.Read(data, 0, data.Length);
            response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Message message = new Message(data, response);
            return message;
        }
    }
}