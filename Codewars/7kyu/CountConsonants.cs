using System.Linq;

namespace Codewars
{
    public static class CountConsonants
    {
        public static int ConsonantCount(string str)
        {
            var vowels = "aeiou";

            bool isConsonant(char x) => char.IsLetter(x) && !vowels.Contains(char.ToLower(x));

            return str.Count(isConsonant);
        }
    }
}
