using System.Linq;

namespace Codewars
{
    public class SurviveTheAttack
    {
        public static bool HasSurvived(int[] attackers, int[] defenders)
        {
            var zip = Enumerable.Zip(attackers, defenders, (a, d) => d - a);

            var defSurvivours = zip.Where(r => r > 0).Count();
            var atackSurvivours = zip.Where(r => r < 0).Count();

            var survivoursDif = defSurvivours - atackSurvivours + defenders.Length - attackers.Length;

            if (survivoursDif == 0)
            {
                return defenders.Sum() >= attackers.Sum();
            }

            return survivoursDif > 0;
        }
    }
}
