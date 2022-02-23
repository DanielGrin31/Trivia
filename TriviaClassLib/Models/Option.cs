namespace TriviaClassLib.Models
{
    public class Option
    {
        #region Fields
        /// <summary>
        /// Property that indicates if the option is the correct option
        /// </summary>
        public bool isCorrect { get; set; }

        /// <summary>
        /// Represents the content of the option(the text shown)
        /// </summary>
        public string _Content { get; set; }

        /// <summary>
        /// Represents the option number for the question
        /// </summary>
        public OptionNumber _OptionNumber { get; set; }

        /// <summary>
        /// Represents the Question the option is a part of
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public Question _Question { get; set; }
        #endregion

        #region Constructors
        public Option()
        {
            _Content = "";
        }

        public Option(OptionNumber optionNumber, string content, Question question)
        {
            _OptionNumber = optionNumber;
            _Content = content;
            _Question = question;
        }

        public Option(string Content)
        {
            _Content = Content;
        } 
        #endregion
    }
}