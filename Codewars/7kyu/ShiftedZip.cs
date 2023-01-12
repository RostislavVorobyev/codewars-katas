namespace Codewars
{
    public static class ShiftedZip
    {
        public static int[] AddingShifted(int[][] arrayOfArrays, int shift)
        {
            var arrLength = arrayOfArrays[0].Length;
            int[] result = new int[arrLength + (arrayOfArrays.Length -1) * shift];

            int currentShift = 0;

            for (int i = 0; i < arrayOfArrays.Length; i++)
            {
                for (int j = 0; j < arrLength; j++)
                {
                    result[j + currentShift] += arrayOfArrays[i][j];
                }

                currentShift += shift;
            }

            return result;
        }
    }
}
