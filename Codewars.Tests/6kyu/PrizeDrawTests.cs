using NUnit.Framework;

namespace Codewars.Tests._6kyu
{
    [TestFixture]
    public class PrizeDrawTests
    {
        public static string participants;
        public static int[] weights;

        [Test]
        public static void NthRank_Should_Return_NoParticipants_On_Empty_Participants_List()
        {
            participants = string.Empty;
            weights = new int[] { 4, 2, 1, 4, 3, 1, 2 };
            Assert.AreEqual("No participants", PrizeDraw.NthRank(participants, weights, 4));
        }

        [Test]
        public static void NthRank_Should_Return_NoTEnoughParticipants_When_Weights_List_Less_Then_Participants_List()
        {
            participants = "Addison,Jayden,Sofia,Michael,Andrew,Lily,Benjamin";
            weights = new int[] { 4, 2, 1, 4, 3, 1, 2 };
            Assert.AreEqual("Not enough participants", PrizeDraw.NthRank(participants, weights, 8));
        }

        [Test]
        public static void NthRank_Should_Return_Participant_With_Rank_N()
        {
            participants = "Elijah,Chloe,Elizabeth,Matthew,Natalie,Jayden";
            weights = new int[] { 1, 3, 5, 5, 3, 6 };
            var n = 2;

            Assert.AreEqual("Matthew", PrizeDraw.NthRank(participants, weights, n));
        }
    }
}