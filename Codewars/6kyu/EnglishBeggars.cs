namespace Codewars
{
    public static class EnglishBeggars
    {
        public static int[] Beggars(int[] values, int n)
        {
            var result = new int[n];

            if (n == 0) { return result; }

            for (int i = 0; i < values.Length; i++)
            {
                result[i % n] += values[i];
            }

            return result;
        }
    }
}
