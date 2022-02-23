namespace TriviaClassLib.Requests
{
    public class CreateRoomRequest
    {
        public string name { get; set; }
        public int maxUsers { get; set; }
        public int questionCount { get; set; }
        public int answerTimeout { get; set; }
    }
}