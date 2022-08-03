/*
 * Break camelCase: https://www.codewars.com/kata/5208f99aee097e6552000148
 * 
 * This task can be solved much easier with [A-Z] Regex.
 */
using System.Linq;

namespace Codewars
{
    public class CamelCaseBreaker
    {
        public string BreakCamelCase(string str)
        {
            return string.Join("", str.Select(x => char.IsUpper(x) ? $" {x}" : x.ToString()).ToArray());
        }
    }
}
