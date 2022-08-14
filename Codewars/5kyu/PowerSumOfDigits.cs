using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public class PowerSumOfDigits
    {
        public long PowerSumDigTerm(int n)
        {
            var properNumbers = new List<long>() { 81, 512, };

            //i -разряд
            for (int place = 2; properNumbers.Count < n; place++)
            {
                for (int sumOfDigits = 2; sumOfDigits < place * 9; sumOfDigits++)
                {
                    var number = sumOfDigits;


                    while (number < Math.Pow(10, place) && properNumbers.Count != n)
                    {
                        if (number > properNumbers.Last() && SumDigits(number) == sumOfDigits)
                        {
                            properNumbers.Add(number);
                        }
                        number *= sumOfDigits;
                    }
                }
            }

            return properNumbers[n - 1];
        }

        public static int SumDigits(int n) => n.ToString().Select(x => x - '0').Sum();
    }
}
