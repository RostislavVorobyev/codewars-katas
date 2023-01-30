namespace Codewars
{
    public static class CreatePhoneNumber
    {
        public static string CreateNumber(int[] numbers)
        {
            var str = string.Join("", numbers);
            return $"({str[0..2]} {str[2..5]}-{str[^4]})";
        }
    }
}
