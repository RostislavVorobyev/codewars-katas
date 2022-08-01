using System.Numerics;

namespace Codewars
{
    public class PascalDiagonals
    {
        public static BigInteger[] GenerateDiagonal(int n, int l)
        {
            if (l == 0)
            {
                return System.Array.Empty<BigInteger>();
            }

            var result = new BigInteger[l];
            result[0] = 1;

            for (int i = 1; i < l; i++)
            {
                var current = result[i - 1];
                var next = GetNext(current, i, n);
                result[i] = next;
            }

            return result;
        }

        private static BigInteger GetNext(BigInteger current, int i, int position) => current * position / i + current;
    }
}
