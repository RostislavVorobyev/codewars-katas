using System;

namespace Codewars
{
    public class DivisibleInts
    {
        public static int GetCount(int n)
        {
            var number = n.ToString();
            var count = 0;

            for (int i = 0; i < number.Length; i++)
            {
                for (int j = 1; j < number.Length - i + 1; j++)
                {
                    var curr = Convert.ToInt32(number.Substring(i, j));

                    if (curr == 0)
                    {
                        continue;
                    }

                    count = n % Convert.ToInt32(number.Substring(i, j)) == 0 ? count + 1 : count;
                }
            }

            return count - 1;
        }
    }
}
