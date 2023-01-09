namespace Codewars
{
    public static class Chaser
    {
        public static int SpeedAndTime(int s, int t)
        {
            var distance = s * t;
            var maxSprint = System.Math.Ceiling((double)t / 2);

            for (var i = 0; i < maxSprint; i++)
            {
                if (s - 3 * i >= 0)
                {
                    distance += s - 3 * i;
                }
            }
            return distance;
        }
    }
}
