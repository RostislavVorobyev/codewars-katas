/*
 * Bit Counting: https://www.codewars.com/kata/526571aae218b8ee490006f4
 */
using System;
using System.Linq;

namespace Codewars
{
    public class BitCounting
    {
        public int CountBits(int n)
        {
            return Convert.ToString(n, 2).Sum(x => x - '0');
        }
    }
}
