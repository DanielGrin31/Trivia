namespace TriviaClassLib.Responses
{
    public class StatisticsResponse
    {
        public int CorrectAnswers { get; set; }
        public int TotalAnswers { get; set; }
        public int TotalGames { get; set; }
        public float AverageTimeToAnswer { get; set; }
    }
}