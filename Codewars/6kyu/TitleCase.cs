using System.Linq;

namespace Codewars
{
    public static class TitleCase
    {
        public static string ToTitleCase(string title, string minorWords = "")
        {
            if(title == string.Empty)
                return string.Empty;

            var nonCapitalizable = minorWords?.ToLower().Split(" ");
            
            var capitalizedTitle = title.Split(" ").Select(x => nonCapitalizable != null && nonCapitalizable.Contains(x.ToLower()) ? x.ToLower() : CapitalizeWord(x));

            return $"{CapitalizeWord(capitalizedTitle.First())} {string.Join(" ", capitalizedTitle.Skip(1))}".Trim();
        }

        private static string CapitalizeWord(string word) => $"{char.ToUpper(word[0])}{word[1..].ToLower()}";
    }
}
