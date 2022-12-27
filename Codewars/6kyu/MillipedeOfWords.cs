using System;
using System.Linq;

namespace Codewars
{
    public static class MillipedeOfWords
    {
        public static bool Millipede(string[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
            var unused = arr.GroupBy(x => x[0]).Select(x => string.Join(string.Empty, x)).ToList();

            while (unused.Count > 1)
            {
                var curr = unused.First();
                unused.Remove(curr);

                var endJoin = unused.FirstOrDefault(x => x[0] == curr[^1]);
                var strartJoin = unused.FirstOrDefault(x => x[^1] == curr[0]);

                if (endJoin != null)
                {
                    unused.Remove(endJoin);
                    unused.Add(curr + endJoin);
                    continue;
                }

                if (strartJoin != null)
                {
                    unused.Remove(strartJoin);
                    unused.Add(strartJoin + curr);
                    continue;
                }

                return false;
            }

            return true;
        }
    }

}
