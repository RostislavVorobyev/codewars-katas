using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public static class UniqueNumber
    {
        public static int GetUnique(IEnumerable<int> numbers)
        {
            return numbers.GroupBy(x => x).Where(x => x.Count() == 1).Single().Key;
        }
    }
}
