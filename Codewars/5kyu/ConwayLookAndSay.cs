using System;
using System.Text;

namespace Codewars
{
    public static class ConwayLookAndSay
    {
        public static ulong LookSay(ulong number)
        {
            var numStr = number.ToString();
            var prevDigit = numStr.ToString()[0];
            var counter = 0;
            var result = new StringBuilder();

            foreach (var digit in numStr)
            {
                if (prevDigit == ' ')
                    prevDigit = digit;

                if (prevDigit == digit)
                {
                    counter++;
                }
                else
                {
                    result.Append($"{counter}{prevDigit}");
                    prevDigit = digit;
                    counter = 1;
                }
            }

            if (result.Length == 0 || numStr[^1] != result[^1])
            {
                result.Append($"{counter}{prevDigit}");
            }

            return Convert.ToUInt64(result.ToString());
        }
    }
}
