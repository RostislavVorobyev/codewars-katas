using System.Collections.Generic;

namespace Codewars
{
    public class SumConsecutivesKata
    {
        public static List<int> SumConsecutives(List<int> s)
        {
            if (s.Count == 0)
                return new List<int>();

            var result = new List<int>() { s[0] };

            for (int i = 1; i < s.Count; i++)
            {
                if (s[i] == s[i - 1])
                    result[^1] = result[^1] + s[i];
                else
                    result.Add(s[i]);
            }

            return result;
        }
    }
}
