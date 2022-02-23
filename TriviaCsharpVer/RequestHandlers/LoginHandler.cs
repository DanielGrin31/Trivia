using System;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Requests;
using TriviaClassLib.Responses;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class LoginHandler
    {
        public static RequestResult HandleLogin(LoginRequest loginRequest, ILoginManager _LoginManager)
        {
            string username = loginRequest.username;
            string password = loginRequest.password;
            try
            {
                _LoginManager.Login(username, password);
                LoginResponse loginResponse = new LoginResponse()
                {
                    status = 100
                };
                return new RequestResult()
                {
                    Buffer = JsonSerializer.Serialize(loginResponse)
                };
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }
    }
}