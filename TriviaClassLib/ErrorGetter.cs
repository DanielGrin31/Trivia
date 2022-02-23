using System;

namespace TriviaClassLib
{
    public class ErrorGetter
    {
        public static string GetRoomIsNotActive()
        {
            return "Room is not active";
        }
        public static string GetNonIntegarValueField()
        {
            return "All Fields Must have an integar number";
        }
        public static string GetOptionNotFound()
        {
            return "Option not Found!";
        }

        public static string GetWrongPassword()
        {
            return "Password is wrong!";
        }

        public static string GetUserLoggedIn()
        {
            return "User is already logged in!";
        }

        public static string GetUserDoesNotExist()
        {
            return "User does not exist!";
        }

        public static string GetRoomWithUsernameAlreadyExists()
        {
            return "Room with that username already exists!";
        }

        public static string GetCouldNotConnect()
        {
            return "Could not connect to server, terminating.";
        }

        public static string GetRoomDoesNotExist()
        {
            return "Room Doesnt exists";
        }

        public static string GetUserNotLoggedIn()
        {
            return "User is not logged in";
        }

        public static string GetUserAlreadyExistsInRoom()
        {
            return "The user already exists in the chosen room";
        }

        public static string GetUserDoesNotExistInRoom()
        {
            return "The user does not exists in the chosen room";
        }

        public static string CouldNotFinishGame()
        {
            return "Could not finish the game";
        }

        public static string GetUserAlreadyExists()
        {
            return "User already exists!";
        }

        public static string GetStatsNotFound()
        {
            return "No statistics found for the chosen user";
        }

        public static string GetProblemLoadingRooms()
        {
            return "There was a problem loading the rooms!";
        }
    }
}