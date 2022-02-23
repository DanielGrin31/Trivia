using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using TriviaClassLib;
using TriviaClassLib.Requests;

namespace TriviaServer
{
    public class Server : IServer
    {
        public IRoomsRepository _RoomsRepository { get; set; }
        public IMainRequestHandler _RequestHandler { get; set; }
        private TcpListener server = null;
        public ArrayList _Connections { get; set; } = new ArrayList();

        public Server(IRoomsRepository roomsRepository, IMainRequestHandler requestHandler, string ip = "127.0.0.1", int port = 13000)
        {
            _RequestHandler = requestHandler;
            _RoomsRepository = roomsRepository;
            IPAddress localAddr = IPAddress.Parse(ip);
            server = new TcpListener(localAddr, port);
            server.Start();
            _RequestHandler._Connections = _Connections;
        }

        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }

        public void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;
            string data = null;
            Byte[] bytes = new Byte[4096];
            int i;
            bool handle = true;
            string str = "Welcome!";
            byte[] msg = Encoding.ASCII.GetBytes(str);
            stream.Write(msg, 0, msg.Length);
            Console.WriteLine("Send: {0}", str);
            while (handle)
            {
                try
                {
                    if (stream != null && stream.DataAvailable)
                    {
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            string hex = BitConverter.ToString(bytes);
                            data = Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
                            string str1 = HandleRequest(data, stream);
                            if (str1!=null)
                            {
                                if (str1?.ToUpper() == "LOGOUT")
                                {
                                    handle = false;
                                    break;
                                }
                                Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str1);
                                stream.Write(reply, 0, reply.Length);
                                Console.WriteLine("Sent: {0}", str1); 
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e.ToString());
                    client.Close();
                }
            }
        }

        private string HandleRequest(string data, NetworkStream stream)
        {
            string message = data.GetMessage('|');
            int code = 0;

            bool codeValid = int.TryParse(data.GetCode('|'), out code);
            switch (code)
            {
                case (int)Codes.CREATEROOM:
                    {
                        CreateRoomRequest createRoomRequest = (CreateRoomRequest)JsonSerializer.Deserialize(message, typeof(CreateRoomRequest));

                        return _RequestHandler.HandleCreateRoom(createRoomRequest)?.Buffer;
                    }
                case (int)Codes.LOGIN:
                    {
                        LoginRequest loginRequest = (LoginRequest)JsonSerializer.Deserialize(message, typeof(LoginRequest));
                        return _RequestHandler.HandleLogin(loginRequest)?.Buffer;
                    }
                case (int)Codes.GETROOMS:
                    {
                        return _RequestHandler.HandleGetRooms()?.Buffer;
                    }
                case (int)Codes.LOGOUT:
                    {
                        LogoutRequest logoutRequest = (LogoutRequest)JsonSerializer.Deserialize(message, typeof(LogoutRequest));
                        _RequestHandler.HandleLogout(logoutRequest.name);
                        return "LOGOUT";
                    }
                case (int)Codes.SIGNUP:
                    {
                        SignupRequest signupRequest = (SignupRequest)JsonSerializer.Deserialize(message, typeof(SignupRequest));
                        return _RequestHandler.HandleSignup(signupRequest)?.Buffer;
                    }
                case (int)Codes.GETPLAYERS:
                    {
                        GetPlayersRequest getPlayersRequest = (GetPlayersRequest)JsonSerializer.Deserialize(message, typeof(GetPlayersRequest));
                        string result = _RequestHandler.HandleGetPlayers(getPlayersRequest)?.Buffer;

                        return result;
                    }
                case (int)Codes.JOINROOM:
                    {
                        JoinRoomRequest joinRoomRequest = (JoinRoomRequest)JsonSerializer.Deserialize(message, typeof(JoinRoomRequest));
                        string result = _RequestHandler.HandleJoinRoom(joinRoomRequest, stream)?.Buffer;
                        return result;
                    }
                case (int)Codes.GETSTATS:
                    {
                        GetStatisticsRequest getStatisticsRequest = (GetStatisticsRequest)JsonSerializer.Deserialize(message, typeof(GetStatisticsRequest));
                        return _RequestHandler.HandleGetStatistics(getStatisticsRequest)?.Buffer;
                    }
                case (int)Codes.OPENROOM:
                    {
                        OpenRoomRequest openRoomRequest = JsonSerializer.Deserialize<OpenRoomRequest>(message);
                        return _RequestHandler.HandleOpenRoom(openRoomRequest)?.Buffer;
                    }
                case (int)Codes.STARTTRIVIA:
                    {
                        StartTriviaRequest startTriviaRequest = JsonSerializer.Deserialize<StartTriviaRequest>(message);
                        return _RequestHandler.HandleStartTrivia(startTriviaRequest)?.Buffer;
                    }
                case (int)Codes.SUBMITSTATS:
                    {
                        SubmitStatisticsRequest submitStatisticsRequest = JsonSerializer.Deserialize<SubmitStatisticsRequest>(message);
                        return _RequestHandler.HandleSubmitStatistics(submitStatisticsRequest)?.Buffer;
                    }
                case (int)Codes.FINISHGAME:
                    {
                        FinishGameRequest finishGameRequest = JsonSerializer.Deserialize<FinishGameRequest>(message);
                        return _RequestHandler.HandleFinishGame(finishGameRequest)?.Buffer;
                    }
                case (int)Codes.GETPLAYINGPLAYERS:
                    {
                        GetPlayingRequest getPlayingRequest = JsonSerializer.Deserialize<GetPlayingRequest>(message);
                        return _RequestHandler.HandleGetPlaying(getPlayingRequest)?.Buffer;
                    }
                default:
                    {
                        return $"Code:def\nMessage:{message}";
                    }
            }
        }
    }
}