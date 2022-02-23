using TriviaClassLib;
using TriviaClassLib.Codes;

namespace TriviaServer
{
    public interface IStatisticsManager
    {
        RequestResult GetStats(string username);
        Statistic UpdateStat(string username, StatType type, int value);
        void InitStats(string username);
        void IncrementStat(string username, StatType type, int value);
    }
}