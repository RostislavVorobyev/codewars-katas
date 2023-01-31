namespace Codewars
{
    public static class ConsecutiveStrings
    {
        public static string LongestConsec(string[] strarr, int k)
        {
            var longesConsequence = string.Empty;

            for (int i = 0; i <= strarr.Length - k; i++)
            {
                var l = i + k;
                var currConsequence = string.Concat(strarr[i..l]);

                if (longesConsequence.Length < currConsequence.Length)
                {
                    longesConsequence = currConsequence;
                }
            }

            return longesConsequence;
        }
    }
}
