using System.Linq;
/*
 * Greed is Good: https://www.codewars.com/kata/5270d0d18625160ada0000e4
 */
namespace Codewars
{
    public static class GreedIsGood
    {
        public static int Score(int[] dice)
        {
            int score = 0;
            var groups = dice.GroupBy(x => x);

            foreach (var group in groups)
            {
                (int singleValue, int setValue) = group.Key switch
                {
                    1 => (100, 1000),
                    5 => (50, 500),
                    _ => (0, group.Key * 100)

                };

                var count = group.Count();

                if (count >= 3)
                {
                    score += setValue + singleValue * (count - 3);
                }
                else
                {
                    score += singleValue * count;
                }
            }

            return score;
        }
    }
}
