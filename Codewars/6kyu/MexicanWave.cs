using System.Collections.Generic;

namespace Codewars
{
    public static class MexicanWave
    {
        public static List<string> Wave(string str)
        {
            var result = new List<string>();

            for (int x = 0; x < str.Length; x++)
            {
                var current = str[x];
                if (char.IsLetter(current))
                {
                    result.Add(str[0..x] + char.ToUpper(current) + str[(x + 1)..]);
                }
            }

            return result;
        }
    }
}