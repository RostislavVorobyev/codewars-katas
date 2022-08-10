using System;
using System.Linq;

namespace Codewars
{
    public class NarcissticNumber
    {
        public bool Narcissistic(int value)
        {
            var digits = value.ToString();

            return digits.Sum(x => Math.Pow(x - '0', digits.Length)) == value;
        }
    }
}
