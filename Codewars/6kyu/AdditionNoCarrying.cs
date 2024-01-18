using System;

namespace Codewars
{
    public class AdditionNoCarrying
    {
        public int AdditionWithoutCarrying(int a, int b)
        {
            var sum = 0;
            var l = Math.Max(a, b).ToString().Length;

            for (int i = 0; i < l; i++)
            {
                sum += (int)(((a % 10 + b % 10) % 10) * Math.Pow(10, i-1));
                a /= 10;
                b/= 10;
            }

            return sum;
        }
    }
}
