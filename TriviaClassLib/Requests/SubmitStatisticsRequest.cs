namespace TriviaClassLib
{
    public class SubmitStatisticsRequest
    {
        public string username { get; set; }
        public int TotalGames { get; set; }
        public int TotalAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public int AnswerTime { get; set; }
    }
}