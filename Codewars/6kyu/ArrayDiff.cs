/*
 * Array.diff : https://www.codewars.com/kata/523f5d21c841566fde000009/solutions/csharp
 */

using System.Linq;

namespace Codewars
{
    public static class ArrayDiff
    {
        public static int[] Find(int[] a, int[] b)
        {
            return a.Where(x => !b.Contains(x)).ToArray();
        }
    }
}
