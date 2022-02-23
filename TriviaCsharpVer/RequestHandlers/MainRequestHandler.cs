using System;
using System.Collections;
using System.Net.Sockets;
using TriviaClassLib;
using TriviaClassLib.Models;
using TriviaClassLib.Requests;
using TriviaServer.RequestHandlers;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class MainRequestHandler : IMainRequestHandler
    {
        public ISignupManager _SignupManager;
        public ILoginManager _LoginManager;
        public IStatisticsManager _StatisticsManager;
        public IRoomsRepository _RoomsRepository;
        public ArrayList _Connections { get; set; }

        public MainRequestHandler(ISignupManager signupManager, ILoginManager loginManager, IStatisticsManager statisticsManager, IRoomsRepository roomsRepository)
        {
            _SignupManager = signupManager;
            _LoginManager = loginManager;
            _StatisticsManager = statisticsManager;
            _RoomsRepository = roomsRepository;
        }

        public RequestResult HandleCreateRoom(CreateRoomRequest CreateRequest)
        {
            return CreateRoomHandler.HandleCreateRoom(CreateRequest, _RoomsRepository);
        }

        public RequestResult HandleGetPlayers(GetPlayersRequest getPlayersRequest)
        {
            return GetPlayersRequestHandler.HandleGetPlayers(getPlayersRequest, _RoomsRepository);
        }

        public RequestResult HandleGetRooms()
        {
            try
            {
                return GetRoomsHandler.HandleGetRooms(_RoomsRepository);
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }

        public RequestResult HandleGetStatistics(GetStatisticsRequest getStatisticsRequest)
        {
            return GetStatisticsHandler.HandleGetStatistics(getStatisticsRequest, _StatisticsManager);
        }

        public RequestResult HandleJoinRoom(JoinRoomRequest joinRoomRequest, NetworkStream stream)
        {
            string username = joinRoomRequest.username;
            int roomId = joinRoomRequest.roomId;
            try
            {
                var result = JoinRoomHandler.HandleJoinRoom(username, roomId, _RoomsRepository, _LoginManager._LoggedUsersRepository);
                _Connections.Add(new Connection()
                {
                    roomId = roomId,
                    stream = stream,
                    username=username
                });
                return result;
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }

        public RequestResult HandleLogin(LoginRequest loginRequest)
        {
            RequestResult result = LoginHandler.HandleLogin(loginRequest, _LoginManager);
            return result;
        }

        public RequestResult HandleLogout(string name)
        {
            return LogoutHandler.HandleLogout(name, _LoginManager._LoggedUsersRepository);
        }

        public RequestResult HandleOpenRoom(OpenRoomRequest openRoomRequest)
        {
            try
            {
                return OpenRoomHandler.HandleOpenRoom(_RoomsRepository, openRoomRequest.roomId, openRoomRequest.username);
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }

        public RequestResult HandleSignup(SignupRequest signupRequest)
        {
            return SignupHandler.HandleSignup(signupRequest, _SignupManager, _StatisticsManager);
        }

        public RequestResult HandleStartTrivia(StartTriviaRequest startTriviaRequest)
        {
            try
            {
                return StartTriviaHandler.HandleStartTrivia(startTriviaRequest, _RoomsRepository, _Connections);
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }

        public RequestResult HandleSubmitStatistics(SubmitStatisticsRequest submitStatisticsRequest)
        {
           return SubmitStatisticsHandler.HandleSubmitStatistics(submitStatisticsRequest, _StatisticsManager);
        }

        public RequestResult HandleFinishGame(FinishGameRequest finishGameRequest)
        {

            try
            {
                return FinishGameHandler.HandleFinishGames(finishGameRequest, _Connections, _RoomsRepository);

            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }

        public RequestResult HandleGetPlaying(GetPlayingRequest getPlayingRequest)
        {
            return GetPlayingHandler.HandleGetPlaying(getPlayingRequest, _RoomsRepository);
        }
    }
}