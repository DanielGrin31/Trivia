using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TriviaClassLib;
using TriviaClassLib.Codes;
using TriviaClassLib.Responses;

namespace TriviaServer
{
    public class StatisticsManager : IStatisticsManager
    {
        private IStatisticsRepository _StatisticsRepository;

        public StatisticsManager(IStatisticsRepository statisticsRepository)
        {
            _StatisticsRepository = statisticsRepository;
        }

        public RequestResult GetStats(string username)
        {
            StatisticsResponse response;
            List<Statistic> stats = _StatisticsRepository.GetByUsername(username).ToList();
            response = new StatisticsResponse();
            try
            {
                response.TotalGames = (int)stats.Where(x => x.statType == StatType.TotalGames).FirstOrDefault()?.value;
                response.AverageTimeToAnswer = (float)(stats.Where(x => x.statType == StatType.TimeToAnswer).FirstOrDefault()?.value/(response.TotalGames));
                response.CorrectAnswers =(int) stats.Where(x => x.statType == StatType.CorrectAnswers).FirstOrDefault()?.value;
                response.TotalAnswers = (int)stats.Where(x => x.statType == StatType.TotalAnswers).FirstOrDefault()?.value;
            }
            catch (Exception e)
            {
                throw new Exception(ErrorGetter.GetStatsNotFound());
            }
            RequestResult requestResult = new RequestResult()
            {
                Buffer = JsonSerializer.Serialize<StatisticsResponse>(response)
            };
            return requestResult;
        }

        public void IncrementStat(string username, StatType type, int value)
        {
            var stat =_StatisticsRepository.GetByUsername(username, type);
            if (stat != null)
            {
                int oldValue = stat.value;
                int newValue = oldValue + value;
                _StatisticsRepository.Update(username, type, newValue);
            }
        }

        public void InitStats(string username)
        {
            _StatisticsRepository.Add(new Statistic(username, StatType.TimeToAnswer,0));
            _StatisticsRepository.Add(new Statistic(username, StatType.CorrectAnswers, 0));
            _StatisticsRepository.Add(new Statistic(username, StatType.TotalAnswers, 0));
            _StatisticsRepository.Add(new Statistic(username, StatType.TotalGames, 0));
        }

        public Statistic UpdateStat(string username, StatType type, int value)
        {
            return _StatisticsRepository.Update(username, type, value);
        }
    }
}