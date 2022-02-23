namespace TriviaServer
{
    public static class StringCodeExtensionMethods
    {
        public static string GetCode(this string str, char seperator)
        {
            return str.Split(seperator)[0];
        }

        public static string GetMessage(this string str, char seperator)
        {
            return str.Split(seperator)[1];
        }
    }
}