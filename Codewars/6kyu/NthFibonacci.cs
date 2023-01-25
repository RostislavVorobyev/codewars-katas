namespace Codewars
{
    public static class NthFibonacci
    {
        public static int NthFib(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;

            return NthFib(n - 1) + NthFib(n - 2);
        }
    }
}
