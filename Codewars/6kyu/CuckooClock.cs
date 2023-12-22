/*
 * https://www.codewars.com/kata/656e4602ee72af0017e37e82
 */

using System;
using System.Linq;

namespace Codewars
{
    public static class CuckooClock
    {

        public static int[] cuckooSchedule = {
            1,1,1,1
            ,2,1,1,1
            ,3,1,1,1
            ,4,1,1,1
            ,5,1,1,1
            ,6,1,1,1
            ,7,1,1,1
            ,8,1,1,1
            ,9,1,1,1
            ,10,1,1,1
            ,11,1,1,1
            ,12,1,1,1
        };

        public static string CuckooClockCount(string inputTime, int chimes)
        {
            var finishTime = DateTime.Parse(inputTime);

            var quater = (finishTime.Hour - 1) * 4 + finishTime.Minute / 15 + 1;

            var chimesNeeded = chimes;

            if (finishTime.Minute % 15 == 0)
            {
                chimesNeeded -= cuckooSchedule[quater - 1];
                if (chimesNeeded < 0) return inputTime;
            }

            if (chimesNeeded > 113)
            {
                var perDay = cuckooSchedule.Sum();
                chimesNeeded %= perDay;
            }

            for (var q = quater; chimesNeeded > 0; q++)
            {
                if (q == cuckooSchedule.Length)
                    q = 0;

                finishTime = finishTime.AddMinutes(15);

                chimesNeeded -= cuckooSchedule[q];
            }

            finishTime = finishTime.AddMinutes(-(finishTime.Minute % 15));

            return finishTime.ToString("hh:mm");
        }
    }
}
