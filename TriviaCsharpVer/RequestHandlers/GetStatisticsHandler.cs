using System;
using TriviaClassLib;
using TriviaClassLib.Requests;
using TriviaServer.Utility;

namespace TriviaServer
{
    public class GetStatisticsHandler
    {
        public static RequestResult HandleGetStatistics(GetStatisticsRequest getStatisticsRequest, IStatisticsManager statisticsManager)
        {
            try
            {
                return statisticsManager.GetStats(getStatisticsRequest.name);
            }
            catch (Exception e)
            {
                return ErrorMaker.MakeError(e);
            }
        }
    }
}