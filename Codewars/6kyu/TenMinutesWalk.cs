/*
 * Take a Ten Minutes Walk: https://www.codewars.com/kata/54da539698b8a2ad76000228/
 */
using System.Linq;

namespace Codewars
{
    public class TenMinutesWalk
    {
        public bool IsValidWalk(string[] walk)
        {
            return walk.Length == 10 
                && walk.Count(x => x == "n") == walk.Count(x => x == "s") 
                && walk.Count(x => x == "e") == walk.Count(x => x == "w");
        }
    }
}
