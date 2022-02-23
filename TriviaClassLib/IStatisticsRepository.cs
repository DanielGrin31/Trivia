using System.Collections.Generic;
using TriviaClassLib.Codes;

namespace TriviaClassLib
{
    public interface IStatisticsRepository
    {
        Statistic Add(Statistic stat);

        Statistic Delete(Statistic stat);

        Statistic Delete(string username, StatType type);

        void DeleteAll(string username);

        Statistic Update(Statistic stat);
        Statistic Update(string username,StatType type,int value);

        IEnumerable<Statistic> GetByUsername(string username);

        Statistic GetByUsername(string username, StatType type);
    }
}