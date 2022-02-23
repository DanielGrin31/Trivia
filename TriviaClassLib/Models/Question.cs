using System.Collections.Generic;
using System.Linq;

namespace TriviaClassLib.Models
{
    public class Question
    {
        #region Properties
        /// <summary>
        /// Represents the content of the question(the question itself)
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Represents all the options the Question has
        /// </summary>
        public List<Option> Options { get; set; }
        #endregion

        #region Constructors
        public Question(string content)
        {
            Content = content;
            Options = new List<Option>();
        }

        public Question(List<Option> options, string content)
        {
            Options = options;
            Content = content;
        }


        public Question()
        {
            Content = "";
            Options = new List<Option>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns>all the correct options of the question</returns>
        public IEnumerable<Option> GetCorrectOptions()
        {
            return Options.Where(x => x.isCorrect == true);
        }
        /// <summary>
        /// Gets the option where the option number is the passed in value
        /// </summary>
        /// <param name="optionNumber"></param>
        /// <returns></returns>
        public Option GetOptionByNumber(OptionNumber optionNumber)
        {
            return Options.Where(x => x._OptionNumber == optionNumber).FirstOrDefault();
        }
        /// <summary>
        /// Gets the option where the option number is the passed in value
        /// </summary>
        /// <param name="optionNumber"></param>
        /// <returns></returns>
        public Option GetOptionByNumber(int optionNumber)
        {
            return GetOptionByNumber((OptionNumber)optionNumber);
        }
        /// <summary>
        /// Adds an option to the options
        /// </summary>
        /// <param name="option"></param>
        public void AddOption(Option option)
        {
            if (Options.Count <= 3)//if there is space(max 4 options)
            {
                if (Options.Count > 0)
                {
                    option._OptionNumber = Options.Max(x => x._OptionNumber) + 1;//Gets the option number
                }
                else
                {
                    option._OptionNumber = OptionNumber.First;//if there are no options
                }
                option._Question = this;
                Options.Add(option);
            }
        }
        /// <summary>
        /// builds an option and adds it to the question
        /// </summary>
        /// <param name="content"></param>
        public void AddOption(string content)
        {
            Option option = new Option(content);
            AddOption(option);
        }

        /// <summary>
        /// Removes the option from the question
        /// </summary>
        /// <param name="option"></param>
        public void RemoveOption(Option option)
        {
            Options.Remove(option);
        }

        /// <summary>
        /// Removes the option from the question
        /// </summary>
        /// <param name="optionNumber"></param>
        public void RemoveOption(OptionNumber optionNumber)
        {
            Options.RemoveAll(x => x._OptionNumber == optionNumber);
        } 
        #endregion
    }
}