using System.Runtime.Serialization;
using TriviaClassLib.Codes;

namespace TriviaClassLib
{
    public class Statistic : ISerializable
    {
        #region Fields
        public string username { get; set; }
        public StatType statType { get; set; }
        public int value { get; set; }
        #endregion

        #region Constructors
        public Statistic()
        {
        }

        public Statistic(SerializationInfo info, StreamingContext context)
        {
            username = info.GetString("username");
            statType = (StatType)info.GetValue("statType", typeof(StatType));
            value = info.GetInt32("value");
        }

        public Statistic(string username, StatType statType, int value)
        {
            this.username = username;
            this.statType = statType;
            this.value = value;
        }
        #endregion

        #region Methods
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("username", username);
            info.AddValue("value", value);
            info.AddValue("statType", statType);
        } 
        #endregion
    }
}