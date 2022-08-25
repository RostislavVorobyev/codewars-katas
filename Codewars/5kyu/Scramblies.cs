using System.Linq;

namespace Codewars
{
    public static class Scramblies
    {
        public static bool Scramble(string str1, string str2)
        {
            var str1LettersGroups = str2.GroupBy(x => x);
            var str2LettersGroups = str1.GroupBy(x => x); 

            foreach(var letterGroup in str1LettersGroups)
            {
                var sameLetterGroupInStr2 = str2LettersGroups.Where(x => x.Key == letterGroup.Key);

                if (!sameLetterGroupInStr2.Any() || letterGroup.Count() > sameLetterGroupInStr2.First().Count())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
