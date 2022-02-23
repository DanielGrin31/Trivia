using System.Collections.Generic;
using System.Linq;
using TriviaClassLib.Codes;

namespace TriviaClassLib
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private List<Statistic> statistics;

        public StatisticsRepository()
        {
            statistics = new List<Statistic>()
            {
                new Statistic( "grinberg",StatType.CorrectAnswers,4),
                new Statistic( "grinberg",StatType.TotalAnswers,41561),
                new Statistic( "grinberg",StatType.TotalGames,87),
                new Statistic( "grinberg",StatType.TimeToAnswer,60),
            };
        }

        public Statistic Add(Statistic stat)
        {
            if (GetByUsername(stat.username, stat.statType) == null)
            {
                statistics.Add(stat);
            }
            return stat;
        }

        public Statistic Delete(Statistic stat)
        {
            return Delete(stat.username, stat.statType);
        }

        public Statistic Delete(string username, StatType type)
        {
            Statistic statistic = GetByUsername(username, type);
            if (statistic != null)
            {
                statistics.Remove(statistic);
            }
            return statistic;
        }

        public void DeleteAll(string username)
        {
            statistics.RemoveAll(x => x.username == username);
        }

        public IEnumerable<Statistic> GetByUsername(string username)
        {
            return statistics.Where(x => x.username == username);
        }

        public Statistic GetByUsername(string username, StatType type)
        {
            return statistics.Where(x => x.username == username && x.statType == type).FirstOrDefault();
        }

        public Statistic Update(Statistic stat)
        {
            Statistic statistic = GetByUsername(stat.username, stat.statType);
            if (statistic != null)
            {
                statistic.value = stat.value;
            }
            return statistic;
        }

        public Statistic Update(string username, StatType type, int value)
        {
            Statistic statistic = GetByUsername(username, type);
            if (statistic!=null)
            {
                statistic.value = value;
            }
            return statistic;
        }
    }
}