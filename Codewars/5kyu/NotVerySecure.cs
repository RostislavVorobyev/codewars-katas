using System.Text.RegularExpressions;

namespace Codewars
{
    public static class NotVerySecure
    {
        public static bool Alphanumeric(string str)
        {
            return Regex.Match(str, @"^[a-zA-Z0-9]+$").Success;
        }
    }
}

