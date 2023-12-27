//https://www.codewars.com/kata/64416600772f2775f1de03f9/
using System.Linq;

namespace Codewars
{
    public class RookCountAttack
    {
        public static int CountAttackingRooks(int[][] R)
        {
            return R.GroupBy(x => x[0]).Sum(g => g.Count() - 1) +
              R.GroupBy(x => x[1]).Sum(g => g.Count() - 1);
        }
    }
}
