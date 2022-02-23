using System;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Codes;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class SubmitStatisticsHandler
    {
        public static RequestResult HandleSubmitStatistics(SubmitStatisticsRequest submitStatisticsRequest, IStatisticsManager statisticsManager)
        {
            try
            {
                string username = submitStatisticsRequest.username;
                statisticsManager.IncrementStat(username, StatType.CorrectAnswers, submitStatisticsRequest.CorrectAnswers);
                statisticsManager.IncrementStat(username, StatType.TimeToAnswer, submitStatisticsRequest.AnswerTime);
                statisticsManager.IncrementStat(username, StatType.TotalGames, submitStatisticsRequest.TotalGames);
                statisticsManager.IncrementStat(username, StatType.TotalAnswers, submitStatisticsRequest.TotalAnswers);
                SubmitStatisticsResponse response = new SubmitStatisticsResponse()
                {
                    status = (int)Codes.SUBMITSTATS
                };
                return new RequestResult()
                {
                    Buffer = JsonSerializer.Serialize<SubmitStatisticsResponse>(response)
                };
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }

        }
    }
}