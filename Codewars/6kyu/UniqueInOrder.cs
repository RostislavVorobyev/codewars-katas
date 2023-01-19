using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public static class UniqueInOrderKata
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            return iterable.Where((x, i) => i == 0 || !Equals(x, iterable.ElementAt(i - 1)));
        }
    }
}
