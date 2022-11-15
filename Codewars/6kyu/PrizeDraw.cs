using System.Linq;

namespace Codewars
{
    public class PrizeDraw
    {
        public static string NthRank(string st, int[] we, int n)
        {
            if (!st.Any())
            {
                return "No participants";
            }

            var names = st.Split(',');

            if (n > names.Length)
            {
                return "Not enough participants";
            }

            return st.Split(',')
                .Zip(we, (name, weight) => (name, (name.Sum(l => char.ToLower(l) - 96) + name.Length) * weight))
                .OrderBy(nameValuePair => nameValuePair.Item2)
                .ThenBy(nameValuePair => nameValuePair.name)
                .Skip(n - 1)
                .First().name;
        }
    }
}
