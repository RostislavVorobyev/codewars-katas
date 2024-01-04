using System.Linq;

namespace Codewars

{
    public static class SalesmanTravel
    {
        public static string Travel(string r, string zipcode)
        {
            var addressGroups = r.Split(',')
                .GroupBy(x => x[^8..])
                .Where(x => x.Key == zipcode)
                .FirstOrDefault();

            return addressGroups != null ?
                $"{zipcode}:{string.Join(',', addressGroups.Select(x => $"{x[(x.IndexOf(' ') + 1)..(x.IndexOf(zipcode) - 1)]}"))}" +
                $"/{string.Join(',', addressGroups.Select(x => x[..x.IndexOf(' ')]))}"
                : $"{zipcode}:/";
        }

    }
}
