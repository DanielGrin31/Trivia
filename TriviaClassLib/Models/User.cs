namespace TriviaClassLib
{
    public class User
    {
        #region Fields
        private string username;
        private string password;
        private string email;

        #endregion

        #region Constructors
        public User()
        {
        }

        public User(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        #endregion

        #region Methods
        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        } 
        #endregion
    }
}