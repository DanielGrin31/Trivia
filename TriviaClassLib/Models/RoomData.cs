using System.Runtime.Serialization;

/// <summary>
/// Data representation of the room
/// </summary>
public class RoomData : ISerializable
{
    #region Fields
    /// <summary>
    /// Id of the room
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// Name of the room
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// Max players allowed to join the room
    /// </summary>
    public int maxPlayers { get; set; }
    /// <summary>
    /// Maximum time per question
    /// </summary>
    public int timePerQuestion { get; set; }
    /// <summary>
    /// Property that returns if the room is active
    /// </summary>
    public bool isActive { get; set; }
    #endregion

    #region Constructors
    public RoomData()
    {
    }

    public RoomData(SerializationInfo info, StreamingContext context)
    {
        id = info.GetInt32("id");
        name = info.GetString("name");
        maxPlayers = info.GetInt32("maxPlayers");
        timePerQuestion = info.GetInt32("timePerQuestion");
        isActive = info.GetBoolean("isActive");
    } 
    #endregion

    #region Methods
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id", id);
        info.AddValue("name", name);
        info.AddValue("maxPlayers", maxPlayers);
        info.AddValue("timePerQuestion", timePerQuestion);
        info.AddValue("isActive", isActive);
    }

    public override string ToString()
    {
        return $"Id:{id}\nName:{name}\n,Max Players:{maxPlayers}\nTime Per Question:{timePerQuestion}\nActive:{isActive}";
    } 
    #endregion
}