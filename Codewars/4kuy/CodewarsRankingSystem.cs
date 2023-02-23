using System;

namespace Codewars
{
    public class CodewarsRankingSystem
    {
        public static class RanksHelper
        {
            private static readonly int[] Ranks = new int[] { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };

            public static int GetRankIndex(int rank)
            {
                return Array.IndexOf(Ranks, rank);
            }

            public static int GetRank(int index)
            {
                return Ranks[index];
            }
        }
        public static class UserRankService
        {
            const int ProgressToNextRank = 100;

            public static void UpdateProgress(int progressScore, User user)
            {
                user.Progress += progressScore;

                if (user.Progress >= ProgressToNextRank)
                {
                    UpdateRank(user);
                }
            }

            private static void UpdateRank(User user)
            {
                var obtainedRanks = user.Progress / ProgressToNextRank;
                int currentRankIndex = RanksHelper.GetRankIndex(user.Rank);

                var newRankIndex = Math.Max(currentRankIndex + obtainedRanks, obtainedRanks);

                user.Rank = RanksHelper.GetRank(newRankIndex);
                user.Progress %= 100;
            }
        }

        public static class ProgressCalculator
        {
            private const int ProgressForEqualActivity = 3;
            private const int ProgressForOneRankLowerActivity = 1;

            public static int EvaluateActivity(int activityRank, int userRank)
            {
                if (activityRank == userRank)
                {
                    return ProgressForEqualActivity;
                }
                else if (RanksHelper.GetRankIndex(activityRank) == RanksHelper.GetRankIndex(userRank) - 1)
                {
                    return ProgressForOneRankLowerActivity;
                }
                else if (activityRank > userRank)
                {
                    var rankingDiff = RanksHelper.GetRankIndex(activityRank) - RanksHelper.GetRankIndex(userRank);

                    return 10 * rankingDiff * rankingDiff;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class User
        {
            public int Rank { get; set; }
            public int Progress { get; set; }

            public User()
            {
                this.Rank = -8;
                this.Progress = 0;
            }

            public void incProgress(int actRank)
            {
                if (!IsValid(actRank))
                {
                    throw new ArgumentException();
                }

                var progressScore = Rank != 8 ? ProgressCalculator.EvaluateActivity(actRank, Rank) : 0;

                if (progressScore > 0 && Rank != 8)
                {
                    UserRankService.UpdateProgress(progressScore, this);
                }
            }

            private bool IsValid(int actRank)
            {
                return actRank <= 8 && actRank >= -8 && actRank != 0;
            }
        }
    }
}
