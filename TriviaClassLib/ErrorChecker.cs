namespace TriviaClassLib
{
    public class ErrorChecker
    {
        public static bool Check(string message)
        {
            if (message == ErrorGetter.GetUserLoggedIn() || message == ErrorGetter.GetWrongPassword() ||
                message == ErrorGetter.GetUserDoesNotExist() || message == ErrorGetter.GetRoomWithUsernameAlreadyExists() || message == ErrorGetter.GetRoomDoesNotExist()
                || message == ErrorGetter.GetUserAlreadyExistsInRoom() || message == ErrorGetter.GetUserNotLoggedIn() || message == ErrorGetter.GetUserAlreadyExistsInRoom()
                || message == ErrorGetter.GetUserAlreadyExists() || message == ErrorGetter.GetUserDoesNotExistInRoom() || message == ErrorGetter.GetStatsNotFound()
                ||message==ErrorGetter.GetRoomIsNotActive())
            {
                return true;
            }
            return false;
        }
    }
}