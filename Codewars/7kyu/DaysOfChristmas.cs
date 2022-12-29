/*
 * DaysOfChristmas: https://www.codewars.com/kata/57dd3a06eb0537b899000a64/train/csharp
 */
namespace Codewars
{
    public static class DaysOfChristmas
    {
        public static int Compare(string line1, string line2)
        {
            return Evaluate(line2[..2].TrimEnd()) - Evaluate(line2[..2].TrimEnd());
        }

        private static int Evaluate(string expr)
        {
            if (expr == "On")
            {
                return 1000;
            }

            if (expr == "a")
            {
                return 0;
            }

            return int.Parse(expr);
        }
    }
}
