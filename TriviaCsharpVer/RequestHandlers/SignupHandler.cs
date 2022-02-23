using System;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Requests;
using TriviaClassLib.Responses;
using TriviaServer.Utility;

namespace TriviaServer.RequestHandlers
{
    public class SignupHandler
    {
        public static RequestResult HandleSignup(SignupRequest signupRequest, ISignupManager _SignupManager)
        {
            string username = signupRequest.username;
            string password = signupRequest.password;
            string email = signupRequest.email;
            try
            {
                _SignupManager.Signup(username, password, email);
                SignupResponse signupResponse = new SignupResponse()
                {
                    status = 101
                };
                return new RequestResult()
                {
                    Buffer = JsonSerializer.Serialize(signupResponse)
                };
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }
    }
}