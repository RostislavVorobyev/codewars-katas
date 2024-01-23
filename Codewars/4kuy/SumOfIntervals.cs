using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public class SumOfIntervals
    {
        public int SumIntervals((int start, int end)[] intervals)
        {
            var merged = new List<(int start, int end)>();

            foreach (var (start, end) in intervals)
            {
                var intersectionIndex = merged.FindIndex(i => start <= i.end && i.start <= end);

                if (intersectionIndex != -1)
                {
                    var intersection = (start: 0, end: 0);
                    var curStart = start;
                    var curEnd = end;

                    while (intersectionIndex != -1)
                    {
                        intersection = merged[intersectionIndex];
                        var newInterval = (start: Math.Min(intersection.start, curStart), end: Math.Max(intersection.end, curEnd));

                        if (newInterval == intersection)
                        {
                            curEnd = 0;
                            curEnd = 0;
                        }

                        merged.RemoveAt(intersectionIndex);


                        intersectionIndex = merged.FindIndex(i => newInterval.start < i.end && i.start < newInterval.end);
                        curEnd = newInterval.end;
                        curStart = newInterval.start;
                    }

                    if ((curStart, curEnd) != default)
                        merged.Add((curStart, curEnd));


                }
                else
                {
                    merged.Add((start, end));
                }
            }

            return merged.Sum(x => GetIntervalLength(x));
        }

        //upper bound is excluded 
        private static int GetIntervalLength((int start, int end) intersection) =>
            intersection.end - intersection.start;
    }
}
