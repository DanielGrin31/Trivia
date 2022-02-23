using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TriviaClassLib.Models
{
    public class StartTriviaData : ISerializable
    {
        #region Fields
        public RoomMetadata room { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        #endregion

        #region Constructors
        public StartTriviaData()
        {
        }

        public StartTriviaData(SerializationInfo info, StreamingContext context)
        {
            room = (RoomMetadata)info.GetValue(nameof(room), typeof(RoomMetadata));
            Questions = (IEnumerable<Question>)info.GetValue(nameof(Questions), typeof(IEnumerable<Question>));
        }
        #endregion

        #region Methods
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(room), room);
            info.AddValue(nameof(Questions), Questions);
        } 
        #endregion
    }
}