using System.Linq;

namespace Codewars
{
    public static class DigitalRoot
    {
        public static int Calculate(long n)
        {
            while (n / 10 > 0)
            {
                n = n.ToString().Sum(x => x - '0');
            }

            return (int)n;
        }
    }
}
