using System;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Responses;

namespace TriviaServer.Utility
{
    public class ErrorMaker
    {
        public static RequestResult MakeError(Exception e)
        {
            RequestResult result = new RequestResult();
            ErrorResponse response = new ErrorResponse
            {
                message = e.Message
            };
            string serializedError = JsonSerializer.Serialize(response);
            result.Buffer = serializedError;
            return result;
        }
    }
}