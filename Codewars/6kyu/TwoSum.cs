namespace Codewars
{
    public static class TwoSum
    {
        public static int[] FindTwoSum(int[] numbers, int target)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] + numbers[i] == target)
                        return new[] { i, j };
                }
            }

            return new int[0];
        }
    }
}
