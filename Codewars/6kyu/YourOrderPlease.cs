using System.Linq;

/*
 * Your order, please : https://www.codewars.com/kata/55c45be3b2079eccff00010f/train/csharp
 */
namespace Codewars
{
    public class YourOrderPlease
    {
        public static string Order(string words)
        {
            if (words == string.Empty) 
                return string.Empty;

            var sortedWords = words.Split(" ").OrderBy(x => x.First(l => char.IsDigit(l)));
            
            return string.Join(" ", sortedWords);
        }
    }
}
