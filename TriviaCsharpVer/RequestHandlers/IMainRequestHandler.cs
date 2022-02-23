using System.Collections;
using System.Net.Sockets;
using TriviaClassLib;
using TriviaClassLib.Requests;

namespace TriviaServer
{
    public interface IMainRequestHandler
    {
        public ArrayList _Connections { get; set; }

        RequestResult HandleCreateRoom(CreateRoomRequest CreateRequest);

        RequestResult HandleLogin(LoginRequest loginRequest);

        RequestResult HandleGetRooms();

        RequestResult HandleLogout(string name);

        RequestResult HandleSignup(SignupRequest signupRequest);

        RequestResult HandleGetPlayers(GetPlayersRequest getPlayersRequest);

        RequestResult HandleJoinRoom(JoinRoomRequest joinRoomRequest, NetworkStream stream);

        RequestResult HandleGetStatistics(GetStatisticsRequest getStatisticsRequest);

        RequestResult HandleOpenRoom(OpenRoomRequest openRoomRequest);

        RequestResult HandleStartTrivia(StartTriviaRequest startTriviaRequest);
        RequestResult HandleSubmitStatistics(SubmitStatisticsRequest submitStatisticsRequest);
        RequestResult HandleFinishGame(FinishGameRequest finishGameRequest);
        RequestResult HandleGetPlaying(GetPlayingRequest getPlayingRequest);
    }
}