using System.Text.RegularExpressions;

namespace Codewars
{
    public static class IPValidation
    {
        public static bool IsValid(string ipAddres)
        {
            return Regex.Match(ipAddres, @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$").Success;
        }
    }
}
